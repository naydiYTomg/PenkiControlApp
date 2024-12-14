
using System.Windows;
using System.Windows.Controls;


namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ProductWindows.xaml
    /// </summary>
    public partial class ProductContainer : UserControl
    {
        public int Id { get; init; }
        private readonly ProductWindows _parent;
        public ProductContainer(ProductWindows parent)
        {
            InitializeComponent();
            _parent = parent;
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _parent.ProductId.Content = Id;
            _parent.ProductName.Content = NameLabel.Content;
        }
    }
}
