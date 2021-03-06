﻿using System;
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
using System.Collections.Generic;
namespace CMS.Web.Admin.News
{
    public partial class Modify : CommonPage
    {
        protected string CurrentCategory { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int id = (Convert.ToInt32(Request.Params["id"]));
                    BindAttribute();
                    ShowInfo(id);
                }
            }


        }

        public void BindAttribute()
        {

            #region 初始化文章属性
            CMS.BLL.Attribute groupBLL = new CMS.BLL.Attribute();
            //★★与表的数据绑定★★
            this.ArticleAttribute.DataSource = groupBLL.GetAllList();//设置数据源
            ArticleAttribute.DataTextField = "name";//设置所要读取的数据表里的列名
            ArticleAttribute.DataValueField = "id";
            ArticleAttribute.DataBind();//数据绑定
            #endregion


        }

        private void setChecked(CheckBoxList list, List<int> checkedList)
        {
            foreach (var item in list.Items)
            {
                var item2 = item as ListItem;
                int currentItem2 = int.Parse(item2.Value);
                if (checkedList.Contains(currentItem2))
                {
                    item2.Selected = true;
                }
               
            }
        }

        private void ShowInfo(int id)
        {
            CMS.BLL.News bll = new CMS.BLL.News();
            CMS.Model.News model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write("找不到此信息");
                Response.End();
            }
            CMS.Model.User user = ((MasterPage)this.Master).user;
            if (!isManageGroup())
            {
                if (model.userId != user.id)
                {
                    Response.Write("你无权修改此信息！");
                    Response.End();

                }
            }
            this.lblid.Text = model.id.ToString();
            this.txttitle.Text = model.title;
            this.txtsource.Text = model.source;

            this.txtcontent.Text = model.content;
            this.txtkeywords.Text = model.keywords;
            this.txtdescription.Text = model.description;
            this.txtaddTime.Text = model.addTime.Value.ToString("yyyy-MM-dd H:m:s");
            //this.txtcategory.Text=model.category.ToString();
            //this.txtrecommend.se=model.recommend.ToString();
            CurrentCategory = model.category.ToString();
            ListItem recommendItem = txtrecommend.Items.FindByValue(model.recommend.ToString());
            if (recommendItem != null)
            {
                recommendItem.Selected = true;
            }

            IsSwitch.Checked = model.isSwitch;
            CMS.BLL.News_Attribute news_Attribute_bll = new BLL.News_Attribute();
            List<int> checkedList=news_Attribute_bll.GetAttribute(id);
            setChecked(this.ArticleAttribute, checkedList);



            //this.txtuserId.Text = "1";
            //this.chkisDel.Checked=model.isDel;
            //this.txthit.Text=model.hit.ToString();

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // your codes.
            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;

            ListItem item = currentCategory.Items.FindByValue(CurrentCategory);
            if (item != null)
            {
                item.Selected = true;
            }

        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";

            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            DropDownList currentCategory = Category1.FindControl("CategoryList") as DropDownList;

            if (currentCategory.SelectedValue == "0")
            {
                strErr += "请选择栏目！\\n";
            }

            if (this.txtcontent.Text.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }

            if (!PageValidate.IsDateTime(txtaddTime.Text))
            {
                strErr += "时间格式错误！\\n";
            }


            if (strErr != "")
            {
                MessageBoxTip.Alert(this, strErr);
                return;
            }

            int id = int.Parse(this.lblid.Text);
            string title = this.txttitle.Text;
            string source = this.txtsource.Text;

            string content = this.txtcontent.Text;
            string titleImage = titleImage = HtmlHelper.GetAllImgUrl(content, true);

            string keywords = this.txtkeywords.Text;
            string description = this.txtdescription.Text;
            DateTime addTime = DateTime.Parse(this.txtaddTime.Text);
            int category = int.Parse(currentCategory.SelectedValue);
            int recommend = int.Parse(this.txtrecommend.SelectedValue);
            bool isSwitch = IsSwitch.Checked;



            //CMS.Model.News model=new CMS.Model.News();
            CMS.BLL.News bll = new CMS.BLL.News();
            CMS.Model.News model = bll.GetModel(id);
            //model.id=id;
            model.title = title;
            model.source = source;
            model.titleImage = titleImage;
            model.content = content;
            model.keywords = keywords;
            model.description = description;
            model.addTime = addTime;
            model.category = category;
            model.recommend = recommend;
            model.isSwitch = isSwitch;
            //model.userId=userId;
            //model.isDel=isDel;
            //model.hit=hit;

            //CMS.BLL.News bll=new CMS.BLL.News();
         

            if (bll.Update(model))
            {

                System.Collections.Generic.List<int> attributes = new System.Collections.Generic.List<int>();
                foreach (var item in ArticleAttribute.Items)
                {
                    var item2 = item as ListItem;
                    if (item2.Selected)
                    {
                        attributes.Add(int.Parse(item2.Value));
                    }
                }

                if (attributes.Count > 0)
                {
                    CMS.BLL.News_Attribute attributeBll = new BLL.News_Attribute();
                    attributeBll.Add(id, attributes);
                }
                MessageBoxTip.AlertAndRedirect(this, "保存成功！", "List.aspx");
            }

          

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
