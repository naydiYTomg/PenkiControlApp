using System.Windows;
using PenkiControlApp.UI.Windows;

namespace PenkiControlApp.UI.Controls;
using Tab = int;

public class TabManager(MainWindow window)
{
    private readonly MainWindow _mainWindow = window;
    private Tab _currentTab = 0;
    
    
    public void ChangeTab(Tab tab)
    {
        if (tab != _currentTab)
        {
            _mainWindow.WrapWins.Children.Clear();
            _currentTab = tab;
            switch (tab)
            {
                case 1:
                    _mainWindow.AddElement(new ClientWindows{ Height = 600, Width = 1160 }, 1);
                    break;
                case 2:
                    _mainWindow.AddElement(new ProductWindows(_mainWindow){Height = 600, Width = 1160}, 1);
                    break;
                case 3:
                    _mainWindow.AddElement(new TagsNCategoriesWindow{Height = 600, Width = 1160}, 1);
                    break;
                case 4:
                    _mainWindow.AddElement(new ManagerWindows{ Height = 600, Width = 1160 }, 1);
                    break;
                case 5:
                    _mainWindow.AddElement(new LoginRegistrationWindow(_mainWindow){ Height = 600, Width = 1160}, 1);
                    break;
                case 6:
                    _mainWindow.AddElement(new SellsWindow { Height = 700, Width = 1280}, 1);
                    break;
                case 7: //Product creation window
                    _mainWindow.AddElement(new ProductCreationWindow(_mainWindow) { Height = 700, Width = 1160}, 1);
                    break;
                default:
                    _mainWindow.tabmgrerror("Ya hz kak ti smog eto sdelat", true);
                    break;
            }

            if (tab != 7)
            {
                UpdateButtons(tab);
            }
        }
    }

    private void EnableButtons()
    {
        List<UIElement> temp =
        [
            _mainWindow.Toolbar.Clients, _mainWindow.Toolbar.Products, _mainWindow.Toolbar.TagsNCategories,
            _mainWindow.Toolbar.Managers, _mainWindow.Toolbar.Login, _mainWindow.Toolbar.Sells
        ];
        temp.ForEach(x => x.IsEnabled = true);
    }
    private void UpdateButtons(int except)
    {
        List<UIElement> temp =
        [
            _mainWindow.Toolbar.Clients, _mainWindow.Toolbar.Products, _mainWindow.Toolbar.TagsNCategories,
            _mainWindow.Toolbar.Managers, _mainWindow.Toolbar.Login, _mainWindow.Toolbar.Sells
        ];
        temp[except - 1].IsEnabled = false;
        temp.ForEach(x =>
        {
            if (temp.IndexOf(x) != except-1)
            {
                x.IsEnabled = true;
            }
        });
    }

    public Tab GetCurrentTab()
    {
        return _currentTab;
    }

    public SearchWindow ChangeToSearchWindow()
    {
        var element = new SearchWindow() { Height = 600, Width = 1160 };
        _mainWindow.WrapWins.Children.Clear();
        _currentTab = 8;
        _mainWindow.AddElement(element, 1);
        EnableButtons();
        return element;
    }
    
}