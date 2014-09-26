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
    public partial class Modify : CommonPage
    {       

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int id = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(id);
                }
			}
		}

        private void ShowInfo(int id)
        {
            CMS.BLL.Attribute bll = new CMS.BLL.Attribute();
            CMS.Model.Attribute model = bll.GetModel(id);
            this.lblid.Text = model.id.ToString();
            this.txtname.Text = model.name;
            this.txtcssClass.Text = model.cssClass;

        }
		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="属性名称不能为空！\\n";	
			}
            if (this.txtcssClass.Text.Trim().Length == 0)
			{
				strErr+="css类名不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
            string cssClass = this.txtcssClass.Text;
			CMS.Model.Attribute model=new CMS.Model.Attribute();
			model.id=id;
			model.name=name;
            model.cssClass = cssClass;

			CMS.BLL.Attribute bll=new CMS.BLL.Attribute();
			bll.Update(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","List.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
