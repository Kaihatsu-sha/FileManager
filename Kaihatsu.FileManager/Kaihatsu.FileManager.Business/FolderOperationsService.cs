//using Kaihatsu.FileManager.Core.Abstraction;
//using Kaihatsu.FileManager.Core.Abstraction.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Kaihatsu.FileManager.Business
//{
//    public class FolderOperationsService : IOperationsFactoryService
//    {
//        private readonly DirectoryInfo _directory;

//        public FolderOperationsService(FileInfoBase file)
//        {
//            _directory = new DirectoryInfo(file.FullPath);
//        }

//        public void Create(string name)
//        {
//            _directory.CreateSubdirectory(name);
//        }

//        public void Delete()
//        {
//            _directory.Delete(true);
//        }

//        public void Move(string path)
//        {
//            _directory.MoveTo(path);
//        }

//        public void Rename(string name)
//        {            
//            string path = _directory.FullName.Replace(_directory.Name, name);
//            _directory.MoveTo(path);
//        }

//        public void Copy(string path)
//        {

//            DirectoryInfo copyDirectory = new DirectoryInfo(Path.Combine(path,_directory.Name));//Создали папку назначения
//            DirectoryInfo[] allDirectories = _directory.GetDirectories("", SearchOption.AllDirectories);
//            FileInfo[] allFiles = _directory.GetFiles("", SearchOption.AllDirectories);
//            foreach (DirectoryInfo directory in allDirectories)
//            {
//                string oldPath = directory.FullName;//.Replace(_directory.FullName, copyDirectory.FullName);
//                string newPath = oldPath.Replace(_directory.FullName, copyDirectory.FullName);

//                Directory.CreateDirectory(newPath);
//            }

//            foreach (FileInfo file in allFiles)
//            {
//                string oldPath = file.FullName;
//                string newPath = oldPath.Replace(_directory.FullName, copyDirectory.FullName);

//                File.Copy(file.FullName, newPath);
//            }
//        }
//    }
//}
