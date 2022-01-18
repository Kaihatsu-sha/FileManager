using Kaihatsu.FileManager.Core.Abstraction.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface IOperationsService:
        IOperationCreate,
        IOperationDelete,
        IOperationCopy,
        IOperationMove,
        IOperationRename
    {
    }
}
