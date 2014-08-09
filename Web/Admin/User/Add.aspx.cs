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
using UserGroup=CMS.Model.UserGroup;
namespace CMS.Web.Admin.User
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserType();
            }

        }

        public void  BindUserType()
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

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuserName.Text.Trim().Length==0)
			{
				strErr+="用户名不能为空！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="密码不能为空！\\n";	
			}
			
			if(this.txtrealName.Text.Trim().Length==0)
			{
				strErr+="联系人不能为空！\\n";	
			}
			if(this.txtphone.Text.Trim().Length==0)
			{
				strErr+="联系电话不能为空！\\n";	
			}
			

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string userName=this.txtuserName.Text;
			string password=this.txtpassword.Text;
			string email=this.txtemail.Text;
			DateTime addTime=DateTime.Now;
			bool isActive=this.chkisActive.Checked;
			string realName=this.txtrealName.Text;
			string phone=this.txtphone.Text;
			int type=int.Parse(this.txttype.SelectedValue);

			CMS.Model.User model=new CMS.Model.User();
			model.userName=userName;
			model.password=password;
			model.email=email;
			model.addTime=addTime;
			model.isActive=isActive;
			model.realName=realName;
			model.phone=phone;
			model.type=type;

			CMS.BLL.User bll=new CMS.BLL.User();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
