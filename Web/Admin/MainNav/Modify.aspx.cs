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
namespace CMS.Web.MainNav
{
    public partial class Modify : Page
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
                    CMS.BLL.MainNav bll = new CMS.BLL.MainNav();
                    CMS.Model.MainNav model = bll.GetModel(id);
                    this.lblid.Text = model.id.ToString();
                    this.txtlink.Text = model.link;
                    this.txtname.Text = model.name;
                    this.chktarget.Checked = model.target;
                    this.txtsort.Text = model.sort.ToString();

                }

                public void btnSave_Click(object sender, EventArgs e)
                {

                    string strErr = "";
                    if (this.txtlink.Text.Trim().Length == 0)
                    {
                        strErr += "链接不能为空！\\n";
                    }
                    if (this.txtname.Text.Trim().Length == 0)
                    {
                        strErr += "名称不能为空！\\n";
                    }
                    if (!PageValidate.IsNumber(txtsort.Text))
                    {
                        strErr += "排序格式错误！\\n";
                    }
                    if (strErr != "")
                    {
                        MessageBox.Show(this, strErr);
                        return;
                    }
                    int id = int.Parse(this.lblid.Text);
                    string link = this.txtlink.Text;
                    string name = this.txtname.Text;
                    bool target = this.chktarget.Checked;
                    int sort = int.Parse(this.txtsort.Text);


                    CMS.Model.MainNav model = new CMS.Model.MainNav();
                    model.id = id;
                    model.link = link;
                    model.name = name;
                    model.target = target;
                    model.sort = sort;

                    CMS.BLL.MainNav bll = new CMS.BLL.MainNav();
                    bll.Update(model);
                    tk.tingyuxuan.utils.MessageBoxTip.AlertAndRedirect(this, "保存成功！", "list.aspx");

                }


                public void btnCancle_Click(object sender, EventArgs e)
                {
                    Response.Redirect("list.aspx");
                }
    }
}
