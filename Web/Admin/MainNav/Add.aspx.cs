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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
            string link = this.txtlink.Text;
            string name = this.txtname.Text;
            bool target = this.chktarget.Checked;
            int sort = int.Parse(this.txtsort.Text);

            CMS.Model.MainNav model = new CMS.Model.MainNav();
            model.link = link;
            model.name = name;
            model.target = target;
            model.sort = sort;

            CMS.BLL.MainNav bll = new CMS.BLL.MainNav();
            bll.Add(model);
         
            tk.tingyuxuan.utils.MessageBoxTip.AlertAndRedirect(this, "保存成功！", "add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
