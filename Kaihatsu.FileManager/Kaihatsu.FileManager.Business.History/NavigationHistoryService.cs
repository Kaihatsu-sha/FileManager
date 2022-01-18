using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;

namespace Kaihatsu.FileManager.Business.History
{
    internal class NavigationHistoryService<T> : INavigationHistoryService<T>
        where T : FolderInfoItem
    {
        //Кладем на верх каждый открытый путь. Получается первый всегда мимо!
        private Stack<T> _navigationHistory = new Stack<T>();
        private T _lastItem;

        public bool CanGetPrevious => _navigationHistory.Count >= 1 ? true : false;

        public T GetPrevious()
        {
            if (!CanGetPrevious)
            {
                throw new ArgumentNullException();
            }
            _lastItem = _navigationHistory.Pop();
            return _lastItem;
        }

        public void AddToHistory(T item)
        {
            if (_lastItem is null)
            {
                _lastItem = item;
                return;
            }

            if (!_lastItem.Equals(item))
            {
                _navigationHistory.Push(_lastItem);
            }

            _lastItem = item;
        }
    }
}