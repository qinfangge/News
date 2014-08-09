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
namespace CMS.Web.Admin.NodeGroup
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
            CMS.BLL.NodeGroup bll = new CMS.BLL.NodeGroup();
            CMS.Model.NodeGroup model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            this.lblid.Text = model.id.ToString();
            this.RoleName.Text = model.name;
            this.Sort.Text = model.sort.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.RoleName.Text.Trim().Length == 0)
            {
                strErr += "角色不能为空！\\n";
            }
            int sort = 0;
            if (this.Sort.Text.Trim().Length != 0)
            {

                if (!int.TryParse(this.Sort.Text.Trim(), out sort))
                {
                    strErr += "排序必须为数值！\\n";
                }
            }
           
            
            

            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            int id = int.Parse(this.lblid.Text);
            CMS.BLL.NodeGroup bll = new CMS.BLL.NodeGroup();

            CMS.Model.NodeGroup model = bll.GetModel(id);
            
            string roleName = this.RoleName.Text.Trim();
            model.name = roleName;
            model.sort = sort;
            
            bll.Update(model);
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
