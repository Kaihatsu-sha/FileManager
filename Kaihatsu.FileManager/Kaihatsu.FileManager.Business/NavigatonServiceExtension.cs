using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Business
{
    public static class NavigatonServiceExtension
    {
        public static INavigationService CreateNavigationService(this Navigation service)
        {
            return new NavigationService();
        }
    }
}
