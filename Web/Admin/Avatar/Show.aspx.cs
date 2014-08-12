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
namespace CMS.Web.Avatar
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
		CMS.BLL.Avatar bll=new CMS.BLL.Avatar();
		CMS.Model.Avatar model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblpicPath.Text=model.picPath;
		this.lbladdTime.Text=model.addTime.ToString();
		this.lbluserID.Text=model.userID.ToString();

	}


    }
}
