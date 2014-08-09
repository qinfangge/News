using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class CategoryControl : System.Web.UI.UserControl
    {
        public int CategoryId{get;set;}
        public int ParentId { get; set;}
        public string ArticleTableName { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["category"] != null)
            {
                CategoryId = int.Parse(Request["category"].ToString());
                ParentId = CategoryId;
            }

            if (Request["pid"] != null)
            {

                ParentId = int.Parse(Request["pid"].ToString());
            }
           

            #region 初始化栏目
            CMS.BLL.Category bll = new CMS.BLL.Category();
            CMS.Model.Category category = bll.GetModel(ParentId);
            Literal1.Text = category.name;
            Repeater1.DataSource = bll.GetCategoryForSelect(ParentId);//设置数据源
            Repeater1.DataBind();
            #endregion
        }
    }
}