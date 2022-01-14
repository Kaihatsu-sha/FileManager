using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.Navigation
{
    public static class NavigationServiceExtension
    {
        public static IServiceCollection AddNavigation(this IServiceCollection collection)
        {
            return collection.AddScoped<INavigationService, NavigationService>();
        }
    }
}
