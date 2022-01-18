using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.AspNetCore.Components;

namespace Kaihatsu.FileManager.BlazorServerApp.Shared.Components
{
    public partial class FolderItem
    {
        private bool _collapseOperationMenu = true;
        private bool _collapseTableRow = true;
        private bool _collapseInputDiv = true;
        private const string _cssInputGroup = "input-group mb-3";
        private IOperationsService _operationsService;
        private System.Timers.Timer timer;

        [Parameter]
        public FolderInfoItem Item { get; set; }
        [Parameter]
        public EventCallback<string> OnOpenDirectoryCallback { get; set; }
        [Parameter]
        public EventCallback UpdateCallback { get; set; }
        [Parameter]
        public EventCallback Refresh { get; set; }
        [Inject]
        protected IOperationsFactoryService operationsFactoryService { get; set; }


        private string? InputValue { get; set; }
        private string? Placeholder { get; set; }

        private string? OperationMenuCssClass => _collapseOperationMenu ? "collapse" : null;
        private string OperationMenuText => _collapseTableRow ? "Выбрать" : "Отменить";
        private string ImputDivCssClass => _collapseInputDiv ? "collapse" : _cssInputGroup;



        protected override async Task OnInitializedAsync()
        {
            _operationsService = operationsFactoryService.CreateFolderFactory();

            _collapseOperationMenu = true;
            _collapseTableRow = true;
            _collapseInputDiv = true;

            if (!Item.IsLoaded)
            {
                timer = new System.Timers.Timer();
                timer.Interval = TimeSpan.FromSeconds(3).TotalMilliseconds;
                timer.Elapsed += (sender, eventArgs) => OnTimerCallback();
                timer.AutoReset = true;
                timer.Start();
            }
            
        }

        private void OnTimerCallback()
        {
            if (Item.IsLoaded)
            {
                timer.Stop();
                timer.Dispose();
                _ = InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
        }

        private void ToggleOperationMenu()
        {
            _collapseOperationMenu = !_collapseOperationMenu;
            _collapseTableRow = !_collapseTableRow;
            _collapseInputDiv = true;

            InputValue = "";
        }

        private void OpenDirectory()
        {
            OnOpenDirectoryCallback.InvokeAsync(Item.Path);
        }

        private void Delete()//FIX : Отслеживания текущей операции.
        {
            _operationsService.Delete(Item.Path, false);

            UpdateCallback.InvokeAsync();
        }

        private void Move()//FIX : Отслеживания текущей операции.
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "F:\\Move\\To\\Folder";
                return;
            }

            if (InputValue.Length > 1)
            {
                _operationsService.Move(Item.Path, InputValue);

                UpdateCallback.InvokeAsync();
            }
        }

        private void Copy()//FIX : Отслеживания текущей операции.
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "F:\\Copy\\In\\Folder";
                return;
            }

            if (InputValue.Length > 1)
            {
                _operationsService.Copy(Item.Path, InputValue + "\\" + Item.Name);

                UpdateCallback.InvokeAsync();
            }
        }

        private void Rename()//FIX : Отслеживания текущей операции.
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "Новое название папки";
                return;
            }

            if (InputValue.Length > 1)
            {
                _operationsService.Rename(Item.Path, InputValue);

                UpdateCallback.InvokeAsync();
            }
        }
    }
}
