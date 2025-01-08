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
        
        var tags = App.TagManager.GetAllTagsByCategoryId(TagsNCategoriesWindow.categoryNumber);
        
        
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