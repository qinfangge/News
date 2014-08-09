using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using tk.tingyuxuan.utils;

namespace CMS.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CMS.Web.Admin.Config.Config config = new CMS.Web.Admin.Config.Config();
                CMS.Model.Config SeoConfig = config.ReadConfig();

                SiteName.Text = SeoConfig.SiteName;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text.Trim();
            string password = Password.Text.Trim();
            string vCode = VCode.Text.Trim();
            string strErr = "";
            if (userName == "")
            {
                strErr += "用户名不能为空！\\n";
            }

            if (password == "")
            {
                strErr += "密码不能为空！\\n";
            }


            if (Session["vcode"] == null)
            {
                strErr += "验证码已经过期！\\n";
            }
            else
            {
                if (vCode != Session["vcode"].ToString())
                {
                    strErr += "验证码错误！\\n";
                }
            }

            if (strErr != "")
            {
                //MessageBoxTip.Alert(this, strErr);
                MessageBoxTip.Alert(this, strErr);
                return;
            }
            DataSet ds = new DataSet();
            BLL.User bll = new BLL.User();
            StringBuilder strWhere = new StringBuilder();

            strWhere.AppendFormat("userName= '{0}' and password='{1}'", userName, password);
            ds = bll.GetList(strWhere.ToString());

            int Count = ds.Tables["ds"].Rows.Count;
            if (Count == 0)
            {
                MessageBoxTip.Alert(this, "用户名或密码错误!");

            }
            else
            {
                int id = int.Parse(ds.Tables["ds"].Rows[0]["id"].ToString());
                CMS.Model.User user = bll.GetModel(id);
                if (user.isActive)
                {
                    SetUserNode(user);
                    Session["user"] = user;

                    MessageBoxTip.AlertAndRedirect(this, "登录成功", "/Admin/Index/Index.aspx");
                }
                else
                {
                    MessageBoxTip.Alert(this, "该账户还未通过审核，请通过网站底部电话联系我们！");
                }

                // Response.Write("News/List.aspx");
                // MessageBoxTip.AlertAndRedirect(this,"登录成功", );
            }
        }

        #region 设置用户能访问的结点（地址)
        protected void SetUserNode(CMS.Model.User user)
        {
            CMS.BLL.Role roleBll = new CMS.BLL.Role();
            CMS.Model.Role role = roleBll.GetModel(user.type.Value);
            if (role != null)
            {
                user.realName = role.name;
            }
            else
            {
                if (user.userName == "admin")
                {
                    user.realName = "超级管理员";
                }
            }
            CMS.BLL.Role_Node Role_NodeBll = new CMS.BLL.Role_Node();
            DataSet nodeData = Role_NodeBll.GetList("roleId=" + user.type.Value);
            DataRowCollection rows = nodeData.Tables[0].Rows;
            string ids = "";
            string strWhere = "";
            for (int j = 0; j < rows.Count; j++)
            {
                ids += rows[j]["nodeId"].ToString() + ",";
            }

            if (ids != "")
            {
                ids = ids.Remove(ids.Length - 1);
                strWhere = " id in (" + ids + ")";
            }
            CMS.BLL.Node nodeBll = new CMS.BLL.Node();
            DataSet nodeDataSet = nodeBll.GetList(strWhere);
            List<string> node = new List<string>();
            DataRowCollection nodeRows = nodeDataSet.Tables[0].Rows;
            for (int i = 0; i < nodeRows.Count; i++)
            {
                node.Add(nodeRows[i]["url"].ToString().ToLower());
            }


            user.Node = node;
        }
        #endregion

       
    }
}