using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CMS.Web.Admin
{
    public partial class CommonPage : System.Web.UI.Page
    {
        public CommonPage()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.Load += new EventHandler(CommonPage_Load);



        }
        void CommonPage_Load(object sender, EventArgs e)
        {

            //if (Session["user"] == null)
            //{
            //    Response.Redirect("/Login.aspx");
            //}
        }
        #region 查看当前用户是否是管理组(编辑，管理员..)
        protected bool isManageGroup()
        {
            CMS.Model.User user = Session["user"] as CMS.Model.User;
            string currentRole = user.type.ToString();
            string[] rolesArray = { };
            if (Cache["管理组"] == null)
            {
                XmlDocument xDoc = new XmlDocument();
                string file = "~/App_Data/UserType.xml";
                xDoc.Load(Server.MapPath(file));
                XmlNodeList xNodeList = xDoc.GetElementsByTagName("role");
                string roles = "";
                roles = xNodeList[0].ChildNodes[1].InnerText;
                rolesArray = roles.Split(new char[] { ',' });
                CacheDependency dp = new CacheDependency(Server.MapPath(file));//建立缓存依赖项dp

                Cache.Insert("管理组", rolesArray, dp, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);
            }
            int position = Array.IndexOf(Cache["管理组"] as string[], currentRole);

            return position != -1;


        }

        #endregion


    }
}