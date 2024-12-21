using System.Windows;
using System.Windows.Controls;
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
    private void Sells_OnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogMessage($"Clicked Sells button and created Sells window");
        _mainWindow.TabManager.ChangeTab(5);
    }

    // private void Toolbar_OnInitialized(object? sender, EventArgs e)
    // {
    //     Console.WriteLine("Initialized toolbar");
    //     MainWindow.WindowInitialized(this);
    // }
}