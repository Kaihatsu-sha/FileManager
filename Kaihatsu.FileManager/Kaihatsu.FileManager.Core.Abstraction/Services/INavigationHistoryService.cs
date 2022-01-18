using Kaihatsu.FileManager.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface INavigationHistoryService<T> 
        where T : FolderInfoItem
    {
        public bool CanGetPrevious { get; }
        public T GetPrevious();

        public void AddToHistory(T item);
    }
}
