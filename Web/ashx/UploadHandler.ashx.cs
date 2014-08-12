using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CMS.Web.ashx
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["a"];
            switch (action)
            {
                case "add":
                    Upload(context);
                    break;
                case "del":
                    // DelateAttachment(context);
                    break;
                default:
                    context.Response.Write("找不到要执行的方法");
                    break;
            }

        }

        private void Upload(HttpContext context)
        {
            //接收上传后的文件
            HttpPostedFile file = context.Request.Files["Filedata"];
            //其他参数
            //string somekey = context.Request["someKey"];
            //string other = context.Request["someOtherKey"];
            //获取文件的保存路径
            string path = "/Upload/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string uploadPath =
                HttpContext.Current.Server.MapPath(path);
            //判断上传的文件是否为空


            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                //保存文件
                string ext = Path.GetExtension(file.FileName);
                string fileName = System.Guid.NewGuid() + ext;
                string filePath = path + fileName;

                file.SaveAs(uploadPath + fileName);

                //如果上传成功就将文件记录到表中
                CMS.BLL.Avatar bll = new CMS.BLL.Avatar();


                CMS.Model.Avatar oldModel = bll.GetModel(2);

                int currentID = 0;
                if (oldModel != null)
                {
                    File.Delete(context.Server.MapPath(oldModel.picPath));
                    oldModel.picPath = filePath;
                    oldModel.addTime = DateTime.Now;
                    bll.Update(oldModel);
                    currentID = oldModel.id;
                }
                else
                {

                    CMS.Model.Avatar model = new CMS.Model.Avatar();
                    model.picPath = filePath;
                    model.addTime = DateTime.Now;
                    //CMS.Model.User user = context.Session["user"] as CMS.Model.User;
                    model.userID = 1;// user.id;
                    currentID = bll.Add(model);
                }
                context.Response.Write(currentID);
            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}