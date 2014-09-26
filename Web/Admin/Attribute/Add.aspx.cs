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
namespace CMS.Web.Admin.Attribute
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
            if (this.txtname.Text.Trim().Length == 0)
            {
                strErr += "属性名称不能为空！\\n";
            }
            if (this.txtcssClass.Text.Trim().Length == 0)
            {
                strErr += "css类名不能为空！\\n";
            }

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
                    
			
			string name=this.txtname.Text;
            string style = this.txtcssClass.Text;

			CMS.Model.Attribute model=new CMS.Model.Attribute();
			
			model.name=name;
			model.cssClass=style;

			CMS.BLL.Attribute bll=new CMS.BLL.Attribute();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
