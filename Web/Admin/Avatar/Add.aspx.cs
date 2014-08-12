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
namespace CMS.Web.Avatar
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtpicPath.Text.Trim().Length==0)
			{
				strErr+="头像不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaddTime.Text))
			{
				strErr+="添加时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserID.Text))
			{
				strErr+="userID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string picPath=this.txtpicPath.Text;
			DateTime addTime=DateTime.Parse(this.txtaddTime.Text);
			int userID=int.Parse(this.txtuserID.Text);

			CMS.Model.Avatar model=new CMS.Model.Avatar();
			model.picPath=picPath;
			model.addTime=addTime;
			model.userID=userID;

			CMS.BLL.Avatar bll=new CMS.BLL.Avatar();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
