using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class ProductCreationWindow : UserControl
{
    public ProductCreationWindow()
    {
        InitializeComponent();
    }

    private void ProductCreationWindow_OnInitialized(object? sender, EventArgs e)
    {
        var got = App.CategoryManager.GetCategories();
        got.ForEach(x => { ChosenCategories.Items.Add(new ComboBoxItem { Content = x.Name }); });
    }

    private void ChosenCategories_OnSelected(object sender, SelectionChangedEventArgs e)
    {
        TagsContainer.Children.Clear();
        var tags = App.TagManager.GetTagsByCategoryName((ChosenCategories.SelectedItem as ComboBoxItem)!.Content.ToString()!);
        tags.ForEach(x =>
        {
            TagsContainer.Children.Add(new TagCheckbox{ TagName = { Content = x.Name } });
        });
    }
}