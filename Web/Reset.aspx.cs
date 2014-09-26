using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
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
            CMS.Model.User model = new Model.User();
            string strErr = "";
            string userName = this.UserName.Text.Trim();
            string email = this.Email.Text.Trim();
           
            string vCode = VCode.Text.Trim();
           

           
            if (userName.Length == 0)
            {
                strErr += "用户名不能为空！\\n";
            }

            if (email.Length == 0)
            {
                strErr += "邮箱不能为空！\\n";
            }

            DataSet ds = new DataSet();
            if (userName.Length > 0 && email.Length > 0)
            {
                ds = bll.GetList("userName='" + userName + "' and email='" + email + "'");
                if (ds.Tables[0].Rows.Count==0)
                {
                    strErr += "用户名和邮箱不匹配！\\n";
                }
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

                ds.Tables[0].Rows[0]["password"] = "888888";
                ds.AcceptChanges();
           
              

             string url = Request.Url.Host;


             XmlDocument xDoc = new XmlDocument();
             string file = "~/App_Data/Config.xml";
             xDoc.Load(Server.MapPath(file));
             string host = xDoc.SelectSingleNode("/config/smtp/host").InnerText;
             string account = xDoc.SelectSingleNode("/config/smtp/account").InnerText;

             string password = xDoc.SelectSingleNode("/config/smtp/password").InnerText;

             string from = xDoc.SelectSingleNode("/config/smtp/from").InnerText;
             string fromName = xDoc.SelectSingleNode("/config/smtp/fromName").InnerText;
      
             Emailer emailer = new Emailer();
             emailer.UserName = account;
             emailer.Password = password;
             emailer.Host = host;
             emailer.From = from;
             emailer.FromName = fromName;
             emailer.To = email;
             emailer.ToName = userName;
             emailer.Subject = string.Format("找回密码邮件");
             emailer.Body = string.Format(@"<html><body>
             您好，{0} ：

            请点击下面的链接来重置您的密码。

            {1}

            如果您的邮箱不支持链接点击，请将以上链接地址拷贝到你的浏览器地址栏中。

            该验证邮件有效期为30分钟，超时请重新发送邮件。

            发件时间：{2}

            此邮件为系统自动发出的，请勿直接回复。

             <p>此邮件为系统邮件，请勿回复！！</p>
             </body>
             </html>", userName, url,DateTime.Now.ToString("Y-m-d H:m:s"));

             try
             {
                 emailer.SendEmail(null);
             }
             catch (Exception ex)
             {
                  MessageBoxTip.Alert(this,ex.Message );
                
             }

            MessageBoxTip.Alert(this, "找回密码的链接已经发送到您的邮箱，请注意查收！");
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}