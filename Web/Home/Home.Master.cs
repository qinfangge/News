using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Home
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public string keywords{set;get;}
        public string CurrentLink { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                CMS.Model.User user=Session["user"] as CMS.Model.User;
                NoLogin.Visible = false;
                LoginName.Visible = true;
                LoginName.Text = "您好，"+user.userName;
                LoginName.NavigateUrl = "Admin/Index/Index.aspx";
            }

            if (!string.IsNullOrEmpty(Request["category"]))
            {
                CurrentLink = Request.Url.PathAndQuery;
            }



            InitAvatar();//头像设置
            InitMainNav();//导航
            InitContact();//网站尾部

           
        }

        #region
        private void InitAvatar()
        {
            int userID = 1;
            
            CMS.BLL.Avatar bll = new BLL.Avatar();
            string url = "";
            CMS.Model.Avatar model = bll.GetAvatarByUserID(userID);
            int width = 120;
            int height = 120;
            int id = 0;
            if (model != null)
            {
                id = model.id;

            }

            url = width + "|" + height + "|" + id;
            url = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(url)).Replace("+", "%2B");
            url = url + ".jpg";
            MyAvatar.ImageUrl = "/Avatar/" + url;

        }
        #endregion
        #region 初始化导航
        private void InitMainNav()
        {
            CMS.BLL.MainNav bll = new BLL.MainNav();
            DataSet ds = bll.GetList(20, "", "sort asc");
            MainNav.DataSource = ds;
            MainNav.DataBind();

        }
        #endregion


        #region 初始化尾部
        private void InitContact()
        {

            CMS.Web.Admin.Contact.Contact contact = new CMS.Web.Admin.Contact.Contact();
            CMS.Model.Contact siteContact = contact.ReadContact();

            Mobile.Text = siteContact.Phone;
            QQ.Text = siteContact.QQ;
            Zip.Text = siteContact.Zip;
            Address.Text = siteContact.Address;
            Contactor.Text = siteContact.Contactor;
            Fax.Text = siteContact.Fax;

            CMS.Web.Admin.Config.Config config = new CMS.Web.Admin.Config.Config();
            CMS.Model.Config SeoConfig = config.ReadConfig();
           
            Other.Text = SeoConfig.Other;

        }
        #endregion

    }
}