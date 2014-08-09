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
namespace CMS.Web.Admin.NodeGroup
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
				strErr+="组不能为空！\\n";	
			}

            int sort = 0;
            if (this.Sort.Text.Trim().Length != 0)
            {

                if (!int.TryParse(this.Sort.Text.Trim(), out sort))
                {
                    strErr += "排序必须为数值！\\n";
                }
            }
			

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
            string roleName = this.RoleName.Text.Trim();
			CMS.Model.NodeGroup model=new CMS.Model.NodeGroup();
			model.name=roleName;
            model.sort = sort;

			CMS.BLL.NodeGroup bll=new CMS.BLL.NodeGroup();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
