using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business.SearchService
{
    public static class SearchServiceExtension
    {
        public static IServiceCollection AddSearch(this IServiceCollection collection)
        {
            return collection.AddScoped<ISearchService, SearchService>();
        }
    }
}
