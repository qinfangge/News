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
namespace CMS.Web.MainNav
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		CMS.BLL.MainNav bll=new CMS.BLL.MainNav();
		CMS.Model.MainNav model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbllink.Text=model.link;
		this.lblname.Text=model.name;
		this.lbltarget.Text=model.target?"是":"否";

	}


    }
}
