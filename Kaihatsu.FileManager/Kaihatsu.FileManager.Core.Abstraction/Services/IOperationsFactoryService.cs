using Kaihatsu.FileManager.Core.Abstraction.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface IOperationsFactoryService
    {//FIX: Продумать механизм. Не всегда нужно создавать все операции!!!
        IOperationsService CreateFileFactory();
        IOperationsService CreateFolderFactory();
        //IOperationCreate OperationCreate();
        //IOperationDelete OperationDelete();
        //IOperationMove OperationMove();
        //IOperationRename OperationRename();
        //IOperationCopy OperationCopy();

    }
}
