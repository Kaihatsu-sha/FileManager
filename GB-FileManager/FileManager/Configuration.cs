using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileManager
{
    public class Configuration<T> where T : IConfiguration
    {
        string _path;

        public Configuration(string fileName)
        {
            _path = Directory.GetCurrentDirectory() + "\\configuration\\" + fileName;

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\configuration"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\configuration");
            }
        }

        public void Load(ref T configuration)
        {
            if (!File.Exists(_path))
            {
                configuration.DepthLevel = 1;
                configuration.PageSize = 15;
                configuration.CurrentDirectory = Directory.GetCurrentDirectory();
                Save(ref configuration);

                return;
            }

            string configData = File.ReadAllText(_path);
            configuration = JsonSerializer.Deserialize<T>(configData);
        }

        public void Save(ref T configuration)
        {
            string data = JsonSerializer.Serialize<T>(configuration);
            File.WriteAllText(_path, data);
        }
    }
}
