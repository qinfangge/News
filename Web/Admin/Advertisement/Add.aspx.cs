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
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtname.Text.Trim().Length == 0)
            {
                strErr += "广告名称不能为空！\\n";
            }
           
            if (this.txturl.Text.Trim().Length == 0)
            {
                strErr += "链接地址不能为空！\\n";
            }
            if (!PageValidate.IsDateTime(txtstartTime.Text))
            {
                strErr += "开始时间格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtendTime.Text))
            {
                strErr += "结束时间格式错误！\\n";
            }

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            string name = this.txtname.Text;
            string image = "";
            string url = this.txturl.Text;
            if (FileUpload1.HasFile)
            {
                string uploadPath = "Upload";
                MyUpload upload = new MyUpload(FileUpload1.PostedFile,uploadPath);
                upload.UploadFile();
                image = upload.FilePath;
            }



            DateTime startTime = DateTime.Parse(this.txtstartTime.Text);
            DateTime endTime = DateTime.Parse(this.txtendTime.Text);

            CMS.Model.Advertisement model = new CMS.Model.Advertisement();
            model.name = name;
            model.image = image;
            model.url = url;
            model.startTime = startTime;
            model.endTime = endTime;

            CMS.BLL.Advertisement bll = new CMS.BLL.Advertisement();
            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "Add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
