using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class LoginRegistrationWindow : UserControl
{
    private MainWindow _window;
    public LoginRegistrationWindow(MainWindow mainWindow)
    {
        InitializeComponent();
        _window = mainWindow;
        LoginAs.Content = App.UILanguage switch
        {
            InternalTypes.Language.Russian => "Войти как...",
            _ => LoginAs.Content
        };
        AsWorker.Content = App.UILanguage switch
        {
            InternalTypes.Language.Russian => "Работник",
            _ => AsWorker.Content
        };
        AsManager.Content = App.UILanguage switch
        {
            InternalTypes.Language.Russian => "Менеджер",
            _ => AsManager.Content
        };
        AsAdmin.Content = App.UILanguage switch
        {
            InternalTypes.Language.Russian => "Администратор",
            _ => AsAdmin.Content
        };
        Register.Content = App.UILanguage switch
        {
            InternalTypes.Language.Russian => "Зарегистрироваться",
            _ => Register.Content
        };
    }

    private void Register_OnClick(object sender, RoutedEventArgs e)
    {
        Container.Children.RemoveRange(1, Container.Children.Count-1);
        var window = new RegistrationWindow(_window);
        Grid.SetColumnSpan(window, 2);
        Container.Children.Add(window);
    }
}