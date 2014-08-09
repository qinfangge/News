using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NamespaceRef
{
    class Program
    {
        static void Main(string[] args)
        {
            string search="113";
            string[] arr=new string[]{"1","2","11"};

            Console.Write(Array.IndexOf(arr, search));

             Country cy;
            String assemblyName = @"NamespaceRef";
            string strongClassName = @"NamespaceRef.Chinese";
           // 注意：这里类名必须为强类名
          // assemblyName可以通过工程的AssemblyInfo.cs中找到
           cy = (Country)Assembly.Load(assemblyName).CreateInstance(strongClassName);
           Console.WriteLine(cy.name);
            Console.ReadKey();
        }
     }

    class Country
    {
        public string name;
     }

    class Chinese : Country
    {
        public Chinese()
        {
             name = "你好";
         }
     }

    class America : Country
    {
        public America()
        {
             name = "Hello";
         }
     }
}