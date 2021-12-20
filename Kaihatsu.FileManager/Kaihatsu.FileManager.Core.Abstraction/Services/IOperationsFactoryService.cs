using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface IOperationsFactoryService
    {
        //public void CreateFactory(FileInfoBase file);

        public IDeleteService Delete();

        public void Move(string path);
    }
}
