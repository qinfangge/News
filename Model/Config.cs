using System;
namespace CMS.Model
{
    [Serializable]
    public  class Config
    {
        public string KeyWords { set; get; }
        public string Description { set; get; }
        public string SiteName { set; get; }
        public string Other { set; get; }
        public Config()
        { }
    }
}