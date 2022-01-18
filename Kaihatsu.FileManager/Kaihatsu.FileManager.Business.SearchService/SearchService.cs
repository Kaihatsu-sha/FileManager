using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using System.Text.RegularExpressions;

namespace Kaihatsu.FileManager.Business.SearchService
{
    internal class SearchService : ISearchService
    {
        private readonly IItemBaseProcessingService _processingService;
        private IQueryable<ItemBase> _items;

        public SearchService(IItemBaseProcessingService processingService)
        {
            _processingService = processingService;
        }

        public void ConfigureSession(string path, bool useSubdirectories = false)
        {
            _items = _processingService.GetAllFromDirection(path, useSubdirectories);
        }

        public IQueryable<ItemBase> Search(string pattern)
        {
            if (_items is null)
            {
                throw new ArgumentNullException();
            }

            Func<ItemBase, bool> predicate = item => { return Regex.IsMatch(item.Name, pattern, RegexOptions.IgnoreCase); };
            
            return _items.Where(predicate).AsQueryable();
        }
    }
}