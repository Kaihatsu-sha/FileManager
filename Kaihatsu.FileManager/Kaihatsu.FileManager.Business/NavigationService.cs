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

        public bool CanOpenPrevious
        {
            get
            {//FIX : Подумать История
                bool rezult = false;

                if (_navigationHistory.Count > 1)
                {
                    DirectoryInfo directory = _navigationHistory.Pop();
                    directory = _navigationHistory.Peek();
                    if (directory != _currentDirectoryInfo)
                    {
                        rezult = true;
                    }
                }
                
                return rezult;
            }
        }
        public bool GoUp()//FIX : Подумать Навигация
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
            if (_currentDirectoryInfo != directory)//FIX : Подумать История
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


        public void OpenPrevious()
        {
            if (CanOpenPrevious)
            {
                DirectoryInfo directory = _navigationHistory.Pop();
                GoPath(directory.FullName);
            }
        }
    }
}
