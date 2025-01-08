using PenkiControlApp.DAL;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace PenkiControlApp.UI.Windows;

public partial class CategoryWindow : UserControl
{
    private readonly TagRepository _repository = new();
    public int Id { get; init; }
    
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
    private void CategoryWindow_OnInitialized(object? sender, EventArgs e) //, int CurrentCategoryId
    {
        //MessageBox.Show("lock in");
        //Tags.Children.Add(new CategoryWindowTag());
        //var categories = App.CategoryManager.GetCategories();
        //categories.ForEach(x =>
        //{
            //MessageBox.Show(x.Name.ToString());
            //NameOfCategory.Text = x.Name;
        //    Tags.Children.Add(new CategoryWindowTag());
        //});

        //NameOfCategory = { Text = x.Name }
        var tags = App.TagManager.GetAllTagsByCategoryId(TagsNCategoriesWindow.categoryNumber);
        
        
        //MessageBox.Show("HEY "+ TagsNCategoriesWindow.categoryNumber.ToString());
        TagsNCategoriesWindow.categoryNumber = TagsNCategoriesWindow.categoryNumber + 1;
        tags.ForEach(x =>
        {
            var tag = new CategoryWindowTag(this)
            {
                TagName = { Text = x.Name },
                Id = x.Id
            };
            Tags.Children.Add(tag);
        });

    }
}