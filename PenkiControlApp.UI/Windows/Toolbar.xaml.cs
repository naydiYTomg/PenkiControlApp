using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.Logging;
using PenkiControlApp.UI.InternalTypes;
using State = uint;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl
{
    private readonly MainWindow _mainWindow;
    private readonly PCALogger _logger = PCALogger.GetInstance();
    private SearchWindow _searchWindow;
    private State _currentState = 0;
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
        if (_mainWindow.TabManager.GetCurrentTab() != 8)
        {
            SwitchTabs();
        }
        _searchWindow = _mainWindow.TabManager.ChangeToSearchWindow();
        
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_mainWindow.TabManager.GetCurrentTab() == 8)
        {
            if (!Search.Text.Replace(" ", "").Equals(""))
            {
                var data = AllDatabaseData.GetInstance().GetData(Search.Text, SearchCategory.Text);
                if (data is not false)
                {
                    _searchWindow.SearchResults.Children.Add(new SearchResultContainer{ TypeLabel =
                    {
                        Content = "Type"
                    }, NameLabel =
                    {
                        Content = (data as ProductForDisplayingOutputModel)!.Name
                    }});
                    _searchWindow.StatusField.Content = $"Found in category {SearchCategory.Text}";
                }
                else
                {
                    _searchWindow.StatusField.Content = $"Not found in category {SearchCategory.Text}";
                }
            }
        }
    }

    private void SwitchTabs()
    {
        List<UIElement> @default = [Products, Clients, Managers, TagsNCategories, Sells];
        List<UIElement> search = [SearchCategory];
        switch (_currentState)
        {
            case 0:
                @default.ForEach(x => x.Visibility = Visibility.Collapsed);
                search.ForEach(x => x.Visibility = Visibility.Visible);
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Products", FontSize = 15 });
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Categories", FontSize = 15 });
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Clients", FontSize = 15 });
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Orders", FontSize = 15 });
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Tags", FontSize = 15 });
                _currentState = 1;
                break;
            case 1:
                search.ForEach(x => x.Visibility = Visibility.Collapsed);
                @default.ForEach(x => x.Visibility = Visibility.Visible);
                _currentState = 0;
                break;
        }

    }

   

    
}