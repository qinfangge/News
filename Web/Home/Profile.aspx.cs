using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Home
{
    public partial class Profile : System.Web.UI.Page
    {
        protected CMS.Model.User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user=Session["user"] as CMS.Model.User;
            if (!IsPostBack)
            {
                CMS.BLL.Avatar bll = new BLL.Avatar();
                CMS.Model.Avatar avatar = bll.GetAvatarByUserID(user.id);
                this.Avatar.Value = avatar.id.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //CMS.Model.User user = new Model.User();
            //user.id = 1;
            //user.userName = "qinfangge";
            //user.email = "fqmhw@qq.clm";
            //user.password = "132";

            string userName=NickName.Text.Trim();
            string password = Password.Text.Trim();
            string email = Email.Text.Trim();
            if (userName != "")
            {
                user.userName = userName;
            }
            if (password != "")
            {
                user.password = userName;
            }
            if (email != "")
            {
                user.email = email;
            }

            CMS.BLL.User bll = new BLL.User();
            if (bll.Update(user))
            {
                tk.tingyuxuan.utils.MessageBoxTip.Alert(this, "保存成功！");
            }
            else
            {
                tk.tingyuxuan.utils.MessageBoxTip.Alert(this, "网络繁忙，请稍后重试！");
            }

        }
    }
}