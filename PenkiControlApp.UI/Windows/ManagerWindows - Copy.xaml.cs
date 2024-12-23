using System.Windows;
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
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Менеджеры",
                _ => InfoLabel.Content
            };
        }


        private void AddManagerWindows_OnInitialized(object? sender, EventArgs e)
        {
            var result = App.UserManager.GetAllManagers();
            result.ForEach(x =>
            {
                var manager = new ManagerContainer(this)
                {
                    Id = x.Id,
                    NameLabel =
                    {
                        Content = x.Name
                    },
                    SurnameLabel =
                    {
                        Content = x.Surname
                    }
                };
                ManagersContent.Children.Add(manager);
            });

        }
    }
}
