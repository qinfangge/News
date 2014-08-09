using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Model
{
    class Article
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Page { set; get; }
        public string TitleImage { set; get; }
        public int IsSwitch { set; get; }
    }
}
