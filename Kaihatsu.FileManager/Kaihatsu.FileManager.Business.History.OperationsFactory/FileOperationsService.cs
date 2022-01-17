using Kaihatsu.FileManager.Core.Abstraction.Operations;
using Kaihatsu.FileManager.Core.Abstraction.Services;

namespace Kaihatsu.FileManager.Business.History.OperationsFactory
{
    internal class FileOperationsService : IOperationsService
    {
        public void Create(string path)
        {
            File.Create(path); 
        }

        public void Delete(string path, bool recursive)
        {
            File.Delete(path);
        }

        public void Copy(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);
        }

        public void Move(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        public void Rename(string sourcePath, string newName)
        {
            FileInfo sourceFile = new FileInfo(sourcePath);
            string fullPath = sourceFile.DirectoryName;
            string path = Path.Combine(fullPath, newName);
            sourceFile.MoveTo(path);
        }
    }
}