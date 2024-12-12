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
using PenkiControlApp.Logging;
using PenkiControlApp.UI.Controls;
using PenkiControlApp.UI.Windows;

namespace PenkiControlApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly PCALogger _logger = PCALogger.GetInstance();
    public Toolbar Toolbar { get; private set; }
    public TabManager TabManager { get; private set;  }

    public MainWindow()
    {
        InitializeComponent();
        TabManager = new TabManager(this);
        Toolbar = new Toolbar(this) { Height = 100 };
        AddElement(Toolbar, 0);
    }

    public void tabmgrerror(string message, bool isDrop)
    {
        _logger.LogError(message, isDrop);
    }
    public void tabmgrlog(string message)
    {
        _logger.LogMessage(message);
    }
    
    public void AddElement(UIElement element, int which)
    {
        
        _logger.LogMessage($"Element {element} is created");

        switch (which)
        {
            case 0:
                WrapTools.Children.Add(element);
                break;
            case 1:
                WrapWins.Children.Add(element);
                break;
        }
    }

    

    

    
}