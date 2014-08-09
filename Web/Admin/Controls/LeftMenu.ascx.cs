using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Admin.Controls
{
    public partial class LeftMenu : System.Web.UI.UserControl
    {
        private CMS.BLL.Node nodeBll = new CMS.BLL.Node();
        private string nodeIds = "";//用户所在角色允许访问的结点;
        private CMS.Model.User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = Session["user"] as CMS.Model.User;
                int currentRole = int.Parse(user.type.ToString());
                string ids = "";
                string leftMenuKey="RoleLeftMenu_" + currentRole;
                if (Cache[leftMenuKey] == null)
                {
                    CMS.BLL.Role roleBll = new CMS.BLL.Role();
                    CMS.Model.Role role = roleBll.GetModel(user.type.Value);
                    CMS.BLL.Role_Node Role_NodeBll = new CMS.BLL.Role_Node();
                    DataSet nodeData = Role_NodeBll.GetList("roleId=" + user.type.Value);
                    DataRowCollection rows = nodeData.Tables[0].Rows;
                    

                    for (int j = 0; j < rows.Count; j++)
                    {
                        ids += rows[j]["nodeId"].ToString() + ",";
                    }

                    if (ids != "")
                    {
                        ids = ids.Remove(ids.Length - 1);
                        nodeIds = " id in (" + ids + ")";
                    }
                    DataSet ds=nodeBll.GetNodeGroup(nodeIds);
                    Cache.Insert(leftMenuKey, ds, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);

                    //Cache.Add("name", content, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                }


                NodeGroupRepeater.DataSource = Cache[leftMenuKey] as DataSet;// nodeBll.GetNodeGroup(nodeIds);//取得用户所在的组
               NodeGroupRepeater.DataBind();




            }
        }

        protected void NodeGroupRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater NodeRepeater = (Repeater)e.Item.FindControl("NodeRepeater");
                //找到分类Repeater关联的数据项
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID
                int id = Convert.ToInt32(rowv["id"]);
                 string childMenuKey="ChildMenu_" + id+"_"+user.type;

                 if (Cache[childMenuKey] == null)
                 {
                     
                     //根据分类ID查询该分类下的产品，并绑定产品Repeater
                     string strWhere = " isMenu = 1 and groupId=" + id;
                     if (this.nodeIds != "")
                     {
                         strWhere += " and " + nodeIds;
                     }

                     DataSet nodeData = nodeBll.GetListWithOrder(strWhere, " sort asc ");
                     System.Web.Caching.CacheDependency dep = new System.Web.Caching.CacheDependency(null, new string[] { "RoleLeftMenu_" +user.type });//缓存依赖
                     Cache.Insert(childMenuKey, nodeData, dep, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);

                 }


                NodeRepeater.DataSource = Cache[childMenuKey] as DataSet;
                NodeRepeater.DataBind();
            } 
        }


       

    }
}