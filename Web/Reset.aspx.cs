using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tk.tingyuxuan.utils;

namespace CMS.Web
{
    public partial class Reset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
               
            
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            CMS.BLL.User bll = new CMS.BLL.User();
            string strErr = "";
            string userName = this.UserName.Text.Trim();
            string password = this.Password.Text.Trim();
           
            string vCode = VCode.Text.Trim();
           

           
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

           
            CMS.Model.User model = new CMS.Model.User();
            model.userName = userName;
            model.password = password;
            model.addTime = addTime;
            model.isActive = isActive;
            

           // CMS.BLL.User bll = new CMS.BLL.User();
            bll.Add(model);
            MessageBoxTip.AlertAndRedirect(this, "注册成功，请等待审核！", "Login.aspx");
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}