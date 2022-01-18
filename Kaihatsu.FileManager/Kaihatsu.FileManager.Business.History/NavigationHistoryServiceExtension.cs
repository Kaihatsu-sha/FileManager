using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.History
{
    public static class NavigationHistoryServiceExtension
    {
        public static IServiceCollection AddNavigationHistory(this IServiceCollection collection)
        {
            return collection.AddScoped<INavigationHistoryService<FolderInfoItem>, NavigationHistoryService<FolderInfoItem>>();
        }
    }
}
