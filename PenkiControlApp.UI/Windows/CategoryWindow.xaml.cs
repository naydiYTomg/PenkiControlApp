using System.Text;
using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.Core.OutputModels;

namespace PenkiControlApp.UI.Windows;

public partial class CategoryWindow : UserControl
{
    private int Id { get; init; }
    private List<TagOutputModel>? _tags;
    private TagsNCategoriesWindow _parent;
    public CategoryWindow(int id, TagsNCategoriesWindow parent)
    {
        Id = id;
        _parent = parent;
        InitializeComponent();
    }
    
    private void CategoryWindow_OnInitialized(object? sender, EventArgs e)
    {
        var tags = App.TagManager.GetTagsByCategoryId(Id);
        _tags = tags;
        
        tags.Take(6).ToList().ForEach(x =>
        {
            Tags.Children.Add(new TagContainer { LabelTagName = { Text = x.Name }, Width = 120, HorizontalAlignment = HorizontalAlignment.Center});
        });
    }

    private void About_OnClick(object sender, RoutedEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        _tags!.ForEach(x =>
        {
            sb.AppendLine(x.Name);
        });
        var temp = new AboutCategoryWindow(_parent) { TBTags = { Text = sb.ToString() } };
        Grid.SetRowSpan(temp, 3);
        _parent.GridMain.Children.Add(temp);
    }
}