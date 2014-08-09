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

namespace CMS.Web
{
    public partial class Search : System.Web.UI.Page
    {
        protected string keyWords { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }

        }

        public void BindData()
        {


            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder("1=1");
            if (!string.IsNullOrEmpty(Request["keyWords"]))
            {
                keyWords = Request["keyWords"].ToString();
                Page.Title = "\"" + keyWords + "\"搜索结果";
                (this.Master as Site).keywords = keyWords;
                strWhere.AppendFormat(" and title like '%{0}%'", keyWords);
            }
          
            string orderBy = "id desc";
            int currentPage = 1;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                currentPage = int.Parse(Request["page"].ToString());
            }
            int pageSize = Pager1.PageSize;
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            CMS.BLL.Article bll = new CMS.BLL.Article();
          //  ds = bll.GetListByPage(strWhere.ToString(), orderBy, startIndex, endIndex);
            ds = bll.GetListByPage(strWhere.ToString(), orderBy, pageSize, currentPage, true);

            Pager1.RecordCount = bll.GetRecordCount(strWhere.ToString());

            Repeater1.DataSource = ds;
            Repeater1.DataBind();


        }

      


    }
}
