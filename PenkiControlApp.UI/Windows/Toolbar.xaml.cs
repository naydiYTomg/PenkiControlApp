using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl
{
    public MainWindow MainWindow { get; set; }
    public Toolbar(MainWindow window)
    {
        MainWindow = window;
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
        var window = new TagsNCategoriesWindow(MainWindow){Height = 700, Width = 1280};
        TagsNCategories.IsEnabled = false;
    }

    private void Managers_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Toolbar_OnInitialized(object? sender, EventArgs e)
    {
        Console.WriteLine("Initialized toolbar");
        MainWindow.WindowInitialized(this);
    }
}