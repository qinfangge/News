using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tk.tingyuxuan.utils;
using CMS.BLL;
using System.Data;
using System.Security.Cryptography;
using System.Text;
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





