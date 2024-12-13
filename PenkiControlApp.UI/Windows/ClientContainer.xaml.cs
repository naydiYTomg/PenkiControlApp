
using System.Windows;
using System.Windows.Controls;


namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ProductWindows.xaml
    /// </summary>
    public partial class ClientContainer : UserControl
    {
        public int Id { get; init; }
        private readonly ClientWindows _parent;
        public ClientContainer(ClientWindows parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            _parent.Nick.Content = NameLabel.Content.ToString();
            _parent.ClientId.Content = Id;
        }
    }
}
