using System.Windows.Controls;


namespace PenkiControlApp.UI.Windows
{

    public partial class AddManagerWindows : UserControl
    {

        public AddManagerWindows()
        {

            InitializeComponent();
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Добавление менеджеров",
                _ => InfoLabel.Content
            };
        }



        private void ManagerWindows_OnInitialized(object? sender, EventArgs e)
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
