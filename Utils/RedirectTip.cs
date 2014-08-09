using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

   //[Serializable]
   public class RedirectTip
    {
       
        public string TipTitle { get; set; }
        public List<HyperLink> LinkButtons { get; set; }
        public List<string> Tips { get; set; }
        public string ImageIconFileName { get; set; }
    }
