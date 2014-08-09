using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;
using System.Xml;
using System.Web.Caching;
namespace CMS.Web.Admin.Notice
{
    public partial class List : CommonPage
    {
        protected string CurrentCategory { set; get; }


        CMS.BLL.Notice bll = new CMS.BLL.Notice();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
                BindData();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = this.Request.FilePath + "?";

            if (!string.IsNullOrEmpty(txtKeyword.Text))
            {
                url += "keywords=" + txtKeyword.Text;
            }
            DropDownList currentCategroy = Category1.FindControl("CategoryList") as DropDownList;
            url += "&category=" + currentCategroy.SelectedValue;
            Response.Redirect(url, true);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.DeleteList(idlist);
            BindData();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // your codes.
            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;

            ListItem item = currentCategory.Items.FindByValue(CurrentCategory);
            if (item != null)
            {
                item.Selected = true;
            }

        }


        #region gridView

        public void BindData()
        {
            #region
            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}
            #endregion

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder("1=1");
            CMS.Model.User user = Session["user"] as CMS.Model.User;
            //string currentRole = user.type.ToString();

            //string[] rolesArray = { };
            //if (Cache["管理组"] == null)
            //{
            //    XmlDocument xDoc = new XmlDocument();
            //    string file = "~/App_Data/UserType.xml";
            //    xDoc.Load(Server.MapPath(file));
            //    XmlNodeList xNodeList = xDoc.GetElementsByTagName("role");
            //    string roles = "";
            //    roles = xNodeList[0].ChildNodes[1].InnerText;
            //    rolesArray = roles.Split(new char[] { ',' });
            //    CacheDependency dp = new CacheDependency(Server.MapPath(file));//建立缓存依赖项dp
            //    Cache.Insert("管理组", rolesArray, dp, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);


            //}
            //int position = Array.IndexOf(Cache["管理组"] as string[], currentRole);
            if (!isManageGroup())
            {
                strWhere.Append(" and userId=" + user.id);
            }

            if (!string.IsNullOrEmpty(Request["keyWords"]))
            {

                txtKeyword.Text = Request["keyWords"].ToString();
            }



            if (!string.IsNullOrEmpty(Request["category"]))
            {
                string currentCategory = Request["category"].ToString();

                if (currentCategory != "0")
                {
                    CurrentCategory = currentCategory;
                    strWhere.AppendFormat(" and category={0} ", currentCategory);
                }


            }

            if (txtKeyword.Text.Trim() != "")
            {
#warning 代码生成警告：请修改 keywordField 为需要匹配查询的真实字段名称
                strWhere.AppendFormat(" and title like '%{0}%'", txtKeyword.Text.Trim());
            }

            string orderBy = "id desc";
            int currentPage = 1;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                currentPage = int.Parse(Request["page"].ToString());
            }
            int pageSize = Pager1.PageSize;
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            //ds = bll.GetListByPage(strWhere.ToString(), orderBy, startIndex, endIndex);
            ds = bll.GetListByPage(strWhere.ToString(), orderBy, pageSize, currentPage, true);
            Pager1.RecordCount = bll.GetRecordCount(strWhere.ToString());
           // DataTable dt = ds.Tables[0];
            //if (dt.Rows.Count == 0)
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gridView.DataSource = ds;
            //    gridView.DataBind();
            //    gridView.Rows[0].Cells.Clear();
            //    gridView.Rows[0].Cells.Add(new TableCell());
            //    gridView.Rows[0].Cells[0].ColumnSpan = 5;
            //    gridView.Rows[0].Cells[0].Text = "暂无信息！";
            //    gridView.Rows[0].Cells[0].Style.Add("color", "red");
            //}
            //else
            //{
                gridView.DataSource = ds;
                gridView.DataBind();
            //}
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "<label><input id='checkAll' type='checkbox'/>全选</label>";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");

                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}

            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.Delete(ID);

            BindData();
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        #endregion





    }
}
