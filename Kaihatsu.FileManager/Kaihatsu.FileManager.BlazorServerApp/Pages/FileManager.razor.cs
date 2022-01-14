using Kaihatsu.FileManager.Core.Abstraction.Services;
using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Business;
using Kaihatsu.FileManager.BlazorServerApp.Shared.Components;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Kaihatsu.FileManager.Core.Abstraction.Data;

namespace Kaihatsu.FileManager.BlazorServerApp.Pages
{
    [Route("Manager")]
    public partial class FileManager
    {
        private IEnumerable<ItemBase>? _items;
        private string? _valueCreateInput;
        private string? _valueSearchInput;
        private string? PageTitle = "File Manager";
        private bool _openSearchMenu = false;
        private bool _openCreateMenu = false;
        private const string _cssInputGroup = "input-group mb-3";

        [Inject]
        protected INavigationService NavigationService { get; set; }
        [Inject]
        protected IItemBaseProcessingService ProcessingService { get; set; }
        [Inject]
        protected INavigationHistoryService<FolderInfoItem> HistoryService { get; set; }
        [Inject]
        protected ISearchService SearchService { get; set; }

        private IEnumerable<ItemBase> ItemsList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            OpenDirectory(null);
        }

        private string? PreviousDisabled => HistoryService.CanGetPrevious ? null : "disabled";
        private string? UpDisabled => NavigationService.CanTheUp ? null : "disabled";
        private string? SearchMenuCssClass => _openSearchMenu ? _cssInputGroup : "collapse";
        private string? CreateMenuCssClass => _openCreateMenu ? _cssInputGroup : "collapse";
       
        private async Task OpenDirectory(string path)
        {
            
            if (NavigationService.CheckingPath(path))
            {
                HistoryService.AddToHistory(new FolderInfoItem(NavigationService.Path));//TODO: Плохо
                ItemsList = ProcessingService.GetAllFromDirection(NavigationService.Path).ToList();
            }
            //Сообщение об ошибке
            //UpdateCallback();
            _items = ItemsList;
        }

        private async Task OpenParent()
        {
            FolderInfoItem parent = NavigationService.GetParent();

            if (parent is not null)
            {
                OpenDirectory(parent.Path);
            }
        }

        private async Task OpenPrevious()
        {
            FolderInfoItem previous = HistoryService.GetPrevious();
            NavigationService.CheckingPath(previous.Path);
            ItemsList = ProcessingService.GetAllFromDirection(NavigationService.Path).ToList();
        }

        private async void UpdateCallback()
        {
            //_status = "!!!";
            int itemsCount = _items
                                .Where(item => item.Type == ItemType.Folder)
                                .Select(item => (FolderInfoItem)item)
                                .Where(item => !item.IsLoadet)
                                .Count();
            if (itemsCount > 0)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(10_000);
                    UpdateCallback();
                });
            }
            
            //_status = "загружено2";
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
            //StateHasChanged();
        }

        private void ToggleSearchMenu()
        {
            _openCreateMenu = false;
            _openSearchMenu = !_openSearchMenu;

            _valueSearchInput = "";
            SearchService.ConfigureSession(NavigationService.Path, true);
            ChangeSearchValue("");
        }

        private void ToggleCreateMenu()
        {
            _openSearchMenu = false;
            _openCreateMenu = !_openCreateMenu;
        }

        private void CreateFolder()
        {
            //FIX: Не сбрасываются переменная назавния!!!
            //DirectoryInfo current = new DirectoryInfo(_currentPath);
            //current.CreateSubdirectory(_newItemName);
            //Reset();
        }

        private void CreateFile()
        {
            //FIX: Не сбрасываются переменная назавния!!!
            //string path = System.IO.Path.Combine(_currentPath, _newItemName);
            //File.Create(path);
            //Reset();
            //FileInfo file = new FileInfo(_currentPath + "\\" + _newItemName);   
        }

        private void ChangeSearchValue(string pattern) 
        {
            if (string.IsNullOrEmpty(pattern))
            {
                ItemsList = _items;
            }

            ItemsList = SearchService.Search(pattern);
        }
    }
}
