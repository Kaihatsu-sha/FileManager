using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.History.OperationsFactory
{
    public static class OperationsServiceExtension
    {
        public static IServiceCollection AddOperationsFactory(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IOperationsFactoryService, OperationsFactoryService>();
        }
    }
}
