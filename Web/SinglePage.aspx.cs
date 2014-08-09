using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CMS.Web
{
    public partial class SinglePage : System.Web.UI.Page
    {
        public string strid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["title"] != null && Request.Params["title"].Trim() != "")
                {

                    string title = Request.Params["title"];
                    ShowInfo(title);
                }
            }
        }
        #region 显示页面信息
        private void ShowInfo(string title)
        {
            CMS.BLL.SinglePage bll = new CMS.BLL.SinglePage();
            CMS.Model.SinglePage model = bll.GetModel(title);
            if (model == null)
            {
                Response.Write("该信息或已被删除！");
               
                
                Response.End();
            }

            #region 显示内容
            ArticleTitle.Text = model.title;
            SinglePageModel1.ID= model.id;
            Content.Text = model.content;
            AddTime.Text = model.addTime.Value.ToString("yyyy-MM-dd H:m:s");
            Hits.Text = (model.hit.Value+1).ToString();
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


        }
        #endregion
    }
}