using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class AboutCategoryWindow : UserControl
{
    private readonly TagsNCategoriesWindow _parent;
    public AboutCategoryWindow(TagsNCategoriesWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        _parent.GridMain.Children.Remove(this);
    }
}