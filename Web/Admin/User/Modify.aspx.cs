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
using tk.tingyuxuan.utils;
using UserGroup = CMS.Model.UserGroup;
namespace CMS.Web.Admin.User
{
    public partial class Modify : CommonPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    BindUserType();
                    int id = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(id);
                }
            }
        }

        public void BindUserType()
        {
             #region 初始化用户角色
            CMS.BLL.Role groupBLL = new CMS.BLL.Role();
            //★★与表的数据绑定★★
            txttype.DataSource = groupBLL.GetAllList();//设置数据源
            txttype.DataTextField = "name";//设置所要读取的数据表里的列名
            txttype.DataValueField = "id";
            txttype.DataBind();//数据绑定
            #endregion
        }

        private void ShowInfo(int id)
        {
            CMS.BLL.User bll = new CMS.BLL.User();
            CMS.Model.User model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            this.lblid.Text = model.id.ToString();
            this.txtuserName.Text = model.userName;
            this.txtemail.Text = model.email;
            this.chkisActive.Checked = model.isActive;
            this.txtrealName.Text = model.realName;
            this.txtphone.Text = model.phone;
            ListItem item = txttype.Items.FindByValue(model.type.ToString());
            if (item != null)
            {
                item.Selected = true;
            }


        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtuserName.Text.Trim().Length == 0)
            {
                strErr += "用户名不能为空！\\n";
            }
            
            

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            int id = int.Parse(this.lblid.Text);
            CMS.BLL.User bll = new CMS.BLL.User();

            CMS.Model.User model = bll.GetModel(id);
            string password = model.password;
            if (this.txtpassword.Text.Trim().Length != 0)
            {

                password = this.txtpassword.Text;
            }

            string userName = this.txtuserName.Text;

            string email = this.txtemail.Text;

            bool isActive = this.chkisActive.Checked;
            string realName = this.txtrealName.Text;
            string phone = this.txtphone.Text;
            int type = int.Parse(this.txttype.SelectedValue);
            model.userName = userName;
            model.password = password;
            model.email = email;
            model.isActive = isActive;
            model.realName = realName;
            model.phone = phone;
            model.type = type;
            bll.Update(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
