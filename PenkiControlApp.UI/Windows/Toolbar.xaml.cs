using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.Logging;
using PenkiControlApp.UI.InternalTypes;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl
{
    private readonly MainWindow _mainWindow;
    private readonly PCALogger _logger = PCALogger.GetInstance();
    private SearchWindow _searchWindow;
    public Toolbar(MainWindow window)
    {
        _mainWindow = window;
        InitializeComponent();
    }

    
    private void Clients_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Products button and created Clients window");
        _mainWindow.TabManager.ChangeTab(1);
    }

    private void Products_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Products button and created Products window");
        _mainWindow.TabManager.ChangeTab(2);

    }

    private void TagsNCategories_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked TagsNCategories button and created Tags&Categories window");
        _mainWindow.TabManager.ChangeTab(3);
        
    }

    private void Managers_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Products button and created Managers window");
        _mainWindow.TabManager.ChangeTab(4);
    }

    // private void Toolbar_OnInitialized(object? sender, EventArgs e)
    // {
    //     Console.WriteLine("Initialized toolbar");
    //     MainWindow.WindowInitialized(this);
    // }
    private void Login_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Login button up and created LoginRegistration window");
        Login.Source = (ImageSource)Resources["Login"]!;
        _mainWindow.TabManager.ChangeTab(5);
    }

    private void Login_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        _logger.LogMessage($"Clicked Login button down");
        Login.Source = (ImageSource)Resources["LoginClicked"]!;
    }

    private void Login_OnMouseLeave(object sender, MouseEventArgs e)
    {
        _logger.LogMessage($"Leaved Login button");
        Login.Source = (ImageSource)Resources["Login"]!;
    }

    private void Sells_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Sells button and created Sells window");
        _mainWindow.TabManager.ChangeTab(6);
    }

    

    private void Search_OnGotFocus(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Search button and created Search window");
        _searchWindow = _mainWindow.TabManager.ChangeToSearchWindow();
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_mainWindow.TabManager.GetCurrentTab() == 8)
        {
            if (!Search.Text.Replace(" ", "").Equals(""))
            {
                var data = AllDatabaseData.GetInstance().GetData(Search.Text, "products") as IOutputModel;
                _searchWindow.SearchResults.Children.Add(new SearchResultContainer{ TypeLabel =
                {
                    Content = "Type"
                }, NameLabel =
                {
                    Content = (data as ProductForDisplayingOutputModel)!.Name
                }});
            }
        }
    }
}