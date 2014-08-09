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
			if(!PageValidate.IsNumber(txtid.Text))
			{
				strErr+="id格式错误！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtstyle.Text.Trim().Length==0)
			{
				strErr+="style不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			int id=int.Parse(this.txtid.Text);
			string name=this.txtname.Text;
			string style=this.txtstyle.Text;

			CMS.Model.Attribute model=new CMS.Model.Attribute();
			model.id=id;
			model.name=name;
			model.style=style;

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
