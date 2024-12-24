using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PenkiControlApp.Logging;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl
{
    private readonly MainWindow _mainWindow;
    private readonly PCALogger _logger = PCALogger.GetInstance();
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
}