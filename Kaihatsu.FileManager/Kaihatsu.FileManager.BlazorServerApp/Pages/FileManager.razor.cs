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
        [Inject]
        protected IOperationsFactoryService operationsFactoryService { get; set; }


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
                GetItemsFromCurrentFolder();
            }
        }

        private void GetItemsFromCurrentFolder()
        {
            ItemsList = ProcessingService.GetAllFromDirection(NavigationService.Path).ToList();
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
            
            GetItemsFromCurrentFolder();
        }

        private async void UpdateCallback()
        {
            ClearInputs();

            _openSearchMenu = false;
            _openCreateMenu = false;
            
            ItemsList = null;
            GetItemsFromCurrentFolder();
        }

        private void ClearInputs()
        {
            _valueCreateInput = "";
            _valueSearchInput = "";
        }

        private void ToggleSearchMenu()
        {
            ClearInputs();

            _openCreateMenu = false;
            _openSearchMenu = !_openSearchMenu;

            SearchService.ConfigureSession(NavigationService.Path, true);
            ChangeSearchValue("");
        }

        private void ToggleCreateMenu()
        {
            ClearInputs();

            _openSearchMenu = false;
            _openCreateMenu = !_openCreateMenu;
        }

        private void CreateFolder()
        {
            operationsFactoryService
                .CreateFolderFactory()
                .Create(Path.Combine(NavigationService.Path, _valueCreateInput));

            GetItemsFromCurrentFolder();
            UpdateCallback();
        }

        private void CreateFile()
        {
            operationsFactoryService
                .CreateFileFactory()
                .Create(Path.Combine(NavigationService.Path, _valueCreateInput));

            GetItemsFromCurrentFolder();
            UpdateCallback();
        }

        private void ChangeSearchValue(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                ItemsList = _items;
                return;
            }

            ItemsList = SearchService.Search(pattern);
        }
    }
}