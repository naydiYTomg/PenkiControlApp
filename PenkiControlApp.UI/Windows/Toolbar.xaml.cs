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
        Console.WriteLine(Search.Text);
        Search.Text = "";
    }

    private void Products_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void TagsNCategories_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new TagsNCategoriesWindow{Height = 700, Width = 1280};
        _logger.LogMessage($"Clicked TagsNCategories button and created {window}");
        TagsNCategories.IsEnabled = false;
        _mainWindow.AddElement(window, 1);
    }

    private void Managers_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    // private void Toolbar_OnInitialized(object? sender, EventArgs e)
    // {
    //     Console.WriteLine("Initialized toolbar");
    //     MainWindow.WindowInitialized(this);
    // }
}