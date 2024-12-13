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
    /// Interaction logic for ProductWindows.xaml
    /// </summary>
    public partial class Container : UserControl
    {
        public int Id { get; set; }
        private ManagerWindows _parent;
        public Container(ManagerWindows parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void _Information_OnClick(object sender, RoutedEventArgs e)
        {
            _parent.Name.Text = (string)_Information.Content;
            _parent.ManagerId.Content = Id;
        }
    }
}
