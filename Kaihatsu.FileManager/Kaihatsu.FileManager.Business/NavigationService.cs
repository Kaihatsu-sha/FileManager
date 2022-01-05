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
        private DirectoryInfo _currentDirectoryInfo;
        private Stack<DirectoryInfo> _navigationHistory = new Stack<DirectoryInfo>();

        public bool CanTheUp => _currentDirectoryInfo?.Parent is not null ? true : false;//TODO : Проверить когда нет родителя
        public string Path => _currentDirectoryInfo.FullName;

        public bool CanOpenPrevious => _navigationHistory.Count >= 1 ? true : false;

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
            AddingDirectoryToHistory(directory);
            _currentDirectoryInfo = directory;

            return true;
        }

        public IQueryable<FileInfoBase> GetAllFromCurrentDirection()
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

            return filesInDerectory.AsQueryable();
        }

        public void OpenPrevious()
        {
            if (!CanOpenPrevious)
            {
                return; 
            }

            _currentDirectoryInfo = _navigationHistory.Pop();
        }

        private void AddingDirectoryToHistory(DirectoryInfo directory)//FIX : Подумать История
        {
            if (_currentDirectoryInfo is null)
            {
                return;
            }
            
            if (!CanOpenPrevious)
            {
                _navigationHistory.Push(_currentDirectoryInfo);
                return;
            }

            if (_navigationHistory.Peek() != directory)
            {
                _navigationHistory.Push(_currentDirectoryInfo);
            }
        }
    }
}
