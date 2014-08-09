using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CMS.BLL;

namespace CMS.Web
{
    public partial class ProjectDetail : System.Web.UI.Page
    {
        public string strid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int id = (Convert.ToInt32(strid));
                    ShowInfo(id);
                }
            }
        }
        #region 显示页面信息
        private void ShowInfo(int id)
        {
            CMS.BLL.Project bll = new CMS.BLL.Project();
            CMS.Model.Project model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("该信息或已被删除！");
                Response.End();
            }
            #region 显示内容
            ArticleTitle.Text = model.title;
            Content.Text = model.content;
            AddTime.Text = model.addTime.ToString("yyyy-MM-dd H:m:s");
            Hits.Text = (model.hit.Value + 1).ToString();
            StartTime.Text = model.startTime.Value.ToString("yyyy年MM月dd hh点mm分ss秒");
            EndTime.Text = model.endTime.Value.ToString("yyyy年MM月dd hh点mm分ss秒");
            Price.Text = model.price;
            #endregion
            #region 设置SEO
            Page.Title = model.title;
            HtmlMeta keyWords = new HtmlMeta();
            keyWords.Name = "keyWords";
            keyWords.Content = model.keywords;
            this.Page.Header.Controls.Add(keyWords);
            Literal literal = new Literal();
            literal.Text = "\r\n";
            this.Page.Header.Controls.Add(literal);
            HtmlMeta description = new HtmlMeta();
            description.Name = "description";
            description.Content = model.description;
            this.Page.Header.Controls.Add(description);
            #endregion
            #region 点击量加1
            model.hit = model.hit + 1;
            bll.Update(model);
            #endregion

            #region 文章小导航
            Category category = new Category();
            CurrentPosition1.ArticleTable = category.GetParents(model.category.Value);
            #endregion
        }
        #endregion
    }
}