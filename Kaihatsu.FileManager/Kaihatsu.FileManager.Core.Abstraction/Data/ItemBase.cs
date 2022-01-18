using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Data
{
    public abstract class ItemBase
    {
        public string Path { get; protected set; }
        public string Name { get; protected set; }
        public ItemType Type { get; protected set; }

        public long Size { get; protected set; }

        public string CreationTime { get; protected set; }
        public string LastWriteTime { get; protected set; }

        public override bool Equals(object? obj)
        {
            ItemBase? item = obj as ItemBase;
            if(item is null)
            {
                return false;
            }

            return item.Path == Path;
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }
    }
}
