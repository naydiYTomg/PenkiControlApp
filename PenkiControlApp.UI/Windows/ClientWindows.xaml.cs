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
    public partial class ClientWindows : UserControl
    {
        public ClientWindows()
        {
            InitializeComponent();
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Клиенты",
                _ => InfoLabel.Content
            };
        }

        private void ClientWindows_OnInitialized(object? sender, EventArgs e)
        {
            var clients = App.ClientManager.GetAllClients();
            clients.ForEach(x =>
            {
                var client = new ClientContainer(this)
                {
                    NameLabel =
                    {
                        Content = x.Name
                    },
                    SurnameLabel =
                    {
                        Content = x.Surname
                    },
                    Id = x.Id
                };
                ClientsContent.Children.Add(client);
            });
        }
    }
}
