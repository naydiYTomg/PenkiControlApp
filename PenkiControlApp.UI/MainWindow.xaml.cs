using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenkiControlApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
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