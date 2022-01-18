using Microsoft.AspNetCore.Components;

namespace Kaihatsu.FileManager.BlazorServerApp.Pages
{
    [Route("")]
    public partial class Index
    {
        private bool _collapseCreateMenu = true;
        private bool _collapseDeleteMenu = true;
        private bool _collapseRenameMenu = true;
        private bool _collapseCopyMenu = true;
        private bool _collapseMoveMenu = true;
        private bool _collapseSearchMenu = true;

        protected override async Task OnInitializedAsync()
        {
        }

        private string? CreateMenuCssClass => _collapseCreateMenu ? "collapse" : null;
        private string? DeleteMenuCssClass => _collapseDeleteMenu ? "collapse" : null;
        private string? RenameMenuCssClass => _collapseRenameMenu ? "collapse" : null;
        private string? CopyMenuCssClass => _collapseCopyMenu ? "collapse" : null;
        private string? MoveMenuCssClass => _collapseMoveMenu ? "collapse" : null;
        private string? SearchMenuCssClass => _collapseSearchMenu ? "collapse" : null;
        private void ToggleCreateMenu()
        {
            _collapseCreateMenu = !_collapseCreateMenu;
        }

        private void ToggleDeleteMenu()
        {
            _collapseDeleteMenu = !_collapseDeleteMenu;
        }

        private void ToggleRenameMenu()
        {
            _collapseRenameMenu = !_collapseRenameMenu;
        }

        private void ToggleCopyMenu()
        {
            _collapseCopyMenu = !_collapseCopyMenu;
        }

        private void ToggleMoveMenu()
        {
            _collapseMoveMenu = !_collapseMoveMenu;
        }

        private void ToggleSearchMenu()
        {
            _collapseSearchMenu = !_collapseSearchMenu;
        }

    }
}
