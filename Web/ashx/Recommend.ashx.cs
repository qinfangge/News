using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMS.Web.ashx
{
    /// <summary>
    /// Comment 的摘要说明
    /// </summary>
    public class Recommend : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           

            CMS.Model.News model = new Model.News();
            CMS.BLL.News bll = new BLL.News();
            int id = int.Parse(context.Request["id"].ToString());
            model = bll.GetModel(id);
            if (model != null)
            {
                model.recommendCount += 1;

                CMS.Model.User user = context.Session["user"] as CMS.Model.User;
                if (user != null)
                {
                    CMS.Model.MyRecommend myRecommendModel = new Model.MyRecommend();
                    myRecommendModel.userID = user.id;
                    myRecommendModel.newsID = id;
                    myRecommendModel.addTime = DateTime.Now;
                    CMS.BLL.MyRecommend myRecommendBll = new BLL.MyRecommend();
                    DataSet ds= myRecommendBll.GetList("userID="+user.id+" and newsID="+id);
                       if(ds.Tables[0].Rows.Count ==0)
                       {
                            myRecommendBll.Add(myRecommendModel);
                       }else
                       {
                           string addTime=ds.Tables[0].Rows[0]["addTime"].ToString();
                           context.Response.Write("该条信息你已经于"+addTime+"推荐过了，请不要重复推荐！");
                           return;
                       }
                }

                if (bll.Update(model))
                {
                    context.Response.Write(1);
                }
                else
                {

                    context.Response.Write(0);
                }
            }

           
        }

        




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}