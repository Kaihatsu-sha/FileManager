using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IConfiguration
    {
        int PageSize { get; set; }
        int DepthLevel { get; set; }
        string CurrentDirectory { get; set; }

    }
}
