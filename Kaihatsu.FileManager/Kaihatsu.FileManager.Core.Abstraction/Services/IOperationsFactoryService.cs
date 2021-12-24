using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface IOperationsFactoryService
    {
        public void Create(string name);
        public void Delete();
        public void Rename(string name);
        public void Move(string path);
    }
}
