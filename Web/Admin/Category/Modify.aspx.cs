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
namespace CMS.Web.Admin.Category
{
    public partial class Modify : CommonPage
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
                    #region 初始化栏目
                    CMS.BLL.Category bll = new CMS.BLL.Category();
                    //★★与表的数据绑定★★
                    txtcategory.DataSource = bll.GetCategoryForSelect(0);//设置数据源
                    txtcategory.DataTextField = "name";//设置所要读取的数据表里的列名
                    txtcategory.DataValueField = "id";
                    txtcategory.DataBind();//数据绑定
                    txtcategory.Items.Insert(0, new ListItem("顶级栏目", "0"));
                    #endregion

					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
                {
                    CMS.BLL.Category bll = new CMS.BLL.Category();
                    CMS.Model.Category model = bll.GetModel(id);
                    if (model == null)
                    {
                        Response.Write("找不到此信息");
                        Response.End();
                    }
                    this.lblid.Text = model.id.ToString();
                    this.txtname.Text = model.name;
                    //this.txtpid.Text=model.pid.ToString();
                    this.txtkeywords.Text = model.keywords;
                    this.txtdescription.Text = model.description;

                    this.txtsort.Text = model.sort.ToString();
                    ListItem currentItem = txtcategory.Items.FindByValue(model.id.ToString());
                    if(currentItem!=null)
                    {
                        txtcategory.Items.Remove(currentItem);
                    }
                    ListItem item = txtcategory.Items.FindByValue(model.pid.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }

                }

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
                strErr += "栏目名称不能为空！\\n";	
			}
			
			if(!PageValidate.IsNumber(txtsort.Text))
			{
                strErr += "序号格式错误！，请输入1，2，3...\\n";	
			}



			if(strErr!="")
			{
				MessageBoxTip.Alert(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
            CMS.BLL.Category bll = new CMS.BLL.Category();
          
			string name=this.txtname.Text;
            int pid = int.Parse(txtcategory.SelectedValue);
			int sort=int.Parse(this.txtsort.Text);
            string keywords = this.txtkeywords.Text;
            string description = this.txtdescription.Text;

			CMS.Model.Category model=new CMS.Model.Category();
			model.id=id;
			model.name=name;
			model.pid=pid;
			model.sort=sort;
            model.keywords = keywords;
            model.description = description;

			
			bll.Update(model);
			MessageBoxTip.AlertAndRedirect(this,"保存成功！","List.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
