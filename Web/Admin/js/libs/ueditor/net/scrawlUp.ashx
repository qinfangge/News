<%@ WebHandler Language="C#" Class="scrawlImgUp" %>

using System;
using System.Web;
using System.IO;
using System.Collections;

public class scrawlImgUp : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string action = context.Request["action"];

        if (action == "tmpImg")
        {
            //上传配置
            string pathbase = "tmp";                                                          //保存路径
            int size = 2;                     //文件大小限制,单位mb                                                                                   //文件大小限制，单位KB
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };                    //文件允许格式

            //上传图片
            Hashtable info = new Hashtable();
            Uploader up = new Uploader();
            info = up.upFile(context, pathbase, filetype, size); //获取上传状态

            HttpContext.Current.Response.Write("<script>parent.ue_callback('" + info["url"] + "','" + info["state"] + "')</script>");//回调函数
        }
        else
        {
            string pathbase = "upload";                                        //保存路径
            string tmpPath = "tmp";               //临时图片目录       

            //上传图片
            Hashtable info = new Hashtable();
            Uploader up = new Uploader();
            info = up.upScrawl(context, pathbase, tmpPath, context.Request["content"]); //获取上传状态

            //如果上传成功就将文件记录到表中
            CMS.Model.Attachment model = new CMS.Model.Attachment();
            model.path = "/" + info["url"].ToString();
            model.title = "";
            model.addTime = DateTime.Now;
            model.fileName = "";
            model.size = decimal.Parse(info["fileSize"].ToString());
            model.ext = info["fileExt"].ToString();
            CMS.Model.User user = context.Session["user"] as CMS.Model.User;
            model.userId = user.id;
            CMS.BLL.Attachment bll = new CMS.BLL.Attachment();
            int currentID = bll.Add(model);
            if (currentID > 0)
            {
                string rewriteUrl = tk.tingyuxuan.utils.ImageUtils.GetThumbImagePath(currentID.ToString(), 0, 0, 1);

                info["url"] = rewriteUrl;
            }
            
            //向浏览器返回json数据
            HttpContext.Current.Response.Write("{'url':'" + info["url"] + "',state:'" + info["state"] + "'}");
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