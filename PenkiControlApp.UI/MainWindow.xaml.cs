using System.IO;
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
using PenkiControlApp.UI.Windows;

namespace PenkiControlApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<UIElement> Elements { get; private set; } = new List<UIElement>();

    public MainWindow()
    {
        InitializeComponent();
        Elements.Add(new Toolbar(this) { Height = 100 });
    }

    public void WindowInitialized(UIElement element)
    {
        switch (element)
        {
            case Toolbar:
                Console.WriteLine("Element Toolbar added");
                Grid.SetRow(element, 0);
                WrapTools.Children.Add(element);
                break;
            case TagsNCategoriesWindow:
                Console.WriteLine("Element TagsNCategories added");
                Grid.SetRow(element, 1);
                WrapWins.Children.Add(element);
                break;
        }
    }

    public void UpdateElements()
    {
        WrapTools.Children.Clear();
        foreach (var element in Elements)
        {
            WrapTools.Children.Add(element);
        }
    }

    
}