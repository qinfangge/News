using System;
namespace CMS.Model
{
    [Serializable]
    public  class Contact
    {
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string QQ { set; get; }
        public string Fax { set; get; }
        public string Zip { set; get; }
        public string WebSit { set; get; }
        public string Contactor { set; get; }
        public Contact()
        { }
    }
}