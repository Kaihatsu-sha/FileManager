using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;

namespace Kaihatsu.FileManager.Business.Navigation
{
    internal class NavigationService : INavigationService
    {
        private FolderInfoItem _folderItem;

        public bool CanTheUp => _folderItem?.Parent is not null ? true : false;//TODO : Проверить когда нет родителя
        public string Path => _folderItem.Path;

        public FolderInfoItem GetParent()//FIX : Подумать Навигация
        {
            if (CanTheUp)
            {
                return _folderItem.Parent;                
            }
            return null;
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

            _folderItem = new FolderInfoItem(path);

            return true;
        }
    }
}