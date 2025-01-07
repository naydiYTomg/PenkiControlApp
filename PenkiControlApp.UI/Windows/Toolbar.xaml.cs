using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.Logging;
using PenkiControlApp.UI.Controls;
using PenkiControlApp.UI.InternalTypes;
using EventManager = PenkiControlApp.UI.Controls.EventManager;
using State = uint;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl, IEventListener
{
    private readonly MainWindow _mainWindow;
    private readonly PCALogger _logger = PCALogger.GetInstance();
    private SearchWindow _searchWindow;
    private State _currentState = 0;
    public Toolbar(MainWindow window)
    {
        _mainWindow = window;
        EventManager.OnEventOccurred += HandleEvent;
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
            Search.IsEnabled = false;
            _searchWindow = _mainWindow.TabManager.ChangeToSearchWindow();
        }
        
        
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_mainWindow.TabManager.GetCurrentTab() == 8)
        {
            if (!Search.Text.Replace(" ", "").Equals(""))
            {
                _searchWindow.SearchResults.Children.Clear();
                if (SearchCategory.SelectedIndex == -1 || SearchCategory.Text == "Anywhere")
                {
                    var (data, _) = AllDatabaseData.GetInstance().GetData(Search.Text, null);
                    if (data.Count != 0)
                    {
                        // List<string> categories = [];
                        data.ForEach(x =>
                        {
                            var model = (((IOutputModel, string))x).Item1;
                            var category = (((IOutputModel, string))x).Item2;
                            _searchWindow.SearchResults.Children.Add(new SearchResultContainer(_searchWindow){ TypeLabel =
                            {
                                Content = category
                            }, NameLabel =
                            {
                                Content = category switch
                                {
                                    "products" => (model as ProductForDisplayingOutputModel)!.Name,
                                    "categories" => (model as CategoryOutputModel)!.Name,
                                    "clients" => (model as ClientForSearchOutputModel)!.Name,
                                    "orders" => (model as OrderForDisplayingOutputModel)!.Id,
                                    "tags" => (model as TagForDisplayingOutputModel)!.Name,
                                    _ => throw new SystemException("SOS!! SOS!! MI PADAYEM!!")
                                }
                            }, Width = 1000, Data = category switch
                            {
                                "products" => (model as ProductForDisplayingOutputModel)!,
                                "categories" => (model as CategoryOutputModel)!,
                                "clients" => (model as ClientForSearchOutputModel)!,
                                "orders" => (model as OrderForDisplayingOutputModel)!,
                                "tags" => (model as TagForDisplayingOutputModel)!,
                                _ => throw new SystemException("SOS!! SOS!! MI PADAYEM!!")
                            }});
                            // categories.Add(category);
                        });
                        // _searchWindow.StatusField.Content = $"Found in category {categories.ToArray()}";
                    }
                    else
                    {
                        _searchWindow.StatusField.Content = $"Not found in database";
                    }
                }
                else
                {
                    var (data, _) = AllDatabaseData.GetInstance().GetData(Search.Text, SearchCategory.Text);
                    if (data.Count != 0)
                    {
                        data.ForEach(x =>
                        {
                            _searchWindow.SearchResults.Children.Add(new SearchResultContainer(_searchWindow){ TypeLabel =
                            {
                                Content = SearchCategory.Text
                            }, NameLabel =
                            {
                                Content = SearchCategory.Text switch
                                {
                                    "Products" => (x as ProductForDisplayingOutputModel)!.Name,
                                    "Categories" => (x as CategoryOutputModel)!.Name,
                                    "Clients" => (x as ClientForSearchOutputModel)!.Name,
                                    "Orders" => (x as OrderForDisplayingOutputModel)!.Id,
                                    "Tags" => (x as TagForDisplayingOutputModel)!.Name,
                                    _ => throw new SystemException("SOS!! SOS!! MI PADAYEM!!")
                                }
                            }, Width = 1000, Data = SearchCategory.Text switch
                                {
                                "Products" => (x as ProductForDisplayingOutputModel)!,
                                "Categories" => (x as CategoryOutputModel)!,
                                "Clients" => (x as ClientForSearchOutputModel)!,
                                "Orders" => (x as OrderForDisplayingOutputModel)!,
                                "Tags" => (x as TagForDisplayingOutputModel)!,
                                _ => throw new SystemException("SOS!! SOS!! MI PADAYEM!!")
                            }});
                            
                        });
                        _searchWindow.StatusField.Content = $"Found in category {SearchCategory.Text}";
                    }
                    else
                    {
                        _searchWindow.StatusField.Content = $"Not found in category {SearchCategory.Text}";
                    }
                }
            }
        }
    }

    private void SwitchTabs()
    {
        List<UIElement> @default = [Products, Clients, Managers, TagsNCategories, Sells];
        List<UIElement> search = [SearchCategory, ExitSearch];
        switch (_currentState)
        {
            case 0:
                @default.ForEach(x => x.Visibility = Visibility.Collapsed);
                search.ForEach(x => x.Visibility = Visibility.Visible);
                SearchCategory.Items.Add(new ComboBoxItem { Content = "Anywhere", FontSize = 15 });
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
                SearchCategory.Items.Clear();
                _currentState = 0;
                break;
        }

    }


    private void ExitSearch_OnClick(object sender, RoutedEventArgs e)
    {
        SwitchTabs();
        _mainWindow.TabManager.ChangeTab(1);
        Search.Clear();
    }

    public void HandleEvent(string name)
    {
        switch (name)
        {
            case "SearchWindowInitialized" or "ClosedSearchResultInfoWindow":
                Search.IsEnabled = true;
                break;
            case "OpenedSearchResultInfoWindow":
                Search.IsEnabled = false;
                break;
        }
    }
}