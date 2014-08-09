using System;
using System.IO;
using System.Text;
namespace tk.tingyuxuan.utils
{
    public class Logger
    {
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="message">向文件写入的内容</param>
        /// <param name="filePath">日志文件的路径</param>
        //public static void Log(string message, string filePath="logger.txt")
        //{
        //    StreamWriter sr = new StreamWriter(filePath, true,Encoding.Default);
        //    DateTime dateTime =DateTime.Now;
        //    string splitString = "----------------------------------------------------------------";
        //    string exceptionMessage = string.Format("{0}异常如下:{0}{0}{1}{0}{0}-----抛出时间：{2}{0}{3}", Environment.NewLine, message, dateTime, splitString);
        //    sr.Write(exceptionMessage);
        //    sr.Flush();
        //    sr.Close();
        //}


    }
}