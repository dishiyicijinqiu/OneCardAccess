using DevExpress.XtraEditors.Controls;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Helper
{
    public class BackgroundFileLoader : IDisposable
    {
        public static BackgroundFileLoader DefaultInstance
        {
            get
            {
                return new BackgroundFileLoader();
            }
        }
        // Fields
        private BackgroundFileLoaderEventHandler _Loaded;
        private BackgroundWorker worker;

        // Events
        public event BackgroundFileLoaderEventHandler Loaded
        {
            add
            {
                BackgroundFileLoaderEventHandler handler2;
                BackgroundFileLoaderEventHandler loaded = this._Loaded;
                do
                {
                    handler2 = loaded;
                    BackgroundFileLoaderEventHandler handler3 = (BackgroundFileLoaderEventHandler)Delegate.Combine(handler2, value);
                    loaded = Interlocked.CompareExchange<BackgroundFileLoaderEventHandler>(ref this._Loaded, handler3, handler2);
                }
                while (loaded != handler2);
            }
            remove
            {
                BackgroundFileLoaderEventHandler handler2;
                BackgroundFileLoaderEventHandler loaded = this._Loaded;
                do
                {
                    handler2 = loaded;
                    BackgroundFileLoaderEventHandler handler3 = (BackgroundFileLoaderEventHandler)Delegate.Remove(handler2, value);
                    loaded = Interlocked.CompareExchange<BackgroundFileLoaderEventHandler>(ref this._Loaded, handler3, handler2);
                }
                while (loaded != handler2);
            }
        }

        // Methods
        public void Abort()
        {
            if (this.worker != null)
            {
                this.worker.CancelAsync();
                this.worker = null;
            }
        }

        private Uri CalculateUri(string path)
        {
            try
            {
                return new Uri(path);
            }
            catch (UriFormatException)
            {
                path = Path.GetFullPath(path);
                return new Uri(path);
            }
        }

        private bool CheckCancel(BackgroundWorker worker, DoWorkEventArgs e, WebRequest request)
        {
            if (worker.CancellationPending)
            {
                request.Abort();
                e.Cancel = true;
                return true;
            }
            return false;
        }

        public virtual void Dispose()
        {
            this._Loaded = null;
            this.Abort();
        }
        private string filename;
        private string savename;
        public void Load(string filename, string savename = null)
        {
            if (string.IsNullOrWhiteSpace(Path.GetExtension(filename)))
                throw new BusinessException("不是有效的文件地址");
            if (this.Loading)
            {
                this.Abort();
            }
            this.filename = filename;
            this.savename = savename;
            this.LoadAsync(filename, savename);
        }

        private void LoadAsync(string filename, string savename)
        {
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(this.LoadAsyncThread);
            this.worker.RunWorkerAsync(new string[] { filename, savename });
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadAsyncCompleted);
        }

        private void LoadAsyncCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Exception result = e.Result as Exception;
                if (this._Loaded != null)
                {
                    this._Loaded(this, new BackgroundFileLoaderEventArgs(result, false, savename, filename));
                }
            }
            else if (this._Loaded != null)
            {
                this._Loaded(this, new BackgroundFileLoaderEventArgs(null, true, savename, filename));
            }
            ((BackgroundWorker)sender).Dispose();
            if (this.worker == sender)
            {
                this.worker = null;
            }
        }

        private void LoadAsyncThread(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.LoadAsyncThreadCore(sender, e);
            }
            catch (Exception exception)
            {
                if (!e.Cancel)
                {
                    e.Result = exception;
                }
            }
        }

        private void LoadAsyncThreadCore(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string filename = (e.Argument as string[])[0];
            string savename = (e.Argument as string[])[1];
            if (string.IsNullOrWhiteSpace(savename))
            {
                savename = string.Format("{0}{1}", Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()), Path.GetExtension(filename));
                this.savename = savename;
            }
            FileStream fs = new FileStream(savename, FileMode.Create);
            try
            {
                WebRequest request = WebRequest.Create(this.CalculateUri(filename));
                if (!this.CheckCancel(worker, e, request))
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        if (this.CheckCancel(worker, e, request))
                        {
                            return;
                        }
                        Stream responseStream = response.GetResponseStream();
                        if (this.CheckCancel(worker, e, request))
                        {
                            return;
                        }
                        byte[] buffer = new byte[0x3e8];
                    Label_006B:
                        if (this.CheckCancel(worker, e, request))
                        {
                            return;
                        }
                        int count = responseStream.Read(buffer, 0, buffer.Length);
                        if (count != 0)
                        {
                            fs.Write(buffer, 0, count);
                            goto Label_006B;
                        }
                        response.Close();
                    }
                    this.CheckCancel(worker, e, request);
                    if (!e.Cancel)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
        }

        // Properties
        public bool Loading
        {
            get
            {
                return (this.worker != null);
            }
        }

    }
    public delegate void BackgroundFileLoaderEventHandler(object sender, BackgroundFileLoaderEventArgs e);
    public class BackgroundFileLoaderEventArgs : EventArgs
    {
        // Fields
        private bool cancelled;
        private Exception error;

        // Methods
        public BackgroundFileLoaderEventArgs(Exception error, bool cancelled, string savename, string filename)
        {
            this.cancelled = cancelled;
            this.error = error;
            this.SaveName = savename;
            this.FileName = filename;
        }

        // Properties
        public bool Cancelled
        {
            get
            {
                return this.cancelled;
            }
        }

        public Exception Error
        {
            get
            {
                return this.error;
            }
        }

        public bool HasError
        {
            get
            {
                return (this.error != null);
            }
        }
        public string SaveName { get; private set; }
        public string FileName { get; private set; }
    }
}
