using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class SearchResultContainer : UserControl
{
    public object Data { get; set; }
    public SearchResultContainer()
    {
        InitializeComponent();
    }
}