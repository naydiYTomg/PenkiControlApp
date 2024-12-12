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
                    _mainWindow.tabmgrlog("TODO:: Create clients tab");
                    break;
                case 2:
                    _mainWindow.AddElement(new ProductWindows(){Height = 700, Width = 1280}, 1);
                    break;
                case 3:
                    _mainWindow.AddElement(new TagsNCategoriesWindow(){Height = 700, Width = 1280}, 1);
                    break;
                case 4:
                    _mainWindow.tabmgrlog("TODO:: Create managers tab");
                    break;
                default:
                    _mainWindow.tabmgrerror("Ya hz kak ti smog eto sdelat", true);
                    break;
            }

            UpdateButtons(tab);
        }
    }

    private void UpdateButtons(int except)
    {
        List<UIElement> temp =
        [
            _mainWindow.Toolbar.Clients, _mainWindow.Toolbar.Products, _mainWindow.Toolbar.TagsNCategories,
            _mainWindow.Toolbar.Managers
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
    
}