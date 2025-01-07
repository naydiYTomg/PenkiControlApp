using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class CategoryWindow : UserControl
{
    public CategoryWindow()
    {
        InitializeComponent();
        //NameOfCategory.Text = App.UILanguage switch
        //{
        //    InternalTypes.Language.English or InternalTypes.Language.Other => "PlaceholderCategory",
        //    InternalTypes.Language.Russian => "КатегорияЗаполнитель",
        //    _ => NameOfCategory.Text
        //};
    }
    private void CategoryWindow_OnInitialized(object? sender, EventArgs e)
    {
        //MessageBox.Show("lock in");
        //Tags.Children.Add(new CategoryWindowTag());
        var categories = App.CategoryManager.GetCategories();
        categories.ForEach(x =>
        {
            MessageBox.Show(x.Name.ToString());
            NameOfCategory.Text = x.Name;
        }

        );
    }
}