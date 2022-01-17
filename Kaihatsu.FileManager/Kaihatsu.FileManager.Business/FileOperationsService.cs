//using Kaihatsu.FileManager.Core.Abstraction;
//using Kaihatsu.FileManager.Core.Abstraction.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Kaihatsu.FileManager.Business
//{
//    internal class FileOperationsService// : IOperationsFactoryService
//    {
//        private readonly FileInfo _file;

//        public FileOperationsService(FileInfoBase file)
//        {
//            _file = new FileInfo(file.FullPath);
//        }

//        public void Create(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete()
//        {
//            _file.Delete();
//        }

//        public void Move(string path)
//        {
//            _file.MoveTo(path);
//        }

//        public void Rename(string name)
//        {
//            string fullPath = _file.DirectoryName;
//            string path = Path.Combine(fullPath, name);
//            _file.MoveTo(path);
//        }

//        public void Copy(string path)
//        {
//            _file.CopyTo(path, false);
//        }
//    }
//}
