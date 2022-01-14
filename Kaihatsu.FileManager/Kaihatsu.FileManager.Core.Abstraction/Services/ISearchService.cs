using Kaihatsu.FileManager.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface ISearchService
    {
        void ConfigureSession(string path, bool useSubdirectories);
        IQueryable<ItemBase> Search(string pattern);
    }
}
