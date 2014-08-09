﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private int CategoryId = 19;
        private string allCategory = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            InitSEO();//初始化SEO

            StringBuilder strWhere = new StringBuilder("recommend=1");
            string orderBy = "addTime desc";
            int currentPage = 1;

            if (!string.IsNullOrEmpty(Request["page"]))
            {
                currentPage = int.Parse(Request["page"].ToString());
            }

            DataSet ds = new DataSet();
            #region 新闻中心

            if (!string.IsNullOrEmpty(Request["category"]))
            {
                CategoryId = int.Parse(Request["category"].ToString());
                string allCategory = this.getAllCategory(CategoryId);

                strWhere = new StringBuilder("category in " + allCategory);
            }
            

           
            int pageSize = Pager1.PageSize;
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            CMS.BLL.News bll = new CMS.BLL.News();
            // ds = bll.GetListByPage(strWhere.ToString(), orderBy, startIndex, endIndex);
            ds = bll.GetListByPage(strWhere.ToString(), orderBy, pageSize, currentPage, true);
            Pager1.RecordCount = bll.GetRecordCount(strWhere.ToString());


            NewsRepeater.DataSource = ds;
            NewsRepeater.DataBind();

            #endregion

        }

        #region 获得当前栏目下的所有栏目
        private string getAllCategory(int CategoryId)
        {
            string allCategory = "(";
            BLL.Category bll = new BLL.Category();
            DataTable table = bll.GetChildren(CategoryId);
            allCategory += CategoryId.ToString() + ",";
            foreach (DataRow row in table.Rows)
            {
                allCategory += row["id"].ToString() + ",";
            }

            allCategory = allCategory.TrimEnd(new char[] { ',' });
            return allCategory + ")";
        }

        #endregion

        #region 初始化SEO
        private void InitSEO()
        {

            CMS.Web.Admin.Config.Config config = new CMS.Web.Admin.Config.Config();
            CMS.Model.Config SeoConfig = config.ReadConfig();
            Page.Title = SeoConfig.SiteName;
            Literal Keywords = this.Master.FindControl("SEOKeywords") as Literal;
            Literal Description = this.Master.FindControl("SEODescription") as Literal;
            Keywords.Text = string.Format(@"<meta name=""keyWords"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(SeoConfig.KeyWords, 80, true));

            Description.Text = string.Format(@"<meta name=""description"" content=""{0}"" />", tk.tingyuxuan.utils.HtmlHelper.SubStr(SeoConfig.Description, 80, true));
            Keywords.Text = "\r\n" + Keywords.Text + "\r\n";
            Description.Text += "\r\n";

        }
        #endregion

        protected void NewsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        protected void NewsRepeater_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {

        }

    }
}