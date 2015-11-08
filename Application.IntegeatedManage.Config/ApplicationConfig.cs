using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Application.IntegeatedManage.Config
{
    public class ApplicationConfig
    {
        /// <summary>
        /// 插件路径
        /// </summary>
        public static readonly string PluginsPath = System.Configuration.ConfigurationManager.AppSettings["PluginsPath"];
        /// <summary>
        /// 附件路径
        /// </summary>
        public static readonly string AttachmentPath = System.Configuration.ConfigurationManager.AppSettings["AttachmentPath"];
        /// <summary>
        /// 员工照片路径
        /// </summary>
        public static readonly string EmployeePhotoPath = System.Configuration.ConfigurationManager.AppSettings["EmployeePhotoPath"];
        /// <summary>
        /// 员工附件路径
        /// </summary>
        public static readonly string EmployeeAttachmentPath = System.Configuration.ConfigurationManager.AppSettings["EmployeeAttachmentPath"];
        /// <summary>
        /// 注册证文件路径
        /// </summary>
        public static readonly string RegisterFilePath = System.Configuration.ConfigurationManager.AppSettings["RegisterFilePath"];
        /// <summary>
        /// 注册证附件路径
        /// </summary>
        public static readonly string RegisterAttachmentPath = System.Configuration.ConfigurationManager.AppSettings["RegisterAttachmentPath"];
        /// <summary>
        /// 文件上传处理者
        /// </summary>
        public static readonly string FileUpLoadHandler = System.Configuration.ConfigurationManager.AppSettings["FileUpLoadHandler"];
        /// <summary>
        /// 文件上传超时时间
        /// </summary>
        public static readonly int FileUpLoadTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FileUpLoadTimeout"]);
    }
}
