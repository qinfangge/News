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
namespace CMS.Web.Admin.GuestBook
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
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="姓名不能为空！\\n";	
			}
			if(this.txtmobile.Text.Trim().Length==0)
			{
				strErr+="电话不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
            if (txtaddTime.Text.Trim() != "")
            {
                if (!PageValidate.IsDateTime(txtaddTime.Text))
                {
                    strErr += "添加时间格式错误！\\n";
                }
            }

			
			if(!PageValidate.IsDateTime(txtreplyTime.Text))
			{
				strErr+="回复时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string name=this.txtname.Text;
			string mobile=this.txtmobile.Text;
			string content=this.txtcontent.Text;
            DateTime addTime = DateTime.Now;
            if (txtaddTime.Text.Trim() != "")
            {
                addTime = DateTime.Parse(this.txtaddTime.Text);
            }

			string reply=this.txtreply.Text;
			DateTime replyTime=DateTime.Parse(this.txtreplyTime.Text);
			bool isChecked=this.chkisChecked.Checked;

			CMS.Model.GuestBook model=new CMS.Model.GuestBook();
			model.title=title;
			model.name=name;
			model.mobile=mobile;
			model.content=content;

			model.addTime=addTime;
			model.reply=reply;
			model.replyTime=replyTime;
			model.isChecked=isChecked;

			CMS.BLL.GuestBook bll=new CMS.BLL.GuestBook();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
