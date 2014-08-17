using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class NewRecommendModel : System.Web.UI.UserControl
    {
      
     
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 绑定数据
        public void BindData()
        {
          
            CMS.BLL.News bll = new CMS.BLL.News();
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder("1=1");
            
            strWhere.AppendFormat(" and id in ({0}) ", getNewsIds());
            
            string orderby = "";
            //ds = bll.GetListByPage(strWhere.ToString(), orderby, 0, 6);
            ds=bll.Cache(30).GetTopList(strWhere.ToString(), orderby, 6, 30);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        #endregion

        #region 获得刚刚推荐的新闻
        private string  getNewsIds()
        {
            
            BLL.Comment bll = new BLL.Comment();
            DataSet ds=bll.GetTopList("", "", 10);

            DataTable table = ds.Tables[0];
            string allIds ="";
            foreach (DataRow row in table.Rows)
            {
                allIds += row["newsId"].ToString() + ",";
            }

            return allIds = allIds.TrimEnd(new char[] { ',' });
        }

        #endregion

    }
}