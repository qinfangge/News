using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Model;
using Maticsoft.Common;
using tk.tingyuxuan.utils;

namespace CMS.Web.Admin.Contact
{
    public partial class Contact :  CommonPage
    {
        private string ContactPath { set; get; }

        public Contact()
        {
            ContactPath = "~/App_Data/Contact.txt";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CMS.Model.Contact contact = this.ReadContact();
                Contactor.Text = contact.Contactor;
                Phone.Text = contact.Phone;
                Fax.Text = contact.Fax;
                Email.Text = contact.Email;
                QQ.Text = contact.QQ;
                Zip.Text = contact.Zip;
                WebSite.Text = contact.WebSit;
                Address.Text = contact.Address;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CMS.Model.Contact contact = new CMS.Model.Contact();
            contact.Contactor = Contactor.Text;
            contact.Phone = Phone.Text;
            contact.Fax = Fax.Text;
            contact.QQ = QQ.Text;
            contact.Email = Email.Text;
            contact.Zip = Zip.Text;
            contact.WebSit = WebSite.Text;
            contact.Address = Address.Text;
            WriteContact(contact);
            MessageBoxTip.Alert(this, "保存成功！");
        }

        public  void WriteContact(CMS.Model.Contact contact)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(contact);
                StreamWriter writer = File.CreateText(Server.MapPath(ContactPath));
                writer.Write(result);
               // writer.Close();
                writer.Dispose();
                
            }
            catch (Exception ex)
            {
                throw new Exception("保存出错了，请重试！原因：" + ex.Message);
            }
        }

        public CMS.Model.Contact ReadContact()
        {
            CMS.Model.Contact contact = new CMS.Model.Contact();
            try
            {
                StreamReader reader = File.OpenText(Server.MapPath(ContactPath));
                string str = reader.ReadToEnd();
                //reader.Close();
                reader.Dispose();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                contact = serializer.Deserialize<CMS.Model.Contact>(str);
            }
            catch (Exception ex)
            {
                throw new Exception("读取联系方式出错了！原因："+ex.Message);
            }

            return contact;
        }

    }
}