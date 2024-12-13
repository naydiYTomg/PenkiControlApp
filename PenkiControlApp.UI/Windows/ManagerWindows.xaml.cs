using System.Windows.Controls;


namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ManagerWindows.xaml
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
