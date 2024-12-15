using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class LoginRegistrationWindow : UserControl
{
    public LoginRegistrationWindow()
    {
        InitializeComponent();
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
            InternalTypes.Language.Russian => "Зарегестрироваться",
            _ => Register.Content
        };
    }
}