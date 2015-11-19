using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.Unity.Utility;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FengSharp.OneCardAccess.Infrastructure
{
    [ConfigurationElementType(typeof(RollingFlatFileTraceListenerData))]
    public class MyRollingFlatFileTraceListener : CustomTraceListener
    {

        private ConcurrentDictionary<string, RollingFlatFileTraceListener> _dic = new ConcurrentDictionary<string, RollingFlatFileTraceListener>();
        private MyCustomerRollingFlatFileTraceListener _defaultListener;
        private readonly MyStreamWriterRollingHelper rollingHelper;
        internal readonly string directory;
        private readonly string extension;
        private readonly string header;
        private readonly string footer;
        private readonly int rollSizeInBytes;
        private readonly string timeStampPattern;
        private readonly RollFileExistsBehavior rollFileExistsBehavior;
        private readonly RollInterval rollInterval;
        private readonly int maxArchivedFiles;
        public MyRollingFlatFileTraceListener(string fileName,
                                        string header,
                                        string footer,
                                        ILogFormatter formatter = null,
                                        int rollSizeKB = 0,
                                        string timeStampPattern = "yyyy-MM-dd",
                                        RollFileExistsBehavior rollFileExistsBehavior = RollFileExistsBehavior.Overwrite,
                                        RollInterval rollInterval = RollInterval.None,
                                        int maxArchivedFiles = 0)
        {
            string formatFileName = Path.GetFileName(fileName);
            Guard.ArgumentNotNullOrEmpty(fileName, "fileName");
            this.extension = Path.GetExtension(fileName);
            this.header = header;
            this.footer = footer;
            this.rollSizeInBytes = rollSizeKB;
            this.timeStampPattern = timeStampPattern;
            this.rollFileExistsBehavior = rollFileExistsBehavior;
            this.rollInterval = rollInterval;
            this.maxArchivedFiles = maxArchivedFiles;

            this.Formatter = formatter;

            fileName = CalcRealFileName(fileName);
            this._defaultListener = new MyCustomerRollingFlatFileTraceListener(formatFileName, fileName, this.header, this.footer,
                            this.Formatter, this.rollSizeInBytes, this.timeStampPattern,
                            this.rollFileExistsBehavior, this.rollInterval, this.maxArchivedFiles);
            this.rollingHelper = new MyStreamWriterRollingHelper(this);

            fileName = ((FileStream)((StreamWriter)_defaultListener.Writer).BaseStream).Name;
            this.directory = Path.GetDirectoryName(fileName);

        }
        internal static string CalcRealFileName(string fileName)
        {
            if (!fileName.Contains("{"))
                return fileName;
            try
            {
                int startIndex = fileName.IndexOf('{');
                int endIndex = fileName.IndexOf('}');
                string formartstring = fileName.Substring(startIndex, endIndex - startIndex);
                string result = fileName.Replace(formartstring, DateTime.Now.ToString(formartstring));
                return result;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new Exception("文件名格式错误");
            }
        }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            //if (this.Filter == null || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            //{
            rollingHelper.RollIfNecessary();
            var listener = this._defaultListener;
            listener.TraceData(eventCache, source, eventType, id, data);
            listener.Flush();
            //}
        }
        public override void Write(string message)
        {
            this._defaultListener.Write(message);
        }
        public override void WriteLine(string message)
        {
            this._defaultListener.WriteLine(message);
        }
        public override void Flush()
        {
            this._defaultListener.Flush();
        }
        public MyStreamWriterRollingHelper RollingHelper
        {
            get { return rollingHelper; }
        }

        /// <summary>
        /// Encapsulates the logic to perform rolls.
        /// </summary>
        /// <remarks>
        /// If no rolling behavior has been configured no further processing will be performed.
        /// </remarks>
        public sealed class MyStreamWriterRollingHelper
        {
            /// <summary>
            /// A tally keeping writer used when file size rolling is configured.<para/>
            /// The original stream writer from the base trace listener will be replaced with
            /// this listener.
            /// </summary>
            MyTallyKeepingFileStreamWriter managedWriter;

            /// <summary>
            /// The trace listener for which rolling is being managed.
            /// </summary>
            MyRollingFlatFileTraceListener owner;

            /// <summary>
            /// A flag indicating whether at least one rolling criteria has been configured.
            /// </summary>
            bool performsRolling;

            /// <summary>
            /// Initialize a new instance of the <see cref="StreamWriterRollingHelper"/> class with a <see cref="RollingFlatFileTraceListener"/>.
            /// </summary>
            /// <param name="owner">The <see cref="RollingFlatFileTraceListener"/> to use.</param>
            public MyStreamWriterRollingHelper(MyRollingFlatFileTraceListener owner)
            {
                this.owner = owner;
                performsRolling = this.owner.rollInterval != RollInterval.None || this.owner.rollSizeInBytes > 0;
            }

            /// <summary>
            /// Finds the max sequence number for a log file.
            /// </summary>
            /// <param name="directoryName">The directory to scan.</param>
            /// <param name="fileName">The file name.</param>
            /// <param name="extension">The extension to use.</param>
            /// <returns>The next sequence number.</returns>
            public static int FindMaxSequenceNumber(string directoryName,
                                                    string fileName,
                                                    string extension)
            {
                string[] existingFiles = Directory.GetFiles(directoryName,
                                                            string.Format("{0}*{1}", fileName, extension));

                int maxSequence = 0;
                Regex regex = new Regex(string.Format(@"{0}\.(?<sequence>\d+){1}$", fileName, extension));
                for (int i = 0; i < existingFiles.Length; i++)
                {
                    Match sequenceMatch = regex.Match(existingFiles[i]);
                    if (sequenceMatch.Success)
                    {
                        int currentSequence = 0;

                        string sequenceInFile = sequenceMatch.Groups["sequence"].Value;
                        if (!int.TryParse(sequenceInFile, out currentSequence))
                            continue; // very unlikely

                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                        }
                    }
                }

                return maxSequence;
            }

            static Encoding GetEncodingWithFallback()
            {
                Encoding encoding = (Encoding)new UTF8Encoding(false).Clone();
                encoding.EncoderFallback = EncoderFallback.ReplacementFallback;
                encoding.DecoderFallback = DecoderFallback.ReplacementFallback;
                return encoding;
            }


            /// <summary>
            /// Rolls the file if necessary.
            /// </summary>
            public void RollIfNecessary()
            {
                if (!performsRolling)
                {
                    // avoid further processing if no rolling has been configured.
                    return;
                }

                string nextFileName;
                if ((nextFileName = CheckIsRollNecessary()) != null)
                {
                    PerformRoll(nextFileName);
                }
            }

            private void PerformRoll(string nextFileName)
            {
                string actualFileName = ((FileStream)((StreamWriter)owner._defaultListener.Writer).BaseStream).Name;

                if (this.owner.rollFileExistsBehavior == RollFileExistsBehavior.Overwrite
                    && string.IsNullOrEmpty(this.owner.timeStampPattern))
                {
                    // no roll will be actually performed: no timestamp pattern is available, and 
                    // the roll behavior is overwrite, so the original file will be truncated
                    owner._defaultListener.Writer.Close();
                    File.WriteAllText(actualFileName, string.Empty);
                }
                else
                {
                    owner._defaultListener.Writer.Close();
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(nextFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                        managedWriter = new MyTallyKeepingFileStreamWriter(fileStream, GetEncodingWithFallback());
                        //owner._defaultListener.Writer = null;
                    }
                    catch (Exception)
                    {
                        nextFileName = nextFileName + Guid.NewGuid().ToString();
                        fileStream = new FileStream(nextFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                        managedWriter = new MyTallyKeepingFileStreamWriter(fileStream, GetEncodingWithFallback());
                        // there's a slight chance of error here - abort if this occurs and just let TWTL handle it without attempting to roll
                        //return false;
                    }
                    finally
                    {
                        owner._defaultListener.Writer = null;
                        owner._defaultListener.Writer = managedWriter;
                        managedWriter = null;
                    }
                }
            }

            private string CheckIsRollNecessary()
            {
                string formatFileName = this.owner._defaultListener.FormatFileName;
                string nextFileName = MyRollingFlatFileTraceListener.CalcRealFileName(formatFileName);
                nextFileName = Path.Combine(this.owner.directory, nextFileName);
                string nowFileName = ((FileStream)((StreamWriter)owner._defaultListener.Writer).BaseStream).Name;
                if (string.Compare(nowFileName, nextFileName, false) != 0)
                {
                    return nextFileName;
                }
                return null;
            }
        }

        /// <summary>
        /// Represents a file stream writer that keeps a tally of the length of the file.
        /// </summary>
        public sealed class MyTallyKeepingFileStreamWriter : StreamWriter
        {
            long tally;

            /// <summary>
            /// Initialize a new instance of the <see cref="TallyKeepingFileStreamWriter"/> class with a <see cref="FileStream"/>.
            /// </summary>
            /// <param name="stream">The <see cref="FileStream"/> to write to.</param>
            public MyTallyKeepingFileStreamWriter(FileStream stream)
                : base(stream)
            {
                tally = stream.Length;
            }

            /// <summary>
            /// Initialize a new instance of the <see cref="TallyKeepingFileStreamWriter"/> class with a <see cref="FileStream"/>.
            /// </summary>
            /// <param name="stream">The <see cref="FileStream"/> to write to.</param>
            /// <param name="encoding">The <see cref="Encoding"/> to use.</param>
            public MyTallyKeepingFileStreamWriter(FileStream stream,
                                                Encoding encoding)
                : base(stream, encoding)
            {
                tally = stream.Length;
            }

            /// <summary>
            /// Gets the tally of the length of the string.
            /// </summary>
            /// <value>
            /// The tally of the length of the string.
            /// </value>
            public long Tally
            {
                get { return tally; }
            }

            ///<summary>
            ///Writes a character to the stream.
            ///</summary>
            ///
            ///<param name="value">The character to write to the text stream. </param>
            ///<exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and current writer is closed. </exception>
            ///<exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"></see> is at the end the stream. </exception>
            ///<exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
            public override void Write(char value)
            {
                base.Write(value);
                tally += Encoding.GetByteCount(new char[] { value });
            }

            ///<summary>
            ///Writes a character array to the stream.
            ///</summary>
            ///
            ///<param name="buffer">A character array containing the data to write. If buffer is null, nothing is written. </param>
            ///<exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and current writer is closed. </exception>
            ///<exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"></see> is at the end the stream. </exception>
            ///<exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
            public override void Write(char[] buffer)
            {
                base.Write(buffer);
                tally += Encoding.GetByteCount(buffer);
            }

            ///<summary>
            ///Writes a subarray of characters to the stream.
            ///</summary>
            ///
            ///<param name="count">The number of characters to read from buffer. </param>
            ///<param name="buffer">A character array containing the data to write. </param>
            ///<param name="index">The index into buffer at which to begin writing. </param>
            ///<exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            ///<exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and current writer is closed. </exception>
            ///<exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"></see> is at the end the stream. </exception>
            ///<exception cref="T:System.ArgumentOutOfRangeException">index or count is negative. </exception>
            ///<exception cref="T:System.ArgumentException">The buffer length minus index is less than count. </exception>
            ///<exception cref="T:System.ArgumentNullException">buffer is null. </exception><filterpriority>1</filterpriority>
            public override void Write(char[] buffer,
                                       int index,
                                       int count)
            {
                base.Write(buffer, index, count);
                tally += Encoding.GetByteCount(buffer, index, count);
            }

            ///<summary>
            ///Writes a string to the stream.
            ///</summary>
            ///
            ///<param name="value">The string to write to the stream. If value is null, nothing is written. </param>
            ///<exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and current writer is closed. </exception>
            ///<exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"></see> is true or the <see cref="T:System.IO.StreamWriter"></see> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"></see> is at the end the stream. </exception>
            ///<exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
            public override void Write(string value)
            {
                base.Write(value);
                tally += Encoding.GetByteCount(value);
            }
        }
    }
    public class MyRollingFlatFileTraceListenerData : RollingFlatFileTraceListenerData
    {
        protected override System.Linq.Expressions.Expression<Func<TraceListener>> GetCreationExpression()
        {
            return
            () =>
                new MyRollingFlatFileTraceListener(
                    this.FileName,
                    this.Header,
                    this.Footer,
                    Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Container.ResolvedIfNotNull<ILogFormatter>(this.Formatter),
                    this.RollSizeKB,
                    this.TimeStampPattern,
                    this.RollFileExistsBehavior,
                    this.RollInterval,
                    this.MaxArchivedFiles);
        }
    }
    public class MyCustomerRollingFlatFileTraceListener : RollingFlatFileTraceListener
    {
        public string FormatFileName { get; set; }
        private string header;
        private string footer;
        public MyCustomerRollingFlatFileTraceListener(string formatFileName, string fileName, string header, string footer, ILogFormatter formatter, int rollSizeKB,
            string timeStampPattern, RollFileExistsBehavior rollFileExistsBehavior, RollInterval rollInterval, int maxArchivedFiles)
            : base(fileName, header, footer, formatter, rollSizeKB, timeStampPattern, rollFileExistsBehavior, rollInterval, maxArchivedFiles)
        {
            this.header = header;
            this.footer = footer;
            this.FormatFileName = formatFileName;
        }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if (this.Filter == null || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (header.Length > 0)
                    WriteLine(header);

                if (data is LogEntry)
                {
                    if (this.Formatter != null)
                    {
                        base.WriteLine(this.Formatter.Format(data as LogEntry));
                    }
                    else
                    {
                        base.TraceData(eventCache, source, eventType, id, data);
                    }
                }
                else
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }

                if (footer.Length > 0)
                    WriteLine(footer);
            }
        }

    }
}
