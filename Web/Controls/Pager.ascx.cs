using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class Pager : System.Web.UI.UserControl
    {

        private int pageSize; //页大小

        private int recordCount; //记录总数

        private int page; //指当前页码

        private int pageCount;  //page总数

        private string url; //当前页地址



        private int width; //控件宽度

        private string cssClass; //控件css类名

        private string align; //对齐方式



        private string pageHtml;



        private bool? enablePageInfo; //是否显示分页信息

        private bool? enableJumpPage; //是否显示跳转信息



        protected void Page_Load(object sender, EventArgs e)
        {

            pageCount = PageCount;

            page = CurrentPage;

            url = Url;

            width = Width;

            if (pageSize >= recordCount) return;

            pageHtml += (width == 0) ? "<div class=\"" + CssClas + "\">" : "<div class=\"" + CssClas + "\" style=\"width:" + width + "px\">";

            if (EnablePageInfo == true) AppendPageInfo();

            pageHtml += (page <= 1) ? "<span class=\"disabled\">上一页</span>" : "<a href=\"" + url.Replace("page=" + page, "page=" + (page - 1)) + "\" title=\"上一页\" class=\"pagerPrev\">上一页</a>";

            pageHtml += (page <= 1) ? "<span class=\"current\">" + page + "</span>" : "<a href=\"" + url.Replace("page=" + page, "page=1") + "\" title=\"跳转到第1页\">1</a>";

            int start = 2;

            int end = (pageCount < 10) ? pageCount : 10;

            if (page > 8)
            {

                pageHtml += "...";

                start = page - 4;

                int end1 = page + 5;

                end = (pageCount < end1) ? pageCount : end1;

            }

            for (int i = start; i < end; i++)
            {

                pageHtml += (i == page) ? "<span class=\"current\">" + i + "</span>" : "<a href=\"" + url.Replace("page=" + page, "page=" + i) + "\" title=\"跳转到第" + i + "页\">" + i + "</a>";

            }

            pageHtml += (page + 5 < pageCount) ? "..." : "";

            pageHtml += (page == pageCount) ? "<span class=\"current\">" + page + "</span>" : "<a href=\"" + url.Replace("page=" + page, "page=" + pageCount) + "\" title=\"跳转到第" + pageCount + "页\">" + pageCount + "</a>";

            pageHtml += (page == pageCount) ? "<span class=\"disabled\">下一页</span>" : "<a href=\"" + url.Replace("page=" + page, "page=" + (page + 1)) + "\" title=\"下一页\" class=\"pagerNext\">下一页</a>";

            if (EnableJumpPage == true) AppendJumpPageScript();

            pageHtml += "</div>";

            PagerBar.Text = pageHtml;
        }



        private void AppendJumpPageScript()
        {

            pageHtml += "&nbsp;<span  class='jumpPage'>跳到第 <input id=\"txtPagebarJumpPage\" class=\"pagebarTextBox\" onfocus=\"this.value=''\" type=\"text\" value=\"" + page + "\" style=\"width:20px;\" /> 页&nbsp;<input type=\"button\" class=\"pagerButton\" onclick=\"jumpPage();\" value=\"确定\" title=\"跳转到指定页\" /></span>" + System.Environment.NewLine;

            pageHtml += "<script type=\"text/javascript\">\n";

            pageHtml += " //<![CDATA[ \n";

            pageHtml += " function jumpPage(){ \n";

            pageHtml += "     var url; \r\n";

            pageHtml += "     var pageNo = document.getElementById('txtPagebarJumpPage').value; \n";

            pageHtml += "     if (document.URL.indexOf('page=') > 0) \r\n";

            pageHtml += "         url =  document.URL.replace('page=" + page + "','page='+pageNo); \n";

            pageHtml += "     else \n";

            pageHtml += "         url =  document.URL.indexOf('?') > 0 ? document.URL + '&amp;page='+ pageNo: document.URL + '?page='+pageNo; \n";

            pageHtml += "     location.href = url; \n";

            pageHtml += " } \r\n";

            pageHtml += " //]]> \r\n";

            pageHtml += "</script> \r\n";

        }



        private void AppendPageInfo()
        {

            pageHtml += "<span class=\"pageInfo\">第" + CurrentPage + "/" + PageCount + "页" + System.Environment.NewLine + "</span>";

        }



        #region 受保护属性

        private int PageCount // 页数
        {

            get
            {

                return (recordCount == 0) ? 1 : (int)(Math.Ceiling((double)recordCount / pageSize));

            }

        }

        private int CurrentPage
        {

            get
            {

                string query = Request.Url.Query;

                string pageString = "page=1";

                Regex regex = new Regex(@"(page=\d*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

                Match match = regex.Match(query);

                if (match.Success)
                {

                    pageString = match.Groups[1].ToString();

                }

                if (pageString.IndexOf("=") > -1)
                {

                    string[] arrPage = pageString.Split(new Char[] { '=' });

                    page = int.Parse(arrPage[1]);

                }

                else
                {

                    page = 1;

                }

                if (page > PageCount) { page = PageCount; }

                if (page < 1) { page = 1; }

                return (int)page;

            }

        }

        private string Url
        {

            get
            {
                string query = "";
                if (!IsRewrite)
                {
                    query = Request.Url.PathAndQuery;

                }
                else
                {
                    query = Request.RawUrl;
                }
                Regex regex = new Regex(@"(page=\d*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

                if (!regex.Match(query).Success) { query += (query.IndexOf("?") > -1 ? "&amp;page=1" : "?page=1"); }

                return query;

            }

        }

        private bool IsRewrite
        {
            get
            {
                return Request.RawUrl != Request.Url.PathAndQuery;
            }
        }



        #endregion

        #region  公共属性
        [Browsable(true)]
        [Category("文本")]
        [Description("每页多少行")]
        [DefaultValue("10")]//默认值
        public int PageSize
        {

            get { return (pageSize == 0) ? 10 : pageSize; }

            set { pageSize = value; }

        }
        [Browsable(true)]
        [Category("文本")]
        [Description("一共是多少行")]
        [DefaultValue("20")]//默认值
        public int RecordCount
        {

            get { return recordCount; }

            set { recordCount = value; }

        }

        public string CssClas
        {

            get { return (string.IsNullOrEmpty(cssClass)) ? "sabrosus" : cssClass; }

            set { cssClass = value; }

        }



        public string Align
        {

            get
            {

                if (string.IsNullOrEmpty(align))

                    return "center";

                switch (align.ToLower())
                {

                    case "left":

                        return "left";

                    case "right":

                        return "right";

                    default:

                        return "center";

                }

            }

            set
            {

                align = value;

            }

        }

        public int Width
        {

            get { return width; }

            set { width = value; }

        }

        public bool? EnableJumpPage
        {

            get { return (enableJumpPage == null) ? false : enableJumpPage; }

            set { enableJumpPage = value; }

        }

        public bool? EnablePageInfo
        {

            get { return (enablePageInfo == null) ? false : enablePageInfo; }

            set { enablePageInfo = value; }

        }

        #endregion

    }
}