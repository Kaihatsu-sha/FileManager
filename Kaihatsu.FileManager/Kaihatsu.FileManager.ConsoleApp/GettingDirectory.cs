using Kaihatsu.FileManager.Business;
using Kaihatsu.FileManager.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.ConsoleApp
{
    internal class GettingDirectory
    {
        public GettingDirectory()
        {
            //Operations opearation = new Operations();

            //foreach(FileInfoBase file in opearation.OpeningDirectory(@"C:\"))
            //{
            //    Console.WriteLine($"path: {file.FullPath} name {file.Name} size {file.Size}");

            //}
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\User\source\GeekBrains\FileManager");
            dirInfo.CreateSubdirectory(@"Folder");
            DirectoryInfo dirInfoSub = new DirectoryInfo(@"C:\Users\User\source\GeekBrains\FileManager\Folder");
            dirInfoSub.MoveTo(@"C:\Users\User\source\GeekBrains\FileManager\NewFolder");

            //FileSystemInfo info = new DirectoryInfo(@"C:\");
            //FileInfoBase mainInfo = new FileInfoBase(@"C:\");
            //FileAttributes atributes = info.Attributes;
            //DirectoryInfo directory = new DirectoryInfo(info.FullName);

            //DirectorySecurity secutiry = directory.GetAccessControl();
            //DirectoryInfo[] directories = directory.GetDirectories();
            //FileInfo[] files = directory.GetFiles();
        }
    }
}
