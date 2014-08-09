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
namespace CMS.Web.Admin.FriendLink
{
    public partial class Modify : CommonPage
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
		CMS.BLL.FriendLink bll=new CMS.BLL.FriendLink();
		CMS.Model.FriendLink model=bll.GetModel(id);
        if (model == null)
        {
            Response.Write("找不到此信息");
            Response.End();
        }
		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		this.txturl.Text=model.url;
        this.txtsort.Text = model.sort.ToString();
        if (model.image != "")
        {
            Panel1.Visible = true;

            HyperLink1.ImageUrl = "/" + model.image;
            HyperLink1.NavigateUrl = model.url;

        }

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txturl.Text.Trim().Length==0)
			{
				strErr+="url不能为空！\\n";	
			}
            if (!PageValidate.IsNumber(txtsort.Text))
            {
                strErr += "排序必须为数字！\\n";
            }

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
            CMS.BLL.FriendLink bll = new CMS.BLL.FriendLink();
            CMS.Model.FriendLink model = bll.GetModel(id);
			string name=this.txtname.Text;
			string url=this.txturl.Text;
            int sort = int.Parse(this.txtsort.Text.Trim());
            string image = model.image;
            if (FileUpload1.HasFile)
            {
                string uploadPath = "Upload";
                MyUpload upload = new MyUpload(FileUpload1.PostedFile, uploadPath);
                upload.UploadFile();
                image = upload.FilePath;

            }

			
			
			model.name=name;
			model.url=url;
			model.image=image;
            model.sort = sort;

			
			bll.Update(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","List.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
