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
namespace CMS.Web.Admin.Investment
{
    public partial class Modify : CommonPage
    {
        protected string CurrentCategory { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int id = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(id);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // your codes.
            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;

            ListItem item = currentCategory.Items.FindByValue(CurrentCategory);
            if (item != null)
            {
                item.Selected = true;
            }

        }


        private void ShowInfo(int id)
        {
            CMS.BLL.Investment bll = new CMS.BLL.Investment();
            CMS.Model.Investment model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            this.lblid.Text = model.id.ToString();
            this.txttitle.Text = model.title;
            this.txtname.Text = model.name;
            this.txtmobile.Text = model.mobile;
            this.txtcontent.Text = model.content;
            this.txtaddTime.Text = model.addTime.Value.ToString("yyyy-MM-dd H:m:s");
            CurrentCategory = model.category.ToString();
            this.txttype.Text = model.type.ToString();
            this.chkisChecked.Checked = model.isChecked;

        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.txtname.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！\\n";
            }
            if (this.txtmobile.Text.Trim().Length == 0)
            {
                strErr += "电话不能为空！\\n";
            }
            if (this.txtcontent.Text.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }
            if (txtaddTime.Text.Trim() == "")
            {
                strErr += "添加时间不能为空！\\n";
            }

            if (!PageValidate.IsDateTime(txtaddTime.Text))
            {
                strErr += "添加时间格式错误！\\n";
            }

            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;

            if (currentCategory.SelectedValue == "0")
            {
                strErr += "请选择栏目！\\n";
            }
           

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            int id = int.Parse(this.lblid.Text);
            string title = this.txttitle.Text;
            string name = this.txtname.Text;
            string mobile = this.txtmobile.Text;
            string content = this.txtcontent.Text;
            DateTime addTime = DateTime.Parse(this.txtaddTime.Text);
            //int category=int.Parse(this.txtcategory.Text);
            int category = int.Parse(currentCategory.SelectedValue);
            int type = int.Parse(this.txttype.Text);
            bool isChecked = this.chkisChecked.Checked;


            CMS.Model.Investment model = new CMS.Model.Investment();
            model.id = id;
            model.title = title;
            model.name = name;
            model.mobile = mobile;
            model.content = content;
            model.addTime = addTime;
            model.category = category;
            model.type = type;
            model.isChecked = isChecked;

            CMS.BLL.Investment bll = new CMS.BLL.Investment();
            bll.Update(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
