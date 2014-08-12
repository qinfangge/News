using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.ashx
{
    /// <summary>
    /// Comment 的摘要说明
    /// </summary>
    public class Comment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            CMS.Model.Comment model = new Model.Comment();
            model.newsId = 72;
            model.content = "汪小菲装逼结果碰到王思聪";
            model.addTime = DateTime.Now;
            model.userId = 1;
            model.ip = GetLoginIp(context.Request);
            model.isCheck = false;
            model.Pid = 0;
            model.dig = 10;
            CMS.BLL.Comment bll = new BLL.Comment();
            if (bll.Add(model)>0)
            {
                context.Response.Write(1);
            }
            else
            {
                context.Response.Write(0);
            }
        }

        /// <summary>
        /// 获取远程访问用户的Ip地址
        /// </summary>
        /// <returns>返回Ip地址</returns>
        protected string GetLoginIp(HttpRequest Request)
        {
            string loginip = "";
            //Request.ServerVariables[""]--获取服务变量集合 
            if (Request.ServerVariables["REMOTE_ADDR"] != null) //判断发出请求的远程主机的ip地址是否为空
            {
                //获取发出请求的远程主机的Ip地址
                loginip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            //判断登记用户是否使用设置代理
            else if (Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    //获取代理的服务器Ip地址
                    loginip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    //获取客户端IP
                    loginip = Request.UserHostAddress;
                }
            }
            else
            {
                //获取客户端IP
                loginip = Request.UserHostAddress;
            }
            return loginip;
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