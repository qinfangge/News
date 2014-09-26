using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Home
{
    public partial class Default : System.Web.UI.Page
    {
        
       

        protected void Page_Load(object sender, EventArgs e)
        {

            CMS.Model.User user = Session["user"] as CMS.Model.User;

            StringBuilder strWhere = new StringBuilder("userId="+user.id);
            string orderBy = "addTime desc";
            int currentPage = 1;

            if (!string.IsNullOrEmpty(Request["page"]))
            {
                currentPage = int.Parse(Request["page"].ToString());
            }

            DataSet ds = new DataSet();
            #region 新闻中心

          
            

           
            int pageSize = Pager1.PageSize;
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            CMS.BLL.News bll = new CMS.BLL.News();
            // ds = bll.GetListByPage(strWhere.ToString(), orderBy, startIndex, endIndex);
            ds = bll.GetMyRecommendByPage(strWhere.ToString(), orderBy, pageSize, currentPage);
            Pager1.RecordCount = bll.GetMyRecommendRecordCount(user.id);


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