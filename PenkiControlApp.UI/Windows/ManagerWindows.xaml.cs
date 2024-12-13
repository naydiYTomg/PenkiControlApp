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
    public partial class ManagerWindows : UserControl
    {
        public ManagerWindows()
        {
            InitializeComponent();
        }

        private void ManagerWindows_OnInitialized(object? sender, EventArgs e)
        {
            var result = App.UserManager.GetAllManagers();
            result.ForEach(x =>
            {
                var manager = new Container(this)
                {
                    Id = x.Id,
                    _Information =
                    {
                        Content = x.Name
                    }
                };
                ManagersContent.Children.Add(manager);
            });
        }
    }
}
