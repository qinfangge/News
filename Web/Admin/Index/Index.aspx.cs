using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Admin.Index
{
    public partial class Index : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal UserName = this.Master.FindControl("userName") as Literal;
            Literal1.Text = UserName.Text;
        }
    }
}