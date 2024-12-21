using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;

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
            ErrorsLabel.Content = "Fill in all fields for registration!";
        }
        else if (App.UserManager.IsLoginExists(LoginField.Text))
        {
            ErrorsLabel.Content = $"User with login {LoginField.Text} already exists, try another login";
        }
        else
        {
            App.UserManager.AddNewUser(NameField.Text, SurnameField.Text, LoginField.Text, PasswordField.Text, false, false);
            _window.TabManager.ChangeTab(1);
        }
        
    }
}