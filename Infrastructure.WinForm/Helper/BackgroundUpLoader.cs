using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Helper
{
    public class BackgroundUpLoader
    {
        public static BackgroundUpLoader DefaultInstance
        {
            get
            {
                return new BackgroundUpLoader();
            }
        }
        private BackgroundUpLoaderEventHandler _UpLoaded;
        private BackgroundWorker worker;
        public event BackgroundUpLoaderEventHandler UpLoaded
        {
            add
            {
                BackgroundUpLoaderEventHandler handler2;
                BackgroundUpLoaderEventHandler upLoaded = this._UpLoaded;
                do
                {
                    handler2 = upLoaded;
                    BackgroundUpLoaderEventHandler handler3 = (BackgroundUpLoaderEventHandler)Delegate.Combine(handler2, value);
                    upLoaded = Interlocked.CompareExchange<BackgroundUpLoaderEventHandler>(ref this._UpLoaded, handler3, handler2);
                }
                while (upLoaded != handler2);
            }
            remove
            {
                BackgroundUpLoaderEventHandler handler2;
                BackgroundUpLoaderEventHandler upLoaded = this._UpLoaded;
                do
                {
                    handler2 = upLoaded;
                    BackgroundUpLoaderEventHandler handler3 = (BackgroundUpLoaderEventHandler)Delegate.Remove(handler2, value);
                    upLoaded = Interlocked.CompareExchange<BackgroundUpLoaderEventHandler>(ref this._UpLoaded, handler3, handler2);
                }
                while (upLoaded != handler2);
            }
        }
        public void Abort()
        {
            if (this.worker != null)
            {
                this.worker.CancelAsync();
                this.worker = null;
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
            this.Abort();
            this._UpLoaded = null;
        }
        private string filename;
        private string savename;
        public void UpLoad(string filename, string savename)
        {
            if (this.UpLoading)
            {
                this.Abort();
            }
            this.filename = filename;
            this.savename = savename;
            this.UpLoadAsync(filename, savename);
        }
        private void UpLoadAsync(string filename, string savename)
        {
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(this.UpLoadAsyncThread);
            this.worker.RunWorkerAsync(new string[] { filename, savename });
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.UpLoadAsyncCompleted);
        }
        private void UpLoadAsyncCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Exception result = e.Result as Exception;
                if (this._UpLoaded != null)
                {
                    this._UpLoaded(this, new BackgroundUpLoaderEventArgs(result, false, this.savename, this.filename));
                }
            }
            else if (this._UpLoaded != null)
            {
                this._UpLoaded(this, new BackgroundUpLoaderEventArgs(null, true, this.savename, this.filename));
            }
            ((BackgroundWorker)sender).Dispose();
            if (this.worker == sender)
            {
                this.worker = null;
            }
        }
        private void UpLoadAsyncThread(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.UpLoadAsyncThreadCore(sender, e);
            }
            catch (Exception exception)
            {
                if (!e.Cancel)
                {
                    e.Result = exception;
                }
            }
        }
        public bool UpLoading
        {
            get
            {
                return (this.worker != null);
            }
        }

        private void UpLoadAsyncThreadCore(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string filename = (e.Argument as string[])[0];
            string savename = (e.Argument as string[])[1];
            if (String.IsNullOrWhiteSpace(savename))
                throw new Exception("保存文件名为空");
            if (!File.Exists(filename))
                throw new Exception("上传文件不存在");
            // 要上传的文件
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求头部信息
            StringBuilder sb = new StringBuilder();
            #region 请求头部信息
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(savename);
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            #endregion
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
            // 根据uri创建HttpWebRequest对象
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(Application.IntegeatedManage.Config.ApplicationConfig.FileUpLoadHandler));
            if (this.CheckCancel(worker, e, httpReq))
            {
                return;
            }
            httpReq.Method = "POST";
            //对发送的数据不使用缓存
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）
            httpReq.Timeout = Application.IntegeatedManage.Config.ApplicationConfig.FileUpLoadTimeout;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                //每次上传4k
                int bufferLength = 0x3e8;
                byte[] buffer = new byte[bufferLength];
                //已上传的字节数
                long offset = 0;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();
                if (this.CheckCancel(worker, e, httpReq))
                {
                    return;
                }
                //发送请求头部消息
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    if (this.CheckCancel(worker, e, httpReq))
                    {
                        return;
                    }
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();
                //获取服务器端的响应
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                //读取服务器端返回的消息
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString != "Success")
                {
                    throw new Exception("上传失败");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new Exception("上传失败");
            }
            finally
            {
                fs.Close();
                r.Close();
            }
        }
    }

    public delegate void BackgroundUpLoaderEventHandler(object sender, BackgroundUpLoaderEventArgs e);
    public class BackgroundUpLoaderEventArgs : EventArgs
    {
        // Fields
        private bool cancelled;
        private Exception error;

        // Methods
        public BackgroundUpLoaderEventArgs(Exception error, bool cancelled, string savename, string showname)
        {
            this.cancelled = cancelled;
            this.error = error;
            this.SaveName = savename;
            this.ShowName = showname;
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
        public string ShowName { get; private set; }
    }
}
