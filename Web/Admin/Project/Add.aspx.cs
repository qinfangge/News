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
namespace CMS.Web.Admin.Project
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtnumber.Text.Trim().Length == 0)
            {
                strErr += "项目编号不能为空！\\n";
            }
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.txtprice.Text.Trim().Length == 0)
            {
                strErr += "挂牌价格不能为空！\\n";
            }
            if (!PageValidate.IsDateTime(txtstartTime.Text))
            {
                strErr += "挂牌日期格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtendTime.Text))
            {
                strErr += "截止日期格式错误！\\n";
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

          

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            string number = this.txtnumber.Text;
            string title = this.txttitle.Text;
            string price = this.txtprice.Text;
            string source = this.Source.Text;
            bool isMemeber = IsMember.Checked;
            DateTime startTime = DateTime.Parse(this.txtstartTime.Text);
            DateTime endTime = DateTime.Parse(this.txtendTime.Text);
            string content = this.txtcontent.Text;
            string titleImage = titleImage = HtmlHelper.GetAllImgUrl(content, true);
            string keywords = this.txtkeywords.Text;
            string description = this.txtdescription.Text;
            DateTime addTime = DateTime.Now;

            int category = int.Parse(currentCategory.SelectedValue);
            int recommend = int.Parse(this.txtrecommend.SelectedValue);
            CMS.Model.User user = Session["user"] as CMS.Model.User;
            int userId = user.id;
            bool isDel = false;
            int hit = 0;
            bool isSwitch = IsSwitch.Checked;


            CMS.Model.Project model = new CMS.Model.Project();
            model.number = number;
            model.title = title;
            model.price = price;
            model.startTime = startTime;
            model.endTime = endTime;
            model.titleImage = titleImage;
            model.content = content;
            model.keywords = keywords;
            model.description = description;
            model.addTime = addTime;
            model.category = category;
            model.recommend = recommend;
            model.userId = userId;
            model.isDel = isDel;
            model.hit = hit;
            model.isSwitch = isSwitch;
            model.isMember = isMemeber;
            model.source = source;
            CMS.BLL.Project bll = new CMS.BLL.Project();
            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "Add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
