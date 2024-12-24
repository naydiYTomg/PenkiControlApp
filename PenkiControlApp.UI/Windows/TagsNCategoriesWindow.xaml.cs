using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class TagsNCategoriesWindow : UserControl
{
 
    public TagsNCategoriesWindow()
    {
        InitializeComponent();
        InfoLabel.Content = App.UILanguage switch
        {
            InternalTypes.Language.English or InternalTypes.Language.Other => "Tags & Categories",
            InternalTypes.Language.Russian => "Тэги & Категории",
            _ => InfoLabel.Content
        };
    }

    private void CategoryWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}