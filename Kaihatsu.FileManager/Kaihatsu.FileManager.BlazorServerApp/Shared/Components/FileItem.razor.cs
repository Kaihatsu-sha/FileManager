using Kaihatsu.FileManager.Core.Abstraction.Data;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.AspNetCore.Components;

namespace Kaihatsu.FileManager.BlazorServerApp.Shared.Components
{
    public partial class FileItem
    {
        private bool _collapseOperationMenu = true;
        private bool _collapseTableRow = true;
        private bool _collapseInputDiv = true;
        private const string _cssInputGroup = "input-group mb-3";
        private IOperationsService _operationsService;


        [Parameter]
        public FileInfoItem Item { get; set; }
        [Parameter]
        public EventCallback UpdateCallback { get; set; }
        [Inject]
        protected IOperationsFactoryService operationsFactoryService { get; set; }

        private string? InputValue { get; set; }
        private string? Placeholder { get; set; }

        private string? OperationMenuCssClass => _collapseOperationMenu ? "collapse" : null;
        private string OperationMenuText => _collapseTableRow ? "Выбрать" : "Отменить";
        private string ImputDivCssClass => _collapseInputDiv ? "collapse" : _cssInputGroup;



        protected override async Task OnInitializedAsync()
        {
            _operationsService = operationsFactoryService.CreateFileFactory();
            _collapseOperationMenu = true;
            _collapseTableRow = true;
            _collapseInputDiv = true;
        }

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    InputValue = "";
        //    _collapseOperationMenu = true;
        //    _collapseTableRow = true;
        //    _collapseInputDiv = true;
        //}

        private void ToggleOperationMenu()
        {
            _collapseOperationMenu = !_collapseOperationMenu;
            _collapseTableRow = !_collapseTableRow;
            _collapseInputDiv = true;

            InputValue = "";
        }

        private void Delete()//FIX : Проверка на изменение операции
        {
            _operationsService.Delete(Item.Path, false);
            
            UpdateCallback.InvokeAsync();
        }

        private void Move()//FIX : Проверка на изменение операции
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "F:\\Move\\To\\Folder\\file.txt";
                return;
            }

            if (InputValue.Length > 1)
            {
                _operationsService.Move(Item.Path, InputValue);

                UpdateCallback.InvokeAsync();
            }
        }

        private void Copy()//FIX : Проверка на изменение операции
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "F:\\Copy\\In\\Folder\\file.txt";
                return;
            }

            if (InputValue.Length > 1)
            {
                _operationsService.Copy(Item.Path, InputValue);

                UpdateCallback.InvokeAsync();
            }
        }

        private void Rename()//FIX : Проверка на изменение операции
        {
            if (_collapseInputDiv)
            {
                _collapseInputDiv = !_collapseInputDiv;
                Placeholder = "newName.txt";
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
