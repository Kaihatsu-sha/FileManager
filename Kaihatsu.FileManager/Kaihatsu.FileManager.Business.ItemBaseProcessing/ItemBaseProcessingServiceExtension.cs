using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.ItemBaseProcessing
{
    public static class ItemBaseProcessingServiceExtension
    {
        public static IServiceCollection AddProcessing(this IServiceCollection collection)
        {
            return collection.AddScoped<IItemBaseProcessingService, ItemBaseProcessingService>();
        }
    }
}
