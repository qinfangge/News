using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class Category : System.Web.UI.UserControl
    {
        [Browsable(true)]
        [Category("文本")]
        [Description("父栏目ID")]
        [DefaultValue("0")]//默认值
        public int ParentId {set;get;}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 初始化栏目
                CMS.BLL.Category bll = new CMS.BLL.Category();
                //★★与表的数据绑定★★
                CategoryList.DataSource = bll.GetCategoryForSelect(ParentId);//设置数据源
                CategoryList.DataTextField = "name";//设置所要读取的数据表里的列名
                CategoryList.DataValueField = "id";

                CategoryList.DataBind();//数据绑定
                CategoryList.Items.Insert(0, new ListItem("请选择栏目", "0"));
                #endregion
            }
        }
    }
}