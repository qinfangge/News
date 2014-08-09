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
    public partial class FriendLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 绑定数据
        public void BindData()
        {
            CMS.BLL.FriendLink bll = new CMS.BLL.FriendLink();
            DataSet ds = new DataSet();
            //StringBuilder strWhere = new StringBuilder("1=1");

            //string orderby = "sort asc ";
            ds = bll.GetAllList();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        #endregion
    }
}