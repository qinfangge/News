using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitContact();
            }
        }

        #region 初始化尾部
        private void InitContact()
        {

            CMS.Web.Admin.Contact.Contact contact = new CMS.Web.Admin.Contact.Contact();
            CMS.Model.Contact siteContact = contact.ReadContact();

            Mobile.Text = siteContact.Phone;
            QQ.Text = siteContact.QQ;
            Zip.Text = siteContact.Zip;
            Address.Text = siteContact.Address;
            Contactor.Text = siteContact.Contactor;
            Fax.Text = siteContact.Fax;


        }
        #endregion
    }
}