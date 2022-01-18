using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Operations
{
    public interface IOperationRename
    {
        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="sourcePath">исходный путь</param>
        /// <param name="newName">новое имя файла</param>
        public void Rename(string sourcePath, string newName);
    }
}
