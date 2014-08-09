using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


namespace CMS.Web.Admin
{
    public partial class Tip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitTip();
        }



        protected void InitTip()
        {
            //显示程序中的错误码
            if (!IsPostBack)
            {
                //显示程序中的错误码
                if (Application["error"] != null)
                {
                    string tips = Application["error"].ToString();// +",用户名不能为空,密码不能为空,";
                    string[] tipArray=tips.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    TipList.DataSource = tipArray;
                    TipList.DataBind();
                    
                }
            }
        }
    }
}