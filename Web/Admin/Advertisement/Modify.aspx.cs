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
namespace CMS.Web.Admin.Advertisement
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
		CMS.BLL.Advertisement bll=new CMS.BLL.Advertisement();
		CMS.Model.Advertisement model=bll.GetModel(id);
        if (model == null)
        {
            Response.Write("找不到此信息");
            Response.End();
        }

		this.lblid.Text=model.id.ToString();
		this.txtname.Text=model.name;
		
		this.txturl.Text=model.url;
        this.txtstartTime.Text = model.startTime.Value.ToString("yyyy-MM-dd H:m:s");
        this.txtendTime.Text = model.endTime.Value.ToString("yyyy-MM-dd H:m:s");
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
                strErr += "广告名称不能为空！\\n";	
			}
			
			if(this.txturl.Text.Trim().Length==0)
			{
                strErr += "链接地址不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtstartTime.Text))
			{
                strErr += "开始时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtendTime.Text))
			{
                strErr += "结束时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string name=this.txtname.Text;
            CMS.BLL.Advertisement bll = new CMS.BLL.Advertisement();
           CMS.Model.Advertisement model= bll.GetModel(id);
             
            string image = model.image;
            string url = this.txturl.Text;
            if (FileUpload1.HasFile)
            {
                string uploadPath = "Upload";
                MyUpload upload = new MyUpload(FileUpload1.PostedFile, uploadPath);
                upload.UploadFile();
                image = upload.FilePath;

            }
			DateTime startTime=DateTime.Parse(this.txtstartTime.Text);
			DateTime endTime=DateTime.Parse(this.txtendTime.Text);
		
			model.name=name;
			model.image=image;
			model.url=url;
			model.startTime=startTime;
			model.endTime=endTime;
			
			bll.Update(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","List.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
