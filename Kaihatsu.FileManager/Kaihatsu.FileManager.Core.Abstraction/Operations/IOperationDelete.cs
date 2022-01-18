using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Operations
{
    public interface IOperationDelete
    {
        /// <summary>
        /// Удаляет файлы
        /// </summary>
        /// <param name="path">пусть</param>
        /// <param name="recursive">рекурсивное удаление, только для папок</param>
        public void Delete(string path, bool recursive);
    }
}
