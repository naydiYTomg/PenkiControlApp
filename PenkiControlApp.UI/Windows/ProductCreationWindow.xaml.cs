using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class ProductCreationWindow : UserControl
{
    private MainWindow _window;
    public ProductCreationWindow(MainWindow window)
    {
        InitializeComponent();
        _window = window;
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
            TagsContainer.Children.Add(new TagCheckbox(x.Id){ TagName = { Content = x.Name } });
        });
    }

    private void CreateButton_OnClick(object sender, RoutedEventArgs e)
    {
        var name = NameOfProductField.Text;
        var categoryName = (ChosenCategories.SelectedItem as ComboBoxItem)!.Content.ToString()!;
        var cost = int.Parse(CostOfProductField.Text);
        var categoryId = App.CategoryManager.GetCategoryIdByName(categoryName);
        var productId = App.ProductManager.AddNewProduct(name, categoryId, cost);
        List<int> chosenTagsIds = [];
        chosenTagsIds.AddRange(from UIElement tagsContainerChild in TagsContainer.Children select tagsContainerChild as TagCheckbox into cur where (bool)cur!.Selected.IsChecked! select cur.Id);
        App.ProductTagRelManager.AddTagsToProduct(productId, chosenTagsIds);
        _window.TabManager.ChangeTab(2);
    }
}