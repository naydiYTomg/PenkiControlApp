using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ProductAddingElement.xaml
    /// </summary>
    public partial class ProductAddingElement : UserControl
    {
        private long amount = 0;
        public int Id { get; init; }
        public ProductAddingElement()
        {
            InitializeComponent();
        }
        private void ProductToAddMinus_OnClick(object sender, RoutedEventArgs e)
        {
            if (amount > 0)
            {
                amount--;
                _ProductToAddQuantity.Text = amount.ToString();
            }
            if (amount == 0)
            {
                var element = sender as Button;
                var parent = element.Parent as StackPanel;
                parent?.Children.Remove(element);
            }
        }
        private void ProductToAddPlus_OnClick(object sender, RoutedEventArgs e)
        {
            if (amount < 999999999999999)
            {
                amount++;
                _ProductToAddQuantity.Text = amount.ToString();
            }
        }
    }
}
