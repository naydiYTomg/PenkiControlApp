using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.UI.InternalTypes;

namespace PenkiControlApp.UI.Windows;

public partial class RegistrationWindow : UserControl
{
    private MainWindow _window;
    public RegistrationWindow(MainWindow window)
    {
        InitializeComponent();
        _window = window;
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (LoginField.Text.Equals("") || PasswordField.Text.Equals("") || NameField.Text.Equals("") || SurnameField.Text.Equals(""))
        {
            ErrorsLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Заполните все поля!",
                _ => "Fill in all fields for registration!"
            };
        }
        else if (App.UserManager.IsLoginExists(LoginField.Text))
        {
            ErrorsLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => $"Пользователь с логином {LoginField.Text} уже существует, попробуйте другой логин",
                _ => $"User with login {LoginField.Text} already exists, try another login"
            };
        }
        else
        {
            int id = App.UserManager.AddNewUser(NameField.Text, SurnameField.Text, LoginField.Text, PasswordField.Text, false, false);
            App.CurrentUser = new User { Name = NameField.Text, Surname = SurnameField.Text, Id = id };
            _window.TabManager.ChangeTab(1);
        }
        
    }

    private void RegistrationWindow_OnInitialized(object? sender, EventArgs e)
    {
        switch (App.UILanguage)
        {
            case InternalTypes.Language.Russian:
                RegisterInfoLabel.Content = "Заполните данные поля чтобы зарегестрироваться";
                RegisterInfoLabel.FontSize = 25;
                break;
            default:
                RegisterInfoLabel.Content = "Fill in this fields to register";
                break;
        }
    }
}