using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class CategoryWindow : UserControl
{
    public CategoryWindow()
    {
        InitializeComponent();
        NameOfCategory.Content = App.UILanguage switch
        {
            InternalTypes.Language.English or InternalTypes.Language.Other => "PlaceholderCategory",
            InternalTypes.Language.Russian => "КатегорияЗаполнитель",
            _ => NameOfCategory.Content
        };
    }
}