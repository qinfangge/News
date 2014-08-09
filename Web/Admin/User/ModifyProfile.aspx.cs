using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
using CMS.Web.Admin;
using tk.tingyuxuan.utils;
namespace CMS.Web.Admin.User
{
    public partial class ModifyProfile : CommonPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        private void ShowInfo()
        {

            CMS.Model.User model = Session["user"] as CMS.Model.User;
            this.txtuserName.Text = model.userName;
            this.txtpassword.Text = model.password;
            this.txtemail.Text = model.email;
            this.txtrealName.Text = model.realName;
            this.txtphone.Text = model.phone;

        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtuserName.Text.Trim().Length == 0)
            {
                strErr += "用户名不能为空！\\n";
            }



            if (this.txtrealName.Text.Trim().Length == 0)
            {
                strErr += "联系人不能为空！！\\n";
            }
            if (this.txtphone.Text.Trim().Length == 0)
            {
                strErr += "联系电话不能为空！\\n";
            }


            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            CMS.Model.User model = Session["user"] as CMS.Model.User;
            string userName = this.txtuserName.Text;
            string password = model.password;
            if (!string.IsNullOrEmpty(this.txtpassword.Text.Trim()))
            {
                password = this.txtpassword.Text;
            }

            string email = this.txtemail.Text;


            string realName = this.txtrealName.Text;
            string phone = this.txtphone.Text;


            CMS.BLL.User bll = new CMS.BLL.User();
            model.userName = userName;
            model.password = password;
            model.email = email;
            model.realName = realName;
            model.phone = phone;
            bll.Update(model);
            MessageBoxTip.Alert(this, "保存成功");
           // MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
