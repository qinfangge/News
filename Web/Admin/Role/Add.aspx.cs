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
namespace CMS.Web.Admin.Role
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
            if (this.RoleName.Text.Trim().Length == 0)
			{
				strErr+="角色不能为空！\\n";	
			}
            int sort = 0;
            try
            {
                 sort = int.Parse(this.Sort.Text);
            }
            catch (Exception ex)
            {
                strErr += "请输入数字！\\n";	
            }
			
                    
			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
            string roleName = this.RoleName.Text.Trim();
			CMS.Model.Role model=new CMS.Model.Role();
			model.name=roleName;
            model.isShow=this.IsShow.Checked;
            model.isDefault = this.IsDefault.Checked;
            model.sort = sort;

			CMS.BLL.Role bll=new CMS.BLL.Role();

            if (model.isDefault)
            {
                bll.ResetDefault();
            }

            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "Add.aspx");
           

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
