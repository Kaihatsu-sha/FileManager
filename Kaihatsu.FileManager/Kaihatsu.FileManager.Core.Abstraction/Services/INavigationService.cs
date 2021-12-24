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
        public bool GoUp();
        public bool GoPath(string? path);
        public IEnumerable<FileInfoBase> GetAll();
    }
}
