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
                strErr += "网站名称不能为空！\\n";
            }
            if (this.txturl.Text.Trim().Length == 0)
            {
                strErr += "链接地址不能为空！\\n";
            }

            if (!PageValidate.IsNumber(txtsort.Text))
            {
                strErr += "排序必须为数字！\\n";
            }



            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            string name = this.txtname.Text;
            string url = this.txturl.Text;
            string image = "";
            int sort = int.Parse(txtsort.Text.Trim());

            if (FileUpload1.HasFile)
            {
                string uploadPath = "Upload";
                MyUpload upload = new MyUpload(FileUpload1.PostedFile, uploadPath);
                upload.UploadFile();
                image = upload.FilePath;
            }


            CMS.Model.FriendLink model = new CMS.Model.FriendLink();
            model.name = name;
            model.url = url;
            model.image = image;
            model.sort = sort;

            CMS.BLL.FriendLink bll = new CMS.BLL.FriendLink();
            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "Add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
