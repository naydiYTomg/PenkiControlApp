using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.UI.InternalTypes;
using Role = int;

namespace PenkiControlApp.UI.Windows;

public partial class LoginWindow : UserControl
{
    private readonly MainWindow _window;
    private readonly Role _role;
    public LoginWindow(MainWindow window, Role role)
    {
        InitializeComponent();
        _window = window;
        _role = role;
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (LoginField.Text.Equals("") || PasswordField.Text.Equals(""))
        {
            ErrorsLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Заполните все поля!",
                _ => "Fill in all fields for login!"
            };
        }
        else 
        {
            switch (_role)
            {
                case 1: // USER
                    if (!App.UserManager.TryLoginUser(LoginField.Text, PasswordField.Text))
                    {
                        ErrorsLabel.Content = App.UILanguage switch
                        {
                            InternalTypes.Language.Russian => "Пользователь не существует или неверный пароль!",
                            _ => "User not exists or wrong password!"
                        };
                    }
                    else
                    {
                        var user = App.UserManager.GetUserByLogin(LoginField.Text);
                        App.CurrentUser = new User { Name = user.Name, Id = user.Id, Surname = user.Surname };
                        _window.TabManager.ChangeTab(1);
                    }
                    break;
                case 2: // MANAGER
                    if (!App.UserManager.TryLoginManager(LoginField.Text, PasswordField.Text))
                    {
                        ErrorsLabel.Content = App.UILanguage switch
                        {
                            InternalTypes.Language.Russian => "Пользователь не существует или неверный пароль!",
                            _ => "User not exists or wrong password!"
                        };
                    }
                    else
                    {
                        var user = App.UserManager.GetManagerByLogin(LoginField.Text);
                        App.CurrentUser = new User { Name = user.Name, Id = user.Id, Surname = user.Surname, IsManager = true };
                        _window.TabManager.ChangeTab(1);
                    }
                    break;
                case 3: // ADMINISTRATOR
                    if (!App.UserManager.TryLoginAdmin(LoginField.Text, PasswordField.Text))
                    {
                        ErrorsLabel.Content = App.UILanguage switch
                        {
                            InternalTypes.Language.Russian => "Пользователь не существует или неверный пароль!",
                            _ => "User not exists or wrong password!"
                        };
                    }
                    else
                    {
                        var user = App.UserManager.GetAdministratorByLogin(LoginField.Text);
                        App.CurrentUser = new User { Name = user.Name, Id = user.Id, Surname = user.Surname, IsAdmin = true };
                        _window.TabManager.ChangeTab(1);
                    }
                    break;
            }
        }
        
        
    }

    private void LoginWindow_OnInitialized(object? sender, EventArgs e)
    {
        switch (App.UILanguage)
        {
            case InternalTypes.Language.Russian:
                LoginInfoLabel.Content = "Заполните эти поля чтобы войти";
                break;
            default:
                LoginInfoLabel.Content = "Fill in this fields to login";
                break;
        }
    }
}