using Kaihatsu.FileManager.Core.Abstraction.Data;
using Microsoft.AspNetCore.Components;

namespace Kaihatsu.FileManager.BlazorServerApp.Shared.Components
{
    public partial class FolderItem
    {
        private bool _collapseOperationMenu = true;
        private bool _collapseTableRow = true;
        private bool _collapseInputDiv = true;
        private const string _cssInputGroup = "input-group mb-3";


        [Parameter]
        public FolderInfoItem Item { get; set; }
        [Parameter]
        public EventCallback<string> OnOpenDirectoryCallback { get; set; }
        [Parameter]
        public EventCallback UpdateCallback { get; set; }

        private string? InputValue { get; set; }

        private string? OperationMenuCssClass => _collapseOperationMenu ? "collapse" : null;
        private string OperationMenuText => _collapseTableRow ? "Выбрать" : "Отменить";
        private string ImputDivCssClass => _collapseInputDiv ? "collapse" : _cssInputGroup;



        protected override async Task OnInitializedAsync()
        {
            _collapseOperationMenu = true;
            _collapseTableRow = true;
            _collapseInputDiv = true;
            //FIX: При переходе выше или назад отображается открытый элемент!!!
            //FIX: Не сбрасываются переменные!!!
        }

        private void ToggleOperationMenu()
        {
            _collapseOperationMenu = !_collapseOperationMenu;
            _collapseTableRow = !_collapseTableRow;
            _collapseInputDiv = true;
        }

        private void OpenDirectory()
        {
            OnOpenDirectoryCallback.InvokeAsync(Item.Path);
        }

        private void Delete()//FIX: При удалении меню операций открывается у следующего элемента!!!
        {
            _collapseInputDiv = false;
            //_operationsFactory.Delete();
            //UpdateCallback.InvokeAsync();
        }

        private void Move()
        {
            _collapseInputDiv = false;
            //if (_collapseMoveDiv)//Шаг 1: Отображаем input для ввода пути
            //{
            //    _collapseMoveDiv = !_collapseMoveDiv;
            //    return;
            //}

            ////Шаг 2: подтверждаем ввод пути
            //if (_moveInput.Length > 1)
            //{
            //    _operationsFactory.Move(_moveInput);
            //    //_collapseMoveDiv = !_collapseMoveDiv;
            //    UpdateCallback.InvokeAsync();
            //}
        }

        private void Copy()
        {
            _collapseInputDiv = false;
            //if (_collapseCopyDiv)//Шаг 1: Отображаем input для ввода пути
            //{
            //    _collapseCopyDiv = !_collapseCopyDiv;
            //    return;
            //}

            ////Шаг 2: подтверждаем ввод пути
            //if (_moveInput.Length > 1)
            //{
            //    _operationsFactory.Copy(_moveInput);
            //    //_collapseMoveDiv = !_collapseMoveDiv;
            //    UpdateCallback.InvokeAsync();
            //}
        }

        private void Rename()
        {
            _collapseInputDiv = false;
            //if (_collapseRenameDiv)//Шаг 1: Отображаем input для ввода пути
            //{
            //    _collapseRenameDiv = !_collapseRenameDiv;
            //    return;
            //}

            ////Шаг 2: подтверждаем ввод пути
            //if (_moveInput.Length > 1)
            //{
            //    _operationsFactory.Rename(_moveInput);
            //    //_collapseMoveDiv = !_collapseMoveDiv;
            //    UpdateCallback.InvokeAsync();
            //}
        }
    }
}
