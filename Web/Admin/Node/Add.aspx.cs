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
using UserGroup=CMS.Model.UserGroup;
namespace CMS.Web.Admin.Node
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 初始化权限组
                CMS.BLL.NodeGroup bll = new CMS.BLL.NodeGroup();
                //★★与表的数据绑定★★
                Group.DataSource = bll.GetAllList();//设置数据源
                Group.DataTextField = "name";//设置所要读取的数据表里的列名
                Group.DataValueField = "id";
                Group.DataBind();//数据绑定
                #endregion

            }

        }


      

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.Name.Text.Trim().Length==0)
			{
				strErr+="权限名不能为空！\\n";	
			}
			if(this.URL.Text.Trim().Length==0)
			{
				strErr+="地址不能为空！\\n";	
			}
			
			if(this.Group.SelectedValue=="0")
			{
				strErr+="请选择权限组！\\n";	
			}

            int sort = 0;
            if (this.Sort.Text.Trim() != "")
            {
                if (!int.TryParse(this.Sort.Text.Trim(), out sort))
                {
                    strErr += "排序必须是数值！\\n";
                }
            }
			

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}

			string name=this.Name.Text;
			string url=this.URL.Text;
			int group=int.Parse(this.Group.SelectedValue);
			
			bool isMenu=this.IsMenu.Checked;
			string menuName=this.MenuName.Text;
			

			CMS.Model.Node model=new CMS.Model.Node();
			model.name=name;
			model.url=url;
            model.isMenu = isMenu;
			model.menuName=menuName;
			model.groupId=group;
            model.sort = sort;
			
			CMS.BLL.Node bll=new CMS.BLL.Node();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
