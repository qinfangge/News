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
using Maticsoft.Common;
using LTP.Accounts.Bus;
using tk.tingyuxuan.utils;
namespace CMS.Web.Admin.Notice
{
    public partial class Add : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CMS.Model.User user = Session["user"] as CMS.Model.User;
                if (isManageGroup())
                {
                    Panel1.Visible = true;
                }
            }
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="标题不能为空！\\n"; 
			}
			if(!PageValidate.IsDateTime(txtstartTime.Text))
			{
				strErr+="拍卖时间格式错误！\\n";	
			}
			
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}


            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;
            if (currentCategory.SelectedValue == "0")
            {
                strErr += "请选择栏目！\\n";
            }
			
			

			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			DateTime startTime=DateTime.Parse(this.txtstartTime.Text);

			string content=this.txtcontent.Text;
            string titleImage = HtmlHelper.GetFirstImgUrl(content);
			string keywords=this.txtkeywords.Text;
			string description=this.txtdescription.Text;
            DateTime addTime = DateTime.Now;
            int category = int.Parse(currentCategory.SelectedValue);
            int recommend = int.Parse(this.txtrecommend.SelectedValue);
            CMS.Model.User user = Session["user"] as CMS.Model.User;
            int userId = user.id;
			bool isDel=false;
			int hit=0;
            bool isSwitch = IsSwitch.Checked;


			CMS.Model.Notice model=new CMS.Model.Notice();
			model.title=title;
			model.startTime=startTime;
			model.titleImage=titleImage;
			model.content=content;
			model.keywords=keywords;
			model.description=description;
			model.addTime=addTime;
			model.category=category;
			model.recommend=recommend;
			model.userId=userId;
			model.isDel=isDel;
			model.hit=hit;
            model.isSwitch = isSwitch;

			CMS.BLL.Notice bll=new CMS.BLL.Notice();
			bll.Add(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","Add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
