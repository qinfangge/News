using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CMS.BLL;
using Utils;

namespace CMS.Web
{
    public partial class Detail : System.Web.UI.Page
    {
        public string strid = "";
        private static IPSeeker seeker = null;

        public Detail()
        {
            
            seeker = new IPSeeker(Server.MapPath("~/App_Data/QQWry.Dat"));//纯真IP地址库存放目录！！
        }
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
            CMS.BLL.News bll = new CMS.BLL.News();
            CMS.Model.News model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("该信息或已被删除！");
                Response.End();
            }



            #region 显示内容
            ArticleTitle.Text = model.title;
            Source.Text = model.source;
            Content.Text = model.content;
            AddTime.Text = model.addTime.Value.ToString("yyyy-MM-dd H:m:s");
            Hits.Text = (model.hit.Value + 1).ToString();
            #endregion

            #region 显示最热评论
            CMS.BLL.Comment commentBll = new CMS.BLL.Comment();
            DataSet ds = new DataSet();
            ds=commentBll.GetList(10, "", "dig asc");
            HotReplayRepeater.DataSource = ds;
            HotReplayRepeater.DataBind();
            CommentCount.Text = (commentBll.GetRecordCount("newsId=" + id)).ToString();
            #endregion
            #region 显示最新评论
          
            ds=commentBll.GetList(10, "", "id desc");
            NewReplayRepeater.DataSource = ds;
            NewReplayRepeater.DataBind();
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

            CurrentPosition1.ArticleTable = category.GetParents(int.Parse(model.category.Value.ToString()));

            #endregion






        }
        #endregion

        protected static string  GetAddress(string ip)
        {
            string address = "未知区域";
          
            System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(ip);
            IPLocation loc = seeker.GetLocation(ipaddr);
            if (loc != null)
            {
                address = loc.Country + loc.Zone;
            }
            return address;
        }
        
    }
}