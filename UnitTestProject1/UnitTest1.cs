using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tk.tingyuxuan.utils;
using CMS.BLL;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Utils;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CMS.BLL.SinglePage singlePageBll = new SinglePage();
            var result=singlePageBll.GetAllList();
            MyCache myCache = new MyCache();
            myCache.Path=@"C:\data.das";
            myCache.SetCache(result);
        }

        [TestMethod]
        public void GetCache()
        {
            
            MyCache myCache = new MyCache();
            myCache.Path = @"C:\data.das";
            Console.WriteLine(myCache.GetCache());
        }
         [TestMethod]
        public void IPTest()
        {
            string ip = "58.247.46.186";//Request.ServerVariables.Get("REMOTE_ADDR");//自动获取用户IP 
            //string ip = TextBox1.Text.Trim(); 
            if (ip == string.Empty) return;
            IPSeeker seeker = new IPSeeker(@"E:\projects\网站建设\新闻\News\Web\App_Data\QQWry.Dat");//纯真IP地址库存放目录！！
            System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(ip);
            IPLocation loc = seeker.GetLocation(ipaddr);
            if (loc == null)
            {
                Console.Write("指定的IP地址无效！");
            }
            Console.Write("地址:" + loc.Country + loc.Zone);
        }



        [TestMethod]
        public void TestMd5()
        {
               //欲进行md5加密的字符串
            string test = "123abc";

            //获取加密服务  
            System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //获取要加密的字段，并转化为Byte[]数组  
            byte[] testEncrypt = UTF8Encoding.Default.GetBytes(test);
            
            //加密Byte[]数组  
            byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);

            //将加密后的数组转化为字段(普通加密)  
            string testResult = UTF8Encoding.Default.GetString(resultEncrypt);  

           testResult= BitConverter.ToString(resultEncrypt).Replace("-", "");

            Console.WriteLine(testResult);
            //作为密码方式加密
            string EncryptPWD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(test, "MD5");
            Console.WriteLine(EncryptPWD);
        }
    }
}





