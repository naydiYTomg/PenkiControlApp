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
    public partial class ManagerContainer : UserControl
    {
        public int Id { get; init; }
        private readonly ManagerWindows _parent;
        public ManagerContainer(ManagerWindows parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void _Information_OnClick(object sender, RoutedEventArgs e)
        {
            _parent.Name.Text = NameLabel.Content.ToString();
            _parent.ManagerId.Content = Id;
            _parent.Surname.Text = SurnameLabel.Content.ToString();
        }
    }
}
