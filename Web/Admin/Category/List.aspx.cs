using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;
using tk.tingyuxuan.utils;
namespace CMS.Web.Admin.Category
{
    public partial class List : CommonPage
    {
        
        
        
		CMS.BLL.Category bll = new CMS.BLL.Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

        protected void DelButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcategory.SelectedValue);
            CMS.BLL.Category bll = new CMS.BLL.Category();
            DataTable children = bll.GetChildren(id);
            if (children.Rows.Count > 0)
            {
                MessageBoxTip.Alert(this, "当前栏目下有子栏目，无法删除，请先删除或移动子栏目后再进行操作！");
               
            }
            else
            {

                int ID = int.Parse(txtcategory.SelectedValue);
                CMS.Model.Category model = bll.GetModel(ID);
                if (bll.Delete(ID))
                {
                    MessageBoxTip.AlertAndRedirect(this, "删除成功！","List.aspx");
                }
                else
                {
                    MessageBoxTip.Alert(this, "删除失败,请稍后重试！");
                }
            }
            
        }
    }
}
