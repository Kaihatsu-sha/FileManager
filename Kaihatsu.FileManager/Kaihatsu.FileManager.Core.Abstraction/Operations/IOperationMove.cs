﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Operations
{
    public interface IOperationMove
    {
        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="sourcePath">исходный путь</param>
        /// <param name="destinationPath">путь назначения</param>
        public void Move(string sourcePath, string destinationPath);
    }
}
