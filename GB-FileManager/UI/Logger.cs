using System;
using System.IO;

namespace UI
{
    public class Logger
    {
        readonly string _path;
        public Logger()
        {            
            _path = Directory.GetCurrentDirectory() + "\\errors";
            Directory.CreateDirectory(_path);
        }

        public void Write(string fileName, string data)
        {
            File.AppendAllText(_path + "\\" + fileName, DateTime.Now.ToLongTimeString() + "\n" + data);
        }
    }
}
