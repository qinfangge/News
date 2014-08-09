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
using CMS.Web.Admin.Controls;
using CMS.Web.Admin;
namespace CMS.Web.Admin.News
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
			
			

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
            string source = this.txtsource.Text;
			string content=this.txtcontent.Text;
            string titleImage = titleImage = HtmlHelper.GetAllImgUrl(content, true);
			string keywords=this.txtkeywords.Text;
			string description=this.txtdescription.Text;
			DateTime addTime=DateTime.Now;
            int category = int.Parse(currentCategory.SelectedValue);
			int recommend=int.Parse(this.txtrecommend.SelectedValue);
            CMS.Model.User user = Session["user"] as CMS.Model.User;
            int userId = user.id;
			bool isDel=false;
			int hit=0;
            bool isSwitch = IsSwitch.Checked;

			CMS.Model.News model=new CMS.Model.News();
			model.title=title;
			model.source=source;
			model.titleImage=titleImage;
			model.content=content;
			model.keywords=keywords;
			model.description=description;
			model.addTime=addTime;
			model.category=category;
			model.recommend=recommend;
			model.userId=userId;
			model.isDel=isDel;
			model.hit=hit;
            model.isSwitch = isSwitch;

			CMS.BLL.News bll=new CMS.BLL.News();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
