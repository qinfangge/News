using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.ashx
{
    /// <summary>
    /// Comment 的摘要说明
    /// </summary>
    public class Comment : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"].ToString();
            if (type == "1")
            {
                Reply(context);
            }

            if (type == "2")
            {
                Dig(context);
            }
        }
        /// <summary>
        /// 顶
        /// </summary>
        protected void Dig(HttpContext context)
        {
            CMS.Model.Comment model = new Model.Comment();
            CMS.BLL.Comment bll = new BLL.Comment();
            int id = int.Parse(context.Request["id"].ToString());
            model = bll.GetModel(id);
            if (model != null)
            {
                model.dig += 1;
                if (bll.Update(model))
                {
                    context.Response.Write(1);
                }
                else
                {
                
                    context.Response.Write(0);
                }
            }
        }

        /// <summary>
        /// 回复
        /// </summary>
        protected void Reply(HttpContext context)
        {
           

            try
            {
                CMS.Model.Comment model = new Model.Comment();
                int newsId = int.Parse(context.Request["newsId"].ToString());
                string content = HttpUtility.HtmlEncode(context.Request["content"].ToString());
                int pid = int.Parse(context.Request["pid"].ToString());
                model.newsId = newsId;
                model.content = content;
                model.addTime = DateTime.Now;
                CMS.Model.User user= context.Session["user"] as CMS.Model.User;
                model.userId = user.id ;
                model.ip = GetLoginIp(context.Request);
                model.isCheck = false;
                model.Pid = pid;
                model.dig = 0;
                CMS.BLL.Comment bll = new BLL.Comment();
                if (bll.Add(model) > 0)
                {
                    context.Response.Write(1);
                }
                else
                {
                    context.Response.Write(0);
                }

            }
            catch (Exception ex)
            {

                context.Response.Write(ex.Message);
              
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