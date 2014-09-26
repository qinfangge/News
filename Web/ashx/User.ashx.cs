using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.ashx
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            string action = context.Request["a"].ToString();
            switch (action)
            {
                case "in":
                    LoginIn(context);
                    break;
                case "out":
                    LoginOut(context);
                      break;
                default:
                    context.Response.Write("非法请求！");
                    break;
            }
        }

        protected void LoginIn(HttpContext context)
        {
            string userName = context.Request["userName"].ToString();
            string password = context.Request["password"].ToString();
            CMS.BLL.User bll = new BLL.User();
            string strWhere = string.Format("userName='{0}' and password='{1}'", userName, password);
           // string strWhere = "id=11";
            List<CMS.Model.User> list = bll.GetModelList(strWhere);
            if (list.Count > 0)
            {
                CMS.Model.User user = list[0];
                context.Session["user"] = user;
                context.Response.Write(1);
            }
            else
            {
                context.Response.Write(0);
            }

        }


        protected void LoginOut(HttpContext context)
        {
            context.Session.Abandon();
            context.Response.Write(1);

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