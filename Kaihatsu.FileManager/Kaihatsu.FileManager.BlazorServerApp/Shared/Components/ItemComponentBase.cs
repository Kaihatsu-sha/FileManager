using Microsoft.AspNetCore.Components;

namespace Kaihatsu.FileManager.BlazorServerApp.Shared.Components
{
    public abstract class ItemComponentBase// : ComponentBase
    {
        public bool _collapseOperationMenu = true;
        public bool _collapseTableRow = true;
        public bool _collapseInputDiv = true;
        public const string _cssInputGroup = "input-group mb-3";

        [Parameter]
        public EventCallback<string> OnOpenDirectoryCallback { get; set; }
        [Parameter]
        public EventCallback UpdateCallback { get; set; }

        public string? InputValue { get; set; }

        public string? OperationMenuCssClass => _collapseOperationMenu ? "collapse" : null;
        public string OperationMenuText => _collapseTableRow ? "Выбрать" : "Отменить";
        public string ImputDivCssClass => _collapseInputDiv ? "collapse" : _cssInputGroup;

        public void ToggleOperationMenu()
        {
            _collapseOperationMenu = !_collapseOperationMenu;
            _collapseTableRow = !_collapseTableRow;
            _collapseInputDiv = true;
        }

        public abstract void OpenDirectory();

        public void Delete()//FIX: При удалении меню операций открывается у следующего элемента!!!
        {
            _collapseInputDiv = false;
            //_operationsFactory.Delete();
            //UpdateCallback.InvokeAsync();
        }

        public void Move()
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

        public void Copy()
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

        public void Rename()
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
