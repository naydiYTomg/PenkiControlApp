using System.Windows;
using System.Windows.Controls;
using EventManager = PenkiControlApp.UI.Controls.EventManager;

namespace PenkiControlApp.UI.Windows;

public partial class AboutSearchResultWindow : UserControl
{
    public SearchWindow _parent;
    public AboutSearchResultWindow(SearchWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        EventManager.TriggerEvent("ClosedSearchResultInfoWindow");
    }
}