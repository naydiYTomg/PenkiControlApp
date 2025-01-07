using PenkiControlApp.Core.InputModels;
using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.UI.InternalTypes;

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
        got.ForEach(x => { _ProductsDropDown.Items.Add(new ProductDropDownItem { Content = x.Name, Id = x.Id}); });

        var AllClients = App.ClientManager.GetAllClients();
        AllClients.ForEach(x => { _ClientsDropDown.Items.Add(new ComboBoxItem { Content = x.Name + " " + x.Surname }); });

    }
    private void ChosenProducts_OnSelected(object sender, SelectionChangedEventArgs e)
    {
        bool isChildrenHere = false;
        var selected = (_ProductsDropDown.SelectedItem as ProductDropDownItem)!;
        if (ProductContainer.Children.Count == 0)
        {
            ProductContainer.Children.Add(new ProductAddingElement(this) { _ProductNameToAdd = { Text = selected.Content.ToString() }, Id = selected.Id });
        }
        else
        {
            foreach (ProductAddingElement child in ProductContainer.Children)
            {
                if (child._ProductNameToAdd.Text == selected.Content.ToString())
                {
                    isChildrenHere = true;
                    child.ValueIncrease();
                }
            }
            if (!isChildrenHere)
            {
                ProductContainer.Children.Add(new ProductAddingElement(this) { _ProductNameToAdd = { Text = selected.Content.ToString() }, Id = selected.Id});
            }
        }
    }
    private void Sell_click(object sender, EventArgs e)
    {
        if ((_ClientsDropDown.SelectedItem as ComboBoxItem) != null)
        {
            string[] nameAndSurname = _ClientsDropDown.Text.Split(" ");
            var client = App.ClientManager.GetClientIdByNameAndSurname(nameAndSurname[0], nameAndSurname[1]);
            MessageBox.Show(client.ToString());
            var orderId = App.OrderManager.InsertOrder(new OrderInputModel { ClientId = client, Sum = 1, Date = (int)DateTime.Now.ToFileTime(), UserId = 1});
            MessageBox.Show(orderId.ToString());
            
            
            if (ProductContainer.Children.Count != 0)
            {
                List<int> counts = [];
                List<ProductToOrderInputModel> products = [];
                foreach (ProductAddingElement child in ProductContainer.Children)
                {
                    products.Add(new ProductToOrderInputModel{ Id = child.Id });
                    counts.Add(int.Parse(child._ProductToAddQuantity.Text));
                }
                App.OrderProductRelManager.AddNewProductToOrder(products, orderId, counts.ToArray());
            }
        }
    }
}