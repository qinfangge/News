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
namespace CMS.Web.Admin.SinglePage
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="标题不能为空！\\n"; 
			}

            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;
            if (currentCategory.SelectedValue == "0")
            {
                strErr += "请选择栏目！\\n";
            }

			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			
			
			if(!PageValidate.IsNumber(txtsort.Text))
			{
				strErr+="排序格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
            int category = int.Parse(currentCategory.SelectedValue);
			string content=this.txtcontent.Text;
			string keywords=this.txtkeywords.Text;
			string description=this.txtdescription.Text;
            DateTime addTime = DateTime.Now;
			int userId=1;
			bool isDel=false;
			int hit=0;
			int sort=int.Parse(this.txtsort.Text);

			CMS.Model.SinglePage model=new CMS.Model.SinglePage();
			model.title=title;
            model.category = category;
			model.content=content;
			model.keywords=keywords;
			model.description=description;
			model.addTime=addTime;
			model.userId=userId;
			model.isDel=isDel;
			model.hit=hit;
			model.sort=sort;

			CMS.BLL.SinglePage bll=new CMS.BLL.SinglePage();
			bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
