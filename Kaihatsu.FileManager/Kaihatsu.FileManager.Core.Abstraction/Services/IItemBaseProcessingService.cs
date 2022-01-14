using Kaihatsu.FileManager.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface IItemBaseProcessingService
    {
        public IQueryable<ItemBase> GetAllFromDirection(string path);
        public IQueryable<ItemBase> GetAllFromDirection(string path, bool useSubdirectories);
    }
}
