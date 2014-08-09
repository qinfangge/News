using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
using tk.tingyuxuan.utils;
using UserGroup = CMS.Model.UserGroup;
namespace CMS.Web.Admin.Role
{
    public partial class Assign : CommonPage
    {
        #region 初始化用户角色
        CMS.BLL.Node nodeBLL = new CMS.BLL.Node();
        //★★与表的数据绑定★★
        
        CMS.BLL.Role_Node Role_Node_BLL = new CMS.BLL.Role_Node();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int roleId = int.Parse(Request["id"].ToString());
                this.RoleId.Value = roleId.ToString();
                BindUserType();
                
            }

        }

        protected void BindUserType()
        {

            CMS.BLL.NodeGroup nodeGroupBLL = new CMS.BLL.NodeGroup();
            //★★与表的数据绑定★★
            NodeGroupReapter.DataSource = nodeGroupBLL.GetAllList();//设置数据源

            NodeGroupReapter.DataBind();//数据绑定

            #region 初始化用户角色
            //CMS.BLL.Node nodeBLL = new CMS.BLL.Node();
            ////★★与表的数据绑定★★
            //Node.DataSource = nodeBLL.GetAllList();//设置数据源
            //Node.DataTextField = "name";//设置所要读取的数据表里的列名
            //Node.DataValueField = "id";
            //Node.DataBind();//数据绑定
            //CMS.BLL.Role_Node Role_Node_BLL = new CMS.BLL.Role_Node();
            //DataSet checkedNode=Role_Node_BLL.GetList("roleId=" + int.Parse(RoleId.Value));
            //DataRowCollection checkedRows = checkedNode.Tables[0].Rows;
            //for (int j = 0; j < Node.Items.Count; j++)
            //{
            //    ListItem currentItem=Node.Items[j];

            //    for (int i = 0; i < checkedRows.Count; i++)
            //    {
            //        if (currentItem.Value == checkedRows[i]["nodeId"].ToString())
            //        {
            //            currentItem.Selected = true;
            //        }

            //    }
            //}



            #endregion
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            //if (Node.Items.Count == 0)
            //{
            //    strErr = "请至少选择一项权限！";
            //}


            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            int roleId = int.Parse(this.RoleId.Value);
            CMS.BLL.Role_Node bll = new CMS.BLL.Role_Node();
            bll.DeleteNodeByRole(roleId);
            #region 将右侧菜单数据至空
            string leftMenuKey = "RoleLeftMenu_" + roleId;
            //Cache[leftMenuKey] = null;
            Cache.Remove(leftMenuKey);
            #endregion
            CMS.Model.Role_Node model = new CMS.Model.Role_Node();

            CheckBoxList cbl;
            foreach (RepeaterItem ri in NodeGroupReapter.Items)
            {
                cbl = ri.FindControl("Node") as CheckBoxList;
                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)//这个就是所有选择的项
                    {
                        model.roleId = roleId;
                        model.nodeId = int.Parse(li.Value);
                        bll.Add(model);
                    }
                }
            }
            
            MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void setChechkedBox(CheckBoxList all, DataSet checkedBox,string fieldName)
        {
            DataRowCollection checkedRows = checkedBox.Tables[0].Rows;
            for (int j = 0; j < all.Items.Count; j++)
            {
                ListItem currentItem = all.Items[j];

                for (int i = 0; i < checkedRows.Count; i++)
                {
                    if (currentItem.Value == checkedRows[i][fieldName].ToString())
                    {
                        currentItem.Selected = true;
                    }

                }
            }
        }

       

        protected void NodeGroupReapter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            #endregion

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;

                int groupId = int.Parse(drv["id"].ToString());
                DataSet checkedNode = Role_Node_BLL.GetList("roleId=" + int.Parse(RoleId.Value));
                DataSet nodeDataSet = nodeBLL.GetList("groupId="+groupId);//设置数据源
                CheckBoxList Node = (CheckBoxList)e.Item.FindControl("Node");
                Node.DataSource = nodeDataSet;
                Node.DataTextField = "name";//设置所要读取的数据表里的列名
                Node.DataValueField = "id";
                Node.DataBind();//数据绑定
                setChechkedBox(Node, checkedNode,"nodeId");
            }
        }



    }
}
