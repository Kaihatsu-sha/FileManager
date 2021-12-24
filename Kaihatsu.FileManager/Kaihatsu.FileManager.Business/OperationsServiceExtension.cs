using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business
{
    public static class OperationsServiceExtension
    {
        public static IOperationsFactoryService CreateFactory(this OperationsFactory factory, FileInfoBase file)
        {
            if (file.Type == FileType.Folder)//Directory
                return new FolderOperationsService(file);
            else//File
                return new FileOperationsService(file); ;
        }
    }
}