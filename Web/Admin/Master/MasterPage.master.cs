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
using CMS.Web.Admin.Controls;

namespace CMS.Web.Admin
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string _tabtitle = "";
        private string path="";
        private bool canWrite = false;
        private bool canDelete = false;
        public string UserType{set;get;}
        public CMS.Model.User user{set;get;}

        public string TabTitle
        {
            get
            {
                return _tabtitle;
            }
            set
            {
                _tabtitle = value;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/Admin/Login.aspx");
                return;
            }

            this.user = Session["user"] as CMS.Model.User;
            path=Request.CurrentExecutionFilePath.ToString().ToLower();
            string writePath = path.Replace("list.aspx", "modify.aspx");
            string deletePath = path.Replace("list.aspx", "delete.aspx");
           

           // CMS.Model.User user = Session["user"] as CMS.Model.User;
            if (!user.Node.Contains(path)&&user.userName!="admin")
            {
                Response.Write("对不起，你没有权限访问此页面！");
                Response.End();
            }

            if (user.Node.Contains(writePath) || user.userName == "admin")
            {
                canWrite = true;
            }
            if (user.Node.Contains(deletePath) || user.userName == "admin")
            {
                canDelete = true;
            }

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserName.Text = user.userName;
                RoleName.Text = user.realName;
                GridView gridView = this.ContentPlaceHolder1.FindControl("gridView") as GridView;
                int hiddenColumn = 0;
                if (gridView != null)
                {
                    DataSet ds = gridView.DataSource as DataSet;
                    DataTable dt = ds.Tables[0];

                    for (int s = 0; s < gridView.Columns.Count; s++)
                    {
                        DataControlField de;
                        de = gridView.Columns[s];
                        if (!canWrite)
                        {
                            if (de.HeaderText == "编辑")
                            {
                                gridView.Columns[s].Visible = false;
                                hiddenColumn++;
                                // gridView.Columns.RemoveAt(s);
                            }
                        }

                        if (!canDelete)
                        {
                            if (de.HeaderText == "删除")
                            {
                                //gridView.Columns.RemoveAt(s);
                                gridView.Columns[s].Visible = false;
                                hiddenColumn++;
                            }

                            Button btnDelete = this.ContentPlaceHolder1.FindControl("btnDelete") as Button;
                            if (btnDelete != null)
                            {
                                btnDelete.Visible = false;//隐藏批量删除功能
                            }

                        }
                    }

                    if (dt.Rows.Count == 0)
                    {
                        dt.Rows.Add(dt.NewRow());
                        gridView.DataSource = ds;
                        gridView.DataBind();
                        gridView.Rows[0].Cells.Clear();
                        gridView.Rows[0].Cells.Add(new TableCell());
                        gridView.Rows[0].Cells[0].ColumnSpan = gridView.Columns.Count - hiddenColumn;
                        gridView.Rows[0].Cells[0].Text = "暂无信息！";
                        gridView.Rows[0].Cells[0].Style.Add("color", "red");
                    }
                }
            }
           
               
        }
    }
}
