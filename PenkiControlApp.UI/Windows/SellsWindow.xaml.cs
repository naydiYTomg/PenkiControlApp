using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class SellsWindow : UserControl
{
    //private MainWindow _window;
    //long i = 0;
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
        bool isChildrenHere = false;
        if (ProductContainer.Children.Count == 0)
        {
            ProductContainer.Children.Add(new ProductAddingElement(this) { _ProductNameToAdd = { Text = (_ProductsDropDown.SelectedItem as ComboBoxItem)!.Content.ToString() } });
        }
        else
        {
            foreach (ProductAddingElement child in ProductContainer.Children)
            {
                if (child._ProductNameToAdd.Text == (_ProductsDropDown.SelectedItem as ComboBoxItem)!.Content.ToString())
                {
                    isChildrenHere = true;
                    child.ValueIncrease();
                }
            }
            if (!isChildrenHere)
            {
                ProductContainer.Children.Add(new ProductAddingElement(this) { _ProductNameToAdd = { Text = (_ProductsDropDown.SelectedItem as ComboBoxItem)!.Content.ToString() } });
            }
        }
    }
}