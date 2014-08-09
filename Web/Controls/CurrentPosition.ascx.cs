using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class CurrentPosition : System.Web.UI.UserControl
    {
        public DataTable ArticleTable { set; get; }
        public string ArticleTableName { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ArticleTable == null) return;
            string nav="<a href='/'>首页</a>";
            ArrayList list = new ArrayList();
            list.Add("0");//顶级栏目
            list.Add("1");//新闻相关
            foreach (DataRow row in ArticleTable.Rows)
            {
                //Array.Find<int>(topColumn, 1);
                if(row["id"].ToString()!="1")//如果是新闻相关，则跳过去
                {
                    if (list.Contains(row["pid"].ToString()))
                    {
                        nav += string.Format(" &gt;&gt; <a href='{0}.aspx?category={1}'>{2}</a>", ArticleTableName, row["id"].ToString(), row["name"]);
                    }
                    else
                    {
                        nav += string.Format(" &gt;&gt; <a href='{0}.aspx?category={1}&pid={3}'>{2}</a>", ArticleTableName, row["id"].ToString(), row["name"], row["pid"]);
                    }
                }
            }

            Nav.Text = nav;
        }


    }
}