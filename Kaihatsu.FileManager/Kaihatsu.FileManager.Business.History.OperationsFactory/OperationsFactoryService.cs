using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.History.OperationsFactory
{
    internal class OperationsFactoryService : IOperationsFactoryService
    {
        public IOperationsService CreateFileFactory()
        {
            return new FileOperationsService();
        }

        public IOperationsService CreateFolderFactory()
        {
            return new FolderOperationsService();
        }
    }
}
