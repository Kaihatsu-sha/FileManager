using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business
{
    public class NavigationService : INavigationService, INavigationHistoryService
    {
        private DirectoryInfo _currentDirectoryInfo = null;
        private Stack<DirectoryInfo> _navigationHistory = new Stack<DirectoryInfo>();
        //TODO : Ошибка, добавляется дважды, проверка на null

        public bool CanTheUp
        {
            get
            {
                return _currentDirectoryInfo?.Parent is not null ? true : false;
            }
        }

        public string Path
        {
            get
            {
                return _currentDirectoryInfo.FullName;
            }
        }

        public bool GoUp()//FIX : Подумать
        {
            if (CanTheUp)
            {
                _currentDirectoryInfo = _currentDirectoryInfo.Parent;
                return true;
            }
            return false;
        }

        public bool GoPath(string? path)
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
            if (_currentDirectoryInfo is not null)//For first open/default open
            {
                _navigationHistory.Push(directory);
            }
            _currentDirectoryInfo = directory;

            return true;
        }

        public IEnumerable<FileInfoBase> GetAll()
        {
            List<FileInfoBase> filesInDerectory = new List<FileInfoBase>();

            foreach (var dirPath in Directory.EnumerateDirectories(_currentDirectoryInfo.FullName))
            {
                filesInDerectory.Add(new FileInfoBase(dirPath));
            }
            foreach (var dirPath in Directory.EnumerateFiles(_currentDirectoryInfo.FullName))
            {
                filesInDerectory.Add(new FileInfoBase(dirPath));
            }

            return filesInDerectory;
        }


        public IEnumerable<FileInfoBase> OpenPrevious()
        {
            _currentDirectoryInfo = _navigationHistory.Pop();
            return GetAll();
        }
    }
}
