using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business
{
    public class FolderOperationsService : IOperationsFactoryService
    {
        private readonly DirectoryInfo _directory;

        public FolderOperationsService(FileInfoBase file)
        {
            _directory = new DirectoryInfo(file.FullPath);
        }

        public void Create(string name)
        {
            _directory.CreateSubdirectory(name);
        }

        public void Delete()
        {
            _directory.Delete(true);
        }

        public void Move(string path)
        {
            _directory.MoveTo(path);
        }

        public void Rename(string name)
        {
            throw new NotImplementedException();
        }
    }
}
