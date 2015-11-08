﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public class EmployeePhotoPictureEdit : BasePictureEdit
    {
        public EmployeePhotoPictureEdit()
            : base()
        {
            this.imageUpLoader = new BackgroundImageURLUpLoader();
            this.imageUpLoader.UpLoaded += imageUpLoader_UpLoaded;
        }

        void imageUpLoader_UpLoaded(object sender, BackgroundImageUpLoaderEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.HasError)
                {
                    this.Image = this.imageUpLoader.LastImage;
                    MessageBoxEx.Error(e.Error);
                }
                else
                {
                    this.Image = System.Drawing.Image.FromFile(this.imageUpLoader.UpLoadName);
                    this._Photo = this.imageUpLoader.SaveName;
                }
            }
            else
            {
                this.Image = this.imageUpLoader.LastImage;
            }
        }
        public void CancelUpLoadAsync()
        {
            this.imageUpLoader.Abort();
        }
        public void UpLoadAsync(string savename)
        {
            this.imageUpLoader.UpLoad(savename);
        }

        private string _Photo;
        public string Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                if (_Photo == value) return;
                _Photo = value;
                this.LoadAsync(string.Format("{0}/{1}/{2}", ApplicationConfig.AttachmentPath, ApplicationConfig.EmployeePhotoPath, _Photo));
            }
        }
        private PictureMenu _Menu;
        protected override PictureMenu Menu
        {
            get
            {
                if (_Menu == null)
                {
                    _Menu = new PictureMenu(this);
                    _Menu.Items.Clear();
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("预览", OnPriviewClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuPriview));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("复制", OnCopyClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuCopy));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("删除", OnDeleteClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuDelete));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("上传", OnUpLoadClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuLoad));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("保存", OnSaveClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuSave));
                }
                return _Menu;
            }
        }
        private void OnPriviewClick(object sender, System.EventArgs e)
        {
            try
            {
                PictureExplorer explorer = new PictureExplorer(this.Image);
                explorer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        private void OnCopyClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedCopy", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        private void OnDeleteClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedDelete", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
            this._Photo = string.Empty;
        }
        private void OnUpLoadClick(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog opendia = new OpenFileDialog();
                opendia.Multiselect = false;
                opendia.Filter = "(请选择jpg图片)|*.jpg";
                if (opendia.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(opendia.FileName))
                    {
                        this.imageUpLoader.UpLoadName = opendia.FileName;
                        this.imageUpLoader.LastImage = this.Image;
                        this.Image = this.Properties.InitialImage;
                        this.imageUpLoader.SaveName = string.Format("{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                        this.UpLoadAsync(string.Format("{0}\\{1}", ApplicationConfig.EmployeePhotoPath, this.imageUpLoader.SaveName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        private void OnSaveClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedSave", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }

        private BackgroundImageURLUpLoader imageUpLoader;

        protected override void Dispose(bool disposing)
        {
            base.fDisposing = true;
            if (disposing)
            {
                if (this.imageUpLoader != null)
                {
                    this.imageUpLoader.Dispose();
                }
            }
            base.Dispose(disposing);

        }
    }
}


//// <summary>
//     /// 将本地文件上传到指定的服务器(HttpWebRequest方法)
//     /// </summary>
//     /// <param name="address">文件上传到的服务器</param>
//     /// <param name="fileNamePath">要上传的本地文件（全路径）</param>
//     /// <param name="saveName">文件上传后的名称</param>
//     /// <param name="progressBar">上传进度条</param>
//     /// <returns>成功返回1，失败返回0</returns>
//     private int Upload_Request(string address, string fileNamePath, string saveName)
//     {
//         int returnValue = 0;
//         // 要上传的文件
//         FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
//         BinaryReader r = new BinaryReader(fs);
//         //时间戳
//         string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
//         byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
//         //请求头部信息
//         StringBuilder sb = new StringBuilder();
//         sb.Append("--");
//         sb.Append(strBoundary);
//         sb.Append("\r\n");
//         sb.Append("Content-Disposition: form-data; name=\"");
//         sb.Append("file");
//         sb.Append("\"; filename=\"");
//         sb.Append(saveName);
//         sb.Append("\"");
//         sb.Append("\r\n");
//         sb.Append("Content-Type: ");
//         sb.Append("application/octet-stream");
//         sb.Append("\r\n");
//         sb.Append("\r\n");
//         string strPostHeader = sb.ToString();
//         byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
//         // 根据uri创建HttpWebRequest对象
//         HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
//         httpReq.Method = "POST";
//         //对发送的数据不使用缓存
//         httpReq.AllowWriteStreamBuffering = false;
//         //设置获得响应的超时时间（300秒）
//         httpReq.Timeout = 300000;
//         httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
//         long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
//         long fileLength = fs.Length;
//         httpReq.ContentLength = length;
//         try
//         {
//             //progressBar.Maximum = int.MaxValue;
//             //progressBar.Minimum = 0;
//             //progressBar.Value = 0;
//             //每次上传4k
//             int bufferLength = 4096;
//             byte[] buffer = new byte[bufferLength];
//             //已上传的字节数
//             long offset = 0;
//             //开始上传时间
//             DateTime startTime = DateTime.Now;
//             int size = r.Read(buffer, 0, bufferLength);
//             Stream postStream = httpReq.GetRequestStream();
//             //发送请求头部消息
//             postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
//             while (size > 0)
//             {
//                 postStream.Write(buffer, 0, size);
//                 offset += size;
//                 //progressBar.Value = (int)(offset * (int.MaxValue / length));
//                 //TimeSpan span = DateTime.Now - startTime;
//                 //double second = span.TotalSeconds;
//                 //lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
//                 //if (second > 0.001)
//                 //{
//                 //    lblSpeed.Text = " 平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
//                 //}
//                 //else
//                 //{
//                 //    lblSpeed.Text = " 正在连接…";
//                 //}
//                 //lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
//                 //lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
//                 //Application.DoEvents();
//                 size = r.Read(buffer, 0, bufferLength);
//             }
//             //添加尾部的时间戳
//             postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
//             postStream.Close();
//             //获取服务器端的响应
//             WebResponse webRespon = httpReq.GetResponse();
//             Stream s = webRespon.GetResponseStream();
//             StreamReader sr = new StreamReader(s);
//             //读取服务器端返回的消息
//             String sReturnString = sr.ReadLine();
//             s.Close();
//             sr.Close();
//             if (sReturnString == "Success")
//             {
//                 returnValue = 1;
//             }
//             else if (sReturnString == "Error")
//             {
//                 returnValue = 0;
//             }
//         }
//         catch
//         {
//             returnValue = 0;
//         }
//         finally
//         {
//             fs.Close();
//             r.Close();
//         }
//         return returnValue;
//     }