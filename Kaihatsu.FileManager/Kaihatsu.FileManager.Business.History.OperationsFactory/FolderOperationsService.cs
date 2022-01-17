using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.History.OperationsFactory
{
    internal class FolderOperationsService: IOperationsService
    {
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void Delete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        public void Move(string sourcePath, string destinationPath)
        {
            Directory.Move(sourcePath, destinationPath);
        }

        public void Rename(string sourcePath, string newName)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            string path = sourcePath.Replace(sourceDirectory.Name, newName);
            Directory.Move(sourcePath, path);
        }

        public void Copy(string sourcePath, string destinationPath)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            DirectoryInfo copyDirectory = new DirectoryInfo(Path.Combine(destinationPath, sourceDirectory.Name));

            DirectoryInfo[] allDirectories = sourceDirectory.GetDirectories("", SearchOption.AllDirectories);
            FileInfo[] allFiles = sourceDirectory.GetFiles("", SearchOption.AllDirectories);
            foreach (DirectoryInfo directory in allDirectories)
            {
                string oldPath = directory.FullName;
                string newPath = oldPath.Replace(sourceDirectory.FullName, copyDirectory.FullName);

                Directory.CreateDirectory(newPath);
            }

            foreach (FileInfo file in allFiles)
            {
                string oldPath = file.FullName;
                string newPath = oldPath.Replace(sourceDirectory.FullName, copyDirectory.FullName);

                File.Copy(file.FullName, newPath);
            }
        }
    }
}
