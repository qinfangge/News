using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CMS.BLL;

namespace CMS.Web
{
    public partial class ProjectList : System.Web.UI.Page
    {
        private int CategoryId = 2;
        private string allCategory = "";
        BLL.Category bll = new BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindData();
            }
        }
        #region 设置SEO
        private void InitSEO()
        {
            CMS.Model.Category category = null;


            if (CategoryId > 0)
            {
                category = bll.GetModel(CategoryId);

            }
            if (category != null)
            {

                Page.Title = category.name;
                Literal Keywords = this.Master.FindControl("SEOKeywords") as Literal;
                Literal Description = this.Master.FindControl("SEODescription") as Literal;
                if (category.keywords.Trim() != "")
                {
                    Keywords.Text = string.Format(@"<meta name=""keyWords"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(category.keywords, 80, true));
                }
                else
                {
                    Keywords.Text = string.Format(@"<meta name=""keyWords"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(category.name, 80, true));
                }


                if (category.description.Trim() != "")
                {

                    Description.Text = string.Format(@"<meta name=""description"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(category.description, 80, true));

                }
                else
                {
                    Description.Text = string.Format(@"<meta name=""description"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(category.name, 80, true));

                }

                Keywords.Text = "\r\n" + Keywords.Text + "\r\n";
                Description.Text += "\r\n";



            }

        }
        #endregion
        #region 获得当前栏目下的所有栏目
        private void getAllCategory()
        {


            DataTable table = bll.GetChildren(CategoryId);
            allCategory += CategoryId.ToString() + ",";
            foreach (DataRow row in table.Rows)
            {
                allCategory += row["id"].ToString() + ",";
            }

            allCategory = allCategory.TrimEnd(new char[] { ',' });
        }

        #endregion

        #region 绑定数据
        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder("1=1");

            string orderBy = "recommend desc,id desc";
            int currentPage = 1;

            if (!string.IsNullOrEmpty(Request["page"]))
            {
                currentPage = int.Parse(Request["page"].ToString());
            }


            if (!string.IsNullOrEmpty(Request["category"]))
            {
                CategoryId = int.Parse(Request["category"].ToString());

                getAllCategory();
                strWhere.AppendFormat(" and category in ({0}) ", allCategory);
            }

            InitSEO();


            int pageSize = Pager1.PageSize;
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            CMS.BLL.Project bll = new CMS.BLL.Project();
           // ds = bll.GetListByPage(strWhere.ToString(), orderBy, startIndex, endIndex);
            ds = bll.GetListByPage(strWhere.ToString(), orderBy, pageSize, currentPage, true);
            Pager1.RecordCount = bll.GetRecordCount(strWhere.ToString());
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            #region 文章小导航
            Category category = new Category();
            CurrentPosition1.ArticleTable = category.GetParents(CategoryId);

            #endregion
        }
        #endregion
    }
}