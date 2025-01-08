using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.UI.InternalTypes.ComboBoxItems;


namespace PenkiControlApp.UI.Windows
{
    
    
    /// <summary>
    /// Interaction logic for ManagerWindows.xaml
    ///
    /// 
    /// </summary>
    public partial class ManagerWindows : UserControl
    {
        private bool _isMakingOpened = false;
        public ManagerWindows()
        {
            InitializeComponent();
            
        }

        private void ManagerWindows_OnInitialized(object? sender, EventArgs e)
        {
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Менеджеры",
                _ => InfoLabel.Content
            };
            ButtonMakeHimManager.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Сделать его менеджером",
                _ => "Make him a manager"
            };
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

        private void ButtonMakeManager_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isMakingOpened)
            {
                ButtonMakeManager.Content = 'x';
                GridManagerMaking.Visibility = Visibility.Visible;
                _isMakingOpened = true;
                var users = App.UserManager.GetUsersWhoIsNotManagers();
                ComboBoxUsers.Items.Clear();
                users.ForEach(x =>
                {
                    ComboBoxUsers.Items.Add(new UserForManagerMakingComboBoxItem()
                        { Id = x.Id, Content = $"{x.Name} {x.Surname}" });
                });
            }
            else
            {
                ButtonMakeManager.Content = '+';
                GridManagerMaking.Visibility = Visibility.Collapsed;
                _isMakingOpened = false;
            }
        }

        private void ButtonMakeHimManager_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isMakingOpened)
            {
                if (ComboBoxUsers.SelectedIndex != -1)
                {
                    var selected = (ComboBoxUsers.SelectedItem as UserForManagerMakingComboBoxItem)!;
                    App.UserManager.MakeUserManager(selected.Id);
                    ButtonMakeManager.Content = '+';
                    GridManagerMaking.Visibility = Visibility.Collapsed;
                    _isMakingOpened = false;
                }
            }
        }
    }
}
