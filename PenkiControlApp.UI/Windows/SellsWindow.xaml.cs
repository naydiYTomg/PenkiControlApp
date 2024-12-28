using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class SellsWindow : UserControl
{
    //private MainWindow _window;
    public SellsWindow()
    {
        InitializeComponent();
        //_window = window;
    }
    private void SellsWindow_OnInitialized(object? sender, EventArgs e)
    {
        var got = App.ProductManager.GetAllProducts();
        got.ForEach(x => { _ProductsDropDown.Items.Add(new ComboBoxItem { Content = x.Name }); });
    }
    private void ChosenProducts_OnSelected(object sender, SelectionChangedEventArgs e)
    {
        //ProductContainer.Children.Clear();
        //var tags = App.TagManager.GetTagsByCategoryName((ProductContainer.SelectedItem as ComboBoxItem)!.Content.ToString()!);
        //tags.ForEach(x =>
        //{
        //   ProductContainer.Children.Add(new TagCheckbox(x.Id) { TagName = { Content = x.Name } });
        //});
        ProductContainer.Children.Add(new ProductAddingElement() { _ProductNameToAdd = {Text = (_ProductsDropDown.SelectedItem as ComboBoxItem)!.Content.ToString() } });
    }
}