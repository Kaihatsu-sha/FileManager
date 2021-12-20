using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;

namespace Kaihatsu.FileManager.Business
{
    //public class DirectoryInfo : FileMainInfo
    //{

    //}
    public class Operations
    {
        public IEnumerable<FileInfoBase> OpeningDirectory(string path)
        {
            List<FileInfoBase> filesInDerectory = new List<FileInfoBase>();

            if (Directory.Exists(path))
            {
                foreach (var dirPath in Directory.EnumerateDirectories(path))
                {
                    filesInDerectory.Add(new FileInfoBase(dirPath));
                }
                foreach (var dirPath in Directory.EnumerateFiles(path))
                {
                    filesInDerectory.Add(new FileInfoBase(dirPath));
                }

            }

            return filesInDerectory;
        }

        public void DeleteSelectedFile(FileInfoBase file)
        {
            OperationsFactory factory = new OperationsFactory();
            IOperationsFactoryService service = factory.Create(file);
            service.
        }
    }

    public static class OperationDeleteFolderExtension
    {
        public static IOperationsFactoryService Create(this OperationsFactory factory, FileInfoBase file)
        {
            //factory._file.Type
            return new OperationDeleteFolder(file);
        }
    }

    public class OperationDeleteFolder : IOperationsFactoryService
    {
        public OperationDeleteFolder(FileInfoBase file)
        {

        }

        public IDeleteService Delete()
        {
            throw new NotImplementedException();
        }

        public void Move(string path)
        {
            throw new NotImplementedException();
        }
    }
}