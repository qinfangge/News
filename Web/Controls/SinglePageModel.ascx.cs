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
    public partial class SinglePageModel : System.Web.UI.UserControl
    {
        public int ID { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            BindData(); 
            base.OnPreRender(e);
        }

        #region 绑定数据
        public void BindData()
        {
            CMS.BLL.SinglePage bll = new CMS.BLL.SinglePage();
            DataSet ds = new DataSet();
            string orderby = "sort asc ";
            string strWhere = " category=63 ";
            //ds = bll.GetListByPage("", orderby, 0, 6);
            ds=bll.GetTopList(strWhere, orderby,10);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        #endregion



    }
}