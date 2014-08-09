using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tk.tingyuxuan.utils
{
    public class FileUtil
    {
        public string FilePath { get; set; }
        public string Message { get; set; }
        public string ReadText()
        {
            string message = "";
            if (File.Exists(FilePath))
            {
                StreamReader reader = new StreamReader(FilePath);
                message = reader.ReadToEnd();
                reader.Close();
            }
            return message;
        }

        public void WriteText(string message)
        {
            StreamWriter writer = new StreamWriter(FilePath);

            writer.Write(message);
            writer.Close();
        }

        

    }
}
