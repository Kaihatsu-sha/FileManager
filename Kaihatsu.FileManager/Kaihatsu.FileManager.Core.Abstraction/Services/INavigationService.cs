using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface INavigationService : INavigationHistoryService
    {
        public bool CanTheUp { get; }
        public string Path { get; }
        public void GoUp();
        public bool CheckingPath(string path);
        public IQueryable<FileInfoBase> GetAllFromCurrentDirection();
    }
}
