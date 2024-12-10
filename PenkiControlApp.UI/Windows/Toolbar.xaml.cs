using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class Toolbar : UserControl
{
    public Toolbar()
    {
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
        throw new NotImplementedException();
    }

    private void Managers_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}