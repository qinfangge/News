using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace tk.tingyuxuan.utils
{
    public class HtmlHelper
    {
        /// <summary>
        /// 根据图片路径生成img 标签
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="alt"></param>
        /// <returns></returns>
        public static string GetImageHtmlByPath(string imagePath, string alt = "", string host = "")
        {
            return string.Format("<img src=\"{2}{0}\" alt=\"{1}\"/>", imagePath, alt, host);

        }
        /// <summary>
        /// 根据flash文件路径生成flash 标签
        /// </summary>
        /// <param name="flashPath">flash路径</param>
        /// <returns></returns>
        public static string GetFlashHtmlByPath(string flashPath, int width = 200, int height = 100, string host = "")
        {
        /* return string.Format(@"<object  data=""{3}{0}"" width=""{1}px"" height=""{2}px"">
         <param value=""always"" name=""allowscriptaccess"">
         <param value=""opaque"" name=""wmode"">
         <param value=""high"" name=""quality"">
         <param name=""movie"" value=""{3}{0}"">
         <param value=""application/x-shockwave-flash"" name=""type"">
         <embed src=""{3}{0}""/>
         </object>", flashPath,width,height,host);*/
        http://www.paifun.net/789/20111230/151827335875%20_633.swf
            return string.Format(@"<embed width=""{1}px"" height=""{2}px"" src=""{3}{0}"" type=""application/x-shockwave-flash"" />", flashPath, width, height, host);


        }

        public static string GetFirstImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>", //注意这里的(?<url>\S+)是按正则表达式中的组来处理的，下面的代码中用使用到，也可以更改成其它的HTML标签，以同样的方法获得内容！
            RegexOptions.Compiled);
            Match m = r.Match(HTMLStr);
            if (m.Success)
                str = m.Result("${url}");
            return str.Trim(new char[] { '"' });
        }

        public static string GetFirstImgUrl(string HTMLStr,bool isRewrite)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>", //注意这里的(?<url>\S+)是按正则表达式中的组来处理的，下面的代码中用使用到，也可以更改成其它的HTML标签，以同样的方法获得内容！
            RegexOptions.Compiled);
            Match m = r.Match(HTMLStr);
            if (m.Success)
            {
                str = m.Result("${url}");
            }

            str=str.Trim(new char[] { '"' });

            return GetAttachmentID(str).ToString();
           // return str.Trim(new char[] { '"' });
        }
        //返回多个路径的情况
        public static string GetAllImgUrl(string text)
        {
            StringBuilder str = new StringBuilder();
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";

            Regex r = new Regex(pat, RegexOptions.Compiled);
            Match m = r.Match(text);
            //int matchCount = 0;
            while (m.Success)
            {
                Group g = m.Groups[2];
                str.Append(g).Append(",");
                
                m = m.NextMatch();
            }
            return str.ToString().Replace("\"", "");
        }

        //返回多个路径的情况
        public static string GetAllImgUrl(string text,bool isRewrite)
        {
            StringBuilder str = new StringBuilder();
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";

            Regex r = new Regex(pat, RegexOptions.Compiled);
            Match m = r.Match(text);
            //int matchCount = 0;
            while (m.Success)
            {
                Group g = m.Groups[2];
                //str.Append(g).Append(",");
                str.Append(GetAttachmentID(g.ToString())).Append("|");
                m = m.NextMatch();
            }

            return str.ToString().Replace("\"", "");
        }

        private static int GetAttachmentID(string rewriteUrl)
        {
            string oldString = oldString = @"(.*)/pic/(.*).jpg";

            System.Text.RegularExpressions.Regex oReg = new System.Text.RegularExpressions.Regex(oldString);
          
            string base64String = "";
            Match m = oReg.Match(rewriteUrl);
            int id = 0;
            if (m.Success)
            {
                base64String = m.Groups[2].Value;
                string para = System.Text.Encoding.Default.GetString(Convert.FromBase64String(base64String.Replace("%2B", "+")));

                string[] paraArray = para.Split(new string[] { "|" }, StringSplitOptions.None);

                id = int.Parse(paraArray[2]);
                
                
            }

            return id;

        }


        /// <summary>

        /// 去除HTML标记

        /// </summary>

        /// <param name="NoHTML">包括HTML的源码 </param>

        /// <returns>已经去除后的文字</returns>

        public static string NoHTML(string Htmlstring)
        {

            //删除脚本

            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML

            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");

            Htmlstring.Replace(">", "");

            Htmlstring.Replace("\r\n", "");

            Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;

        }

        public static string SubStr(string oldString, int length, bool removeHtml)
        {
            string newStr = "";
            if (removeHtml)
            {
                newStr = NoHTML(oldString);
                newStr = newStr.Length > length ? newStr.Substring(0, length) : newStr;
            }
            else
            {
                newStr = oldString.Length > length ? oldString.Substring(0, length) : oldString;
            }
            return newStr;
        }
        #region 高亮关键字儿
        public static string HightLight(string content, string search, string hightLightClass)
        {

            string result = content.Replace(search, "<font class=\'" + hightLightClass + "\'>" + search + "</font>");

            return result;
        }
        #endregion

        public static void ddlBind(DropDownList ddl, string[] DataText, int[] DataValue)
        {
            for (int i = 0; i < DataText.Length; i++)
            {
                ddl.Items.Add(new ListItem(DataText[i], DataValue[i].ToString()));
            }
        }

        public static void ddlBind(CheckBoxList ddl, string[] DataText, int[] DataValue)
        {
            for (int i = 0; i < DataText.Length; i++)
            {
                ddl.Items.Add(new ListItem(DataText[i], DataValue[i].ToString()));
            }
        }

        public static void ddlBind(RadioButtonList ddl, string[] DataText, int[] DataValue)
        {
            for (int i = 0; i < DataText.Length; i++)
            {
                ddl.Items.Add(new ListItem(DataText[i], DataValue[i].ToString()));
            }
        }



    }


}


