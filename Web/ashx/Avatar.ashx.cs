using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Xml;
using CMS.BLL;
using tk.tingyuxuan.utils;
namespace CMS.Web.ashx
{
    /// <summary>
    /// Image 的摘要说明
    /// </summary>
    public class AvatarHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetValidUntilExpires(true);
            string para = context.Request["p"];

            string p = System.Text.Encoding.Default.GetString(Convert.FromBase64String(para.Replace("%2B", "+")));

            string[] paraArray = p.Split(new string[] { "|" }, StringSplitOptions.None);

            int id = 0;
            string noPicPath = "/App_Data/noPic.jpg";
            int width = 100;
            int height = 100;
            string path = "";
            try
            {
                width = int.Parse(paraArray[0]);
                height = int.Parse(paraArray[1]);
                id = int.Parse(paraArray[2]);
                CMS.BLL.Avatar bll = new CMS.BLL.Avatar();
                CMS.Model.Avatar model = bll.GetModel(id);
                path = model.picPath;

            }
            catch (Exception ex)
            {
                path = noPicPath;
            }
            string realPath = "";
            if (path.IndexOf("http://") < 0)
            {
                realPath = context.Server.MapPath(path);
            }
            else
            {
                realPath = path;
            }

            Image newImage = ImageUtils.GetThumbNailImage(realPath, width, height);

            //bool isWaterImage = false;
            //XmlDocument doc = new XmlDocument();
            //string configPath = context.Server.MapPath("~/App_Data/config.xml");
            //doc.Load(configPath);    //加载Xml文件  
            //string isWaterNode = doc.SelectSingleNode("/config/waterImage/isWater").InnerText;
            //if (isWaterNode == "true")
            //{
            //    isWaterImage = true;
            //}
            //if (isWaterImage&&width==0&&height==0)
            //{
            //    string waterPath="/App_Data/water.png";
            //    Image waterImage = Image.FromFile(context.Server.MapPath(waterPath));
            //    newImage=ImageUtils.CreateImageWaterMark(newImage, waterImage);
            //}


            if (newImage == null)
            {
               
                realPath = context.Server.MapPath(noPicPath);

                newImage = ImageUtils.GetThumbNailImage(realPath, width, height);
            }


            newImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            newImage.Dispose();

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