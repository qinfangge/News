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
namespace CMS.Web.Admin.Node
{
    public partial class Modify : CommonPage
    {

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

       

        private void ShowInfo(int id)
        {
            CMS.BLL.Node bll = new CMS.BLL.Node();
            CMS.Model.Node model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            this.lblid.Text = model.id.ToString();

            #region 初始化权限组
            CMS.BLL.NodeGroup groupBLL = new CMS.BLL.NodeGroup();
            //★★与表的数据绑定★★
            Group.DataSource = groupBLL.GetAllList();//设置数据源
            Group.DataTextField = "name";//设置所要读取的数据表里的列名
            Group.DataValueField = "id";
            Group.DataBind();//数据绑定
            #endregion
            this.Name.Text = model.name;
            this.URL.Text = model.url;
            this.IsMenu.Checked = model.isMenu;
            this.Sort.Text = model.sort.ToString();
            this.MenuName.Text = model.menuName;
            ListItem item = Group.Items.FindByValue(model.groupId.ToString());
            if (item != null)
            {
                item.Selected = true;
            }


        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            
            int id = int.Parse(this.lblid.Text);
            string strErr = "";
            if (this.Name.Text.Trim().Length == 0)
            {
                strErr += "组名不能为空！\\n";
            }
            if (this.URL.Text.Trim().Length == 0)
            {
                strErr += "地址不能为空！\\n";
            }

            if (this.Group.SelectedValue == "0")
            {
                strErr += "请选择权限组！\\n";
            }
            int sort=0;

            if (!int.TryParse(this.Sort.Text.Trim(),out sort))
            {
                strErr += "排序必须是数值！\\n";
            }


            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }

            string name = this.Name.Text;
            string url = this.URL.Text;
            int group = int.Parse(this.Group.SelectedValue);
           
            bool isMenu = this.IsMenu.Checked;
            string menuName = this.MenuName.Text;


            CMS.Model.Node model = new CMS.Model.Node();
            model.id = id;
            model.name = name;
            model.url = url;
            model.isMenu = isMenu;
            model.menuName = menuName;
            model.groupId = group;
            model.sort = sort;

            CMS.BLL.Node bll = new CMS.BLL.Node();
          
            bll.Update(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
