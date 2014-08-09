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
            CMS.BLL.Project bll = new CMS.BLL.Project();
            CMS.Model.Project model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            CMS.Model.User user = ((MasterPage)this.Master).user;
            if (!isManageGroup())
            {
                if (model.userId != user.id)
                {
                    Response.Write("你无权修改此信息！");
                    Response.End();

                }
            }

            this.lblid.Text = model.id.ToString();
            this.txtnumber.Text = model.number;
            this.Source.Text = model.source;
            this.IsMember.Checked = model.isMember;
            this.txttitle.Text = model.title;
            this.txtprice.Text = model.price;
            this.txtstartTime.Text = model.addTime.ToString("yyyy-MM-dd");
            this.txtendTime.Text = model.endTime.Value.ToString("yyyy-MM-dd");

            this.txtcontent.Text = model.content;
            this.txtkeywords.Text = model.keywords;
            this.txtdescription.Text = model.description;
            this.txtaddTime.Text = model.addTime.ToString("yyyy-MM-dd H:m:s");
            CurrentCategory = model.category.ToString();

            ListItem recommendItem = txtrecommend.Items.FindByValue(model.recommend.ToString());
            if (recommendItem != null)
            {
                recommendItem.Selected = true;
            }

            IsSwitch.Checked = model.isSwitch;



        }

        public void btnSave_Click(object sender, EventArgs e)
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
            int id = int.Parse(this.lblid.Text);
            string source = this.Source.Text;
            bool isMemeber = IsMember.Checked;
            string number = this.txtnumber.Text;
            string title = this.txttitle.Text;
            string price = this.txtprice.Text;
            DateTime startTime = DateTime.Parse(this.txtstartTime.Text);
            DateTime endTime = DateTime.Parse(this.txtendTime.Text);

            string content = this.txtcontent.Text;
            string titleImage = HtmlHelper.GetAllImgUrl(content, true);
            
            string keywords = this.txtkeywords.Text;
            string description = this.txtdescription.Text;
            DateTime addTime = DateTime.Parse(this.txtaddTime.Text);


            int category = int.Parse(currentCategory.SelectedValue);
            int recommend = int.Parse(this.txtrecommend.SelectedValue);
            bool isSwitch = IsSwitch.Checked;




            CMS.BLL.Project bll = new CMS.BLL.Project();
            CMS.Model.Project model = bll.GetModel(id);
            model.id = id;
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
            model.isSwitch = isSwitch;
            model.isMember = isMemeber;
            model.source = source;

            bll.Update(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
