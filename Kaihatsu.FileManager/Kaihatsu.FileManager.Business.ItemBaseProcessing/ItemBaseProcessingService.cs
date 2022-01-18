using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;

namespace Kaihatsu.FileManager.Business.ItemBaseProcessing
{
    internal class ItemBaseProcessingService : IItemBaseProcessingService
    {
        public IQueryable<ItemBase> GetAllFromDirection(string path, bool useSubdirectories)
        {
            List<ItemBase> filesInDerectory = new List<ItemBase>();
            IEnumerable<string> directories = null;
            IEnumerable<string> files = null;

            try
            {
                if (useSubdirectories)
                {
                    directories = Directory.EnumerateDirectories(path, "", SearchOption.AllDirectories);
                    files = Directory.EnumerateFiles(path, "", SearchOption.AllDirectories);
                }
                else
                {
                    directories = Directory.EnumerateDirectories(path);
                    files = Directory.EnumerateFiles(path);
                }

                foreach (var dirPath in directories)
                {
                    filesInDerectory.Add(new FolderInfoItem(dirPath));
                }

                foreach (var dirPath in files)
                {
                    filesInDerectory.Add(new FileInfoItem(dirPath));
                }
            }
            catch(UnauthorizedAccessException ex)
            {

            }

            return filesInDerectory.AsQueryable();
        }

        public IQueryable<ItemBase> GetAllFromDirection(string path)
        {
            return GetAllFromDirection(path, false);
        }
    }
}