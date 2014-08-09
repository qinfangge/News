using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using tk.tingyuxuan.utils;

namespace CMS.Web
{
    public partial class Investment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string vCode = VCode.Text.Trim();
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
            
            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;
            if (currentCategory.SelectedValue == "0")
            {
                strErr += "请选择栏目！\\n";
            }
            if (Session["vcode"] == null)
            {
                strErr += "验证码已经过期！\\n";
            }
            else
            {
                if (vCode != Session["vcode"].ToString())
                {
                    strErr += "验证码错误！\\n";
                }
            }

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            string title = this.txttitle.Text;
            string name = this.txtname.Text;
            string mobile = this.txtmobile.Text;
            string content = this.txtcontent.Text;
            DateTime addTime = DateTime.Now;
            
            int category = int.Parse(currentCategory.SelectedValue);
            int type = int.Parse(this.txttype.Text);
            bool isChecked = false;

            CMS.Model.Investment model = new CMS.Model.Investment();
            model.title = title;
            model.name = name;
            model.mobile = mobile;
            model.content = content;
            model.addTime = addTime;
            model.category = category;
            model.type = type;
            model.isChecked = isChecked;

            CMS.BLL.Investment bll = new CMS.BLL.Investment();
            bll.Add(model);
            MessageBoxTip.Alert(this, "提交成功,我们将及时与您取得联系！");

        }



    }
}