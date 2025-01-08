using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.UI.Controls;
using PenkiControlApp.UI.InternalTypes;

namespace PenkiControlApp.UI.Windows;

public partial class TagsNCategoriesWindow : UserControl
{
    private CategoryPagesManager? _pagesManager = null;
 
    public TagsNCategoriesWindow()
    {
        InitializeComponent();
        
    }


    private void TagsNCategoriesWindow_OnInitialized(object? sender, EventArgs e)
    {
        InfoLabel.Content = App.UILanguage switch
        {
            InternalTypes.Language.English or InternalTypes.Language.Other => "Tags & Categories",
            InternalTypes.Language.Russian => "Тэги & Категории",
            _ => InfoLabel.Content
        };

        var categories = App.CategoryManager.GetCategories();
        // categories.Add(new CategoryOutputModel() { Name = "Yo1", Id = 3 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo2", Id = 4 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo3", Id = 5 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo4", Id = 6 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo5", Id = 7 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo6", Id = 8 });
        // categories.Add(new CategoryOutputModel() { Name = "Yo7", Id = 9 });
        if (categories.Count <= 3)
        {
            foreach (var (i, val) in categories.Select((val, index) => (index, val)))
            {
                var wind = new CategoryWindow(val.Id, this)
                {
                    NameOfCategory =
                    {
                        Content = val.Name
                    },
                    Width = 300
                };
                Grid.SetColumn(wind, i);
                GridCategories.Children.Add(wind);
            }
        }
        else
        {
            var loadedCategories = categories.SplitChunks(3);
            var pagesCount = loadedCategories.Count;
            var paginationElement = new PaginationElement() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
            _pagesManager = new CategoryPagesManager(pagesCount, this, loadedCategories, paginationElement);
            Grid.SetRow(paginationElement, 2);
            _pagesManager.ChangePage(0, true);
            foreach (var i in Enumerable.Range(1, pagesCount))
            {
                paginationElement.PanelButtons.Children.Add(new PaginationButton(this) { Content = i, Width = 20, Height = 20, Margin = new Thickness(10, 0, 0, 0)});
            }
            
            GridMain.Children.Add(paginationElement);
            

        }
        
    }

    public void ChangePage(int @new)
    {
        _pagesManager!.ChangePage(@new - 1, false);
    }
}