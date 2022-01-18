using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Operations
{
    public interface IOperationCreate
    {
        /// <summary>
        /// Создает объект по пути. Для файлов указывается расширение
        /// </summary>
        /// <param name="path">путь</param>
        public void Create(string path);
    }
}
