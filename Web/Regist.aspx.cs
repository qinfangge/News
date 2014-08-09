using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tk.tingyuxuan.utils;

namespace CMS.Web
{
    public partial class Regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                BindUserType();
            
        }

        public void BindUserType()
        {

            #region 初始化用户角色
            CMS.BLL.Role groupBLL = new CMS.BLL.Role();
            CMS.Model.Role defaultModel = groupBLL.GetDefaultModel();



            //★★与表的数据绑定★★
            UserType.DataSource = groupBLL.GetTopList("isShow=1", "sort asc", 20);//设置数据源

            UserType.DataTextField = "name";//设置所要读取的数据表里的列名
            UserType.DataValueField = "id";
            UserType.DataBind();//数据绑定
            if (defaultModel != null)
            {
                ListItem item = UserType.Items.FindByValue(defaultModel.id.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
            }

            #endregion
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            CMS.BLL.User bll = new CMS.BLL.User();
            string strErr = "";
            string userName = this.UserName.Text.Trim();
            string password = this.Password.Text.Trim();
            string confirmPassword = this.ConfirmPassword.Text.Trim();
            string vCode = VCode.Text.Trim();
            bool isSelected = false;
            foreach (ListItem item in UserType.Items)
            {
                if (item.Selected)
                {
                    isSelected = true;
                    break;
                }
            }

            if (!isSelected)
            {
                strErr += "请选择用户类型！\\n";
            }
            if (userName.Length == 0)
            {
                strErr += "用户名不能为空！\\n";
            }
            else
            {
              
                
               int count= bll.GetRecordCount("userName='" + userName+"'");
               if (count > 0)
               {
                   strErr += "用户名已存在！\\n";
               }

            }
            if (password.Length == 0)
            {
                strErr += "密码不能为空！\\n";
            }

            if (password != confirmPassword)
            {
                strErr += "2次输入的密码不一致！\\n";
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
                MessageBoxTip.Alert(this, strErr);
                return;
            }

            
            
            
            DateTime addTime = DateTime.Now;
            bool isActive = false;

            int type = int.Parse(UserType.SelectedValue);

            CMS.Model.User model = new CMS.Model.User();
            model.userName = userName;
            model.password = password;
            model.addTime = addTime;
            model.isActive = isActive;
            model.type = type;

           // CMS.BLL.User bll = new CMS.BLL.User();
            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "注册成功，请等待审核！", "Login.aspx");
        }
    }
}