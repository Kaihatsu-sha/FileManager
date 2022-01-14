using Kaihatsu.FileManager.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface INavigationService
    {
        public bool CanTheUp { get; }
        public string Path { get; }

        public FolderInfoItem GetParent();
        public bool CheckingPath(string path);
    }
}
