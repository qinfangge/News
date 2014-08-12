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
namespace CMS.Web.Comment
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		CMS.BLL.Comment bll=new CMS.BLL.Comment();
		CMS.Model.Comment model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtcontent.Text=model.content;
		this.txtaddTime.Text=model.addTime.ToString();
		this.txtip.Text=model.ip;
		this.txtnewsId.Text=model.newsId.ToString();
		this.txtdig.Text=model.dig.ToString();
		this.txtPid.Text=model.Pid.ToString();
		this.chkisCheck.Checked=model.isCheck;
		this.txtuserId.Text=model.userId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="评论不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaddTime.Text))
			{
				strErr+="评论时间格式错误！\\n";	
			}
			if(this.txtip.Text.Trim().Length==0)
			{
				strErr+="ip不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtnewsId.Text))
			{
				strErr+="newsId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdig.Text))
			{
				strErr+="dig格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPid.Text))
			{
				strErr+="Pid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserId.Text))
			{
				strErr+="userId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string content=this.txtcontent.Text;
			DateTime addTime=DateTime.Parse(this.txtaddTime.Text);
			string ip=this.txtip.Text;
			int newsId=int.Parse(this.txtnewsId.Text);
			int dig=int.Parse(this.txtdig.Text);
			int Pid=int.Parse(this.txtPid.Text);
			bool isCheck=this.chkisCheck.Checked;
			int userId=int.Parse(this.txtuserId.Text);


			CMS.Model.Comment model=new CMS.Model.Comment();
			model.id=id;
			model.content=content;
			model.addTime=addTime;
			model.ip=ip;
			model.newsId=newsId;
			model.dig=dig;
			model.Pid=Pid;
			model.isCheck=isCheck;
			model.userId=userId;

			CMS.BLL.Comment bll=new CMS.BLL.Comment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
