using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace tk.tingyuxuan.utils
{
    public class MyUpload
    {
        private string fileType;
        private string pictureType;
        private int fileSizeLimit;
        private HttpPostedFile fileUp;
        private string uploadPath;
        public string FilePath { set; get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUp">上传的文件</param>
        /// <param name="uploadPath">文件上传所在的路径</param>
        public MyUpload(HttpPostedFile fileUp,string uploadPath="upload")
        {
            this.fileType = ".doc,.xls,.txt,.rar";
            this.pictureType = ".jpg|.gif|.png|.bmp|.psd|.svg|";
            this.fileSizeLimit = 1024000;
            this.fileUp = fileUp;
            this.uploadPath = uploadPath;
        }
       /// <summary>
       /// 
       /// </summary>
        /// <param name="fileUp">上传的文件</param>
       /// <param name="fileType">允许上传文件的类型</param>
        /// <param name="pictureType">允许上传图片的类型</param>
        /// <param name="fileSizeLimit">允许上传文件的大小，默认是1024K</param>
        public MyUpload(HttpPostedFile fileUp, string fileType, string pictureType,string uploadPath = "upload",int fileSizeLimit = 12040)
        {
            this.fileType = fileType;
            this.pictureType = pictureType;
            this.fileSizeLimit = fileSizeLimit;
        }
        //允许上传的文件类型
        protected bool IsAllowableFileType()
        {

            if (fileType.IndexOf(Path.GetExtension(fileUp.FileName).ToLower()) != -1)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 判断图片类型限制
        /// </summary>
        /// <returns></returns>
        protected bool IsAllowablePictureType()
        {

            if (pictureType.IndexOf(Path.GetExtension(fileUp.FileName).ToLower()) != -1)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 判断文件类型限制
        /// </summary>
        /// <returns></returns>
        private bool IsAllowableFileSize()
        {

            if (fileSizeLimit > fileUp.ContentLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据当前日期生成文件夹
        /// </summary>
        /// <param name="parentDirectory">文件上传的根路径,默认是upload</param>
        /// <returns>返回文件夹的路径</returns>
        public static string CreateDirectoryByDate(string parentDirectory="upload")
        {
            string uploadPath= parentDirectory +"/"+ DateTime.Now.ToString("yyyyMMdd");
            string absoluteUploadPath = "~/" + uploadPath;
            if (Directory.Exists(HttpContext.Current.Server.MapPath(absoluteUploadPath)) == false)//判断文件夹是否存在,若不存在则创建
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(absoluteUploadPath));
            }


            return uploadPath;
        }
        /// <summary>
        /// 根据日期 时间 秒 生成新的文件名
        /// </summary>
        /// <param name="oldName">旧文件名</param>
        /// <returns></returns>
        public static string ReNameFile(string oldName)
        {
            return DateTime.Now.ToString("HHmmssffffff ") + "_" + new Random().Next(1000).ToString() + oldName.Substring(oldName.LastIndexOf("."));
        }
        /// <summary>
        /// 获取文件上传后的新路径
        /// </summary>
        /// <param name="parentDirectory">上传文件所在的目录</param>
        /// <param name="oldName">上传前的文件名</param>
        /// <returns></returns>
        public static string GetFilePath(string oldName,string parentDirectory="upload" )
        {
            return CreateDirectoryByDate(parentDirectory) + "/" + ReNameFile(oldName);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="isPicture">默认是上传图片类型</param>
        public void UploadFile(bool isPicture=true)
        {
            
            if (fileUp.ContentLength > 0)
            {
                if (isPicture ? IsAllowablePictureType(): IsAllowableFileType())
                {
                    
                        
                   
                        if (IsAllowableFileSize())
                        {
                           // uploadPath = GetFilePath(fileUp.FileName，uploadPath);
                            FilePath=uploadPath = GetFilePath(fileUp.FileName, uploadPath);
                           uploadPath=HttpContext.Current.Server.MapPath("~/" + uploadPath);
                           fileUp.SaveAs(uploadPath);
                        }
                        else
                            throw new Exception("文件太大了");
                }
                else
                    throw new Exception("文件类型不正确");
            }
            else
            {
                throw new Exception("上传文件不能空");
            }
        }
        
    }
}
