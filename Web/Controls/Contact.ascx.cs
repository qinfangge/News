using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Web.Controls
{
    public partial class Contact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitContact();
        }

        #region 初始化联系方式
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