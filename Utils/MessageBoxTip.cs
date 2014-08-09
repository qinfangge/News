using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace tk.tingyuxuan.utils
{
    public class MessageBoxTip
    {
        public static void Alert(Page page ,string message)
        {
            string script=@"window.onload=function()
            {
                alert("""+message+@""");
            }";
            page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", script, true);
           
        }

        public static void AlertAndRedirect(Page page, string message, string url)
        {
            string script = @"window.onload=function()
            {
                alert(""" + message + @""");
                window.location.href="""+url+@""";
            }";
            page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndRedirect", script, true);
        }

    }
}
