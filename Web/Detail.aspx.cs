using System;
using System.Collections;
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
        protected  CMS.Model.User user = null;
       static CMS.BLL.Avatar bll = new BLL.Avatar();
       static CMS.BLL.User userBll = new BLL.User();
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
                    if (Session["user"] != null)
                    {
                        user = Session["user"] as CMS.Model.User;
                    }
                    //user = new CMS.Model.User();
                    //user.id = 3;
                    //user.userName = "封丘门户网";
                    
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




            #region 登录状态
            //bool isLogin = false;
            if (user!=null)
            {

                LoginPanel.Visible = false;
                LoginInPanel.Visible = true;

              
                ReplyModuleLogin.Visible = false;
                ReplyModuleLoginIn.Visible = true;
                InitAvatar();

            }
            else
            {
                LoginPanel.Visible = true;
                LoginInPanel.Visible = false;

                ReplyModuleLogin.Visible = true;
                ReplyModuleLoginIn.Visible = false;
            }
            #endregion

            #region 显示最热评论
            CMS.BLL.Comment commentBll = new CMS.BLL.Comment();


            string strWhere = "newsId=" + id;

            DataSet ds = new DataSet();
            ds = commentBll.GetList(4, strWhere+" and dig>5", "dig desc");
            HotReplayRepeater.DataSource = ds;
            HotReplayRepeater.DataBind();
            CommentCount2.Text = CommentCount.Text = (commentBll.GetRecordCount("newsId=" + id)).ToString();
            #endregion
            #region 显示最新评论

            ds = commentBll.GetList(10, strWhere, "id desc");
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

        protected static string GetParentCommentHtml(int pid)
        {
            if (pid == 0) return "";
            string html = "";
            string commentStartHtml = "<div class='tie-frontOfFloor layerBgcolor'>";


            string commentEndHtml = "</div>";

            ArrayList list = new ArrayList();
            GetParentComment(pid, ref list);

             list.Reverse();
            
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                string commentHtml = @"<div class='tie-floorInner'>                
                                            <span class='tie-floor-author layerUserName'>
                                                {0}网易河北省石家庄市手机网友 [{1}]的原贴：</span>
                                                <span class='tie-floor-index'>{2}</span>            
                                         </div>          
                                        <p class='tie-floor-content layerFontColor'>{3}</p>";
                CMS.Model.Comment comment = item as CMS.Model.Comment;

                commentHtml = string.Format(commentHtml, GetAddress(comment.ip), GetUserName(comment.userId.Value), i + 1, comment.content);

                html += commentHtml;
                html = string.Format(commentStartHtml + "{0}" + commentEndHtml, html);
                

            }

           


            // commentHtml+=GetParentComment(comment.Pid.Value);

            return html;
        }
        protected static void GetParentComment(int pid, ref ArrayList list)
        {

            if (pid > 0)
            {
                CMS.BLL.Comment commentBll = new CMS.BLL.Comment();
                CMS.Model.Comment comment = new Model.Comment();
                comment = commentBll.GetModel(pid);
                if (comment != null)
                {
                    list.Add(comment);
                    GetParentComment(comment.Pid.Value, ref list);
                }

            }
            // return list;
        }

        #region 头像设置
        private void InitAvatar()
        {
            int userID =user.id;

            CMS.BLL.Avatar bll = new BLL.Avatar();
            string url = "";
            CMS.Model.Avatar model = bll.GetAvatarByUserID(userID);
            int width = 120;
            int height = 120;
            int id = 0;
            if (model != null)
            {
                id = model.id;

            }

            url = width + "|" + height + "|" + id;
            url = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(url)).Replace("+", "%2B");
            url = url + ".jpg";
            Avatar.ImageUrl = "/Avatar/" + url;

        }
        #endregion


        #region 获得评论者的头像
        protected static string  GetAvatar(int userID)
        {
            string url = "";
            CMS.Model.Avatar model = bll.GetAvatarByUserID(userID);
            int width = 120;
            int height = 120;
            int id = 0;
            if (model != null)
            {
                id = model.id;

            }

            url = width + "|" + height + "|" + id;
            url = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(url)).Replace("+", "%2B");
            url = url + ".jpg";

           // Avatar.ImageUrl = "/Avatar/" + url;
            return "/Avatar/" + url;

        }
        #endregion


        #region 获得评论者信息
        protected static string GetUserName(int userID)
        {
            CMS.Model.User user = new Model.User();
            user = userBll.GetModel(userID);
            if (user != null)
            {
                return user.userName;
            }
            else
            {
                return "该用户已被删除！";
            }
            

        }
        #endregion





        protected static string GetAddress(string ip)
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