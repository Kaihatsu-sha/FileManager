using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business
{
    public class NavigationService// : INavigationService
    {
        private DirectoryInfo _currentDirectoryInfo;

        public bool CanTheUp => _currentDirectoryInfo?.Parent is not null ? true : false;//TODO : Проверить когда нет родителя
        public string Path => _currentDirectoryInfo.FullName;

        public void GoUp()//FIX : Подумать Навигация
        {
            if (CanTheUp)
            {
                CheckingPath(_currentDirectoryInfo.Parent.FullName);
            }
        }

        public bool CheckingPath(string path)
        {
            if (path is null || path.Length == 0)
            {
                path = Directory.GetCurrentDirectory();
            }

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Не корректный путь к папке");
            }

            DirectoryInfo directory = new DirectoryInfo(path);
            _currentDirectoryInfo = directory;

            return true;
        }

        //public IQueryable<FileInfoBase> GetAllFromCurrentDirection()
        //{
        //    List<FileInfoBase> filesInDerectory = new List<FileInfoBase>();

        //    foreach (var dirPath in Directory.EnumerateDirectories(_currentDirectoryInfo.FullName))
        //    {
        //        filesInDerectory.Add(new FileInfoBase(dirPath));
        //    }
        //    foreach (var dirPath in Directory.EnumerateFiles(_currentDirectoryInfo.FullName))
        //    {
        //        filesInDerectory.Add(new FileInfoBase(dirPath));
        //    }

        //    return filesInDerectory.AsQueryable();
        //}

        
    }
}
