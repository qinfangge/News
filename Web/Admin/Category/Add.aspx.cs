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
namespace CMS.Web.Admin.Category
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 初始化栏目
                CMS.BLL.Category bll = new CMS.BLL.Category();
                //★★与表的数据绑定★★
                txtcategory.DataSource = bll.GetCategoryForSelect(0);//设置数据源
                txtcategory.DataTextField = "name";//设置所要读取的数据表里的列名
                txtcategory.DataValueField = "id";
                txtcategory.DataBind();//数据绑定
                txtcategory.Items.Insert(0, new ListItem("顶级栏目", "0"));
                #endregion
            }
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="栏目名称不能为空！\\n";	
			}
			
			if(!PageValidate.IsNumber(txtsort.Text))
			{
				strErr+="序号格式错误！，请输入1，2，3...\\n";	
			}

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string name=this.txtname.Text;
            int pid = int.Parse(this.txtcategory.SelectedValue);
			int sort=int.Parse(this.txtsort.Text);
            string keywords = this.txtkeywords.Text;
            string description = this.txtdescription.Text;

			CMS.Model.Category model=new CMS.Model.Category();
			model.name=name;
			model.pid=pid;
			model.sort=sort;
            model.keywords = keywords;
            model.description = description;

			CMS.BLL.Category bll=new CMS.BLL.Category();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

       
    }
}
