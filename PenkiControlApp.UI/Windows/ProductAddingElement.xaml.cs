using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ProductAddingElement.xaml
    /// </summary>
    public partial class ProductAddingElement : UserControl
    {
        public int Id { get; init; }
        public ProductAddingElement()
        {
            InitializeComponent();
        }
    }
}
