using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class CurrentUserWindow : UserControl
{
    private MainWindow _window;
    public CurrentUserWindow(MainWindow window)
    {
        InitializeComponent();
        _window = window;
    }

    private void CurrentUserWindow_OnInitialized(object? sender, EventArgs e)
    {
        var cur = App.CurrentUser!;
        switch (App.UILanguage)
        {
            case InternalTypes.Language.Russian:
                InfoLabel.Content = "Текущий пользователь";
                LabelUsername.Content = $"Логин: {cur.Id}";
                LabelName.Content = $"Имя: {cur.Name}";
                LabelSurname.Content = $"Фамилия: {cur.Surname}";
                OnlyLocLabelPassword.Content = $"Пароль: *****";
                ButtonLogout.Content = $"Выйти";
                if (cur.IsAdmin)
                {
                    TBAdditional.Text = "Вы администратор";
                } else if (cur.IsManager)
                {
                    TBAdditional.Text = "Вы менеджер";
                }
                break;
            default:
                InfoLabel.Content = "Current user";
                LabelUsername.Content = $"Login: {cur.Id}";
                LabelName.Content = $"Name: {cur.Name}";
                LabelSurname.Content = $"Surname: {cur.Surname}";
                OnlyLocLabelPassword.Content = $"Password: *****";
                ButtonLogout.Content = $"Logout";
                if (cur.IsAdmin)
                {
                    TBAdditional.Text = "You are an administrator";
                } else if (cur.IsManager)
                {
                    TBAdditional.Text = "You are a manager";
                }
                break;
        }
    }

    private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
    {
        _window.TabManager.ChangeTab(1);
        App.CurrentUser = null;
    }
}