using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;
namespace tk.tingyuxuan.utils
{
    public class MyCache
    {
        public string Path { set; get; }
        public int CacheTime { set; get; }
        public void SetCache(object value)
        {
            if (!File.Exists(Path))
            {
                FileStream fs = File.Create(Path);
                fs.Close();
            }
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.StreamWriter swBinary = new System.IO.StreamWriter(Path);
            bf.Serialize(swBinary.BaseStream, value);
            swBinary.Close();
        }

        public object GetCache()
        {
            object obj = null;
            if (File.Exists(Path))
            {
                FileInfo fi = new FileInfo(Path);
                if (fi.LastWriteTime.AddSeconds(CacheTime) > DateTime.Now)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    System.IO.StreamReader srBinary = new System.IO.StreamReader(Path);
                    obj = bf.Deserialize(srBinary.BaseStream);
                    srBinary.Close();
                }
            }
            return obj;
        }

    }
}
