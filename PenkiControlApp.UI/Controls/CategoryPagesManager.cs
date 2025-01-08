using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.UI.Windows;

namespace PenkiControlApp.UI.Controls;
using Page = int;

public class CategoryPagesManager
{
    private Page _pagesCount = 0;
    private Page _current = 0;
    private List<List<CategoryOutputModel>> _pages;
    private TagsNCategoriesWindow _parent;
    private PaginationElement _paginationElement;

    public CategoryPagesManager(Page count, TagsNCategoriesWindow window, List<List<CategoryOutputModel>> pages, PaginationElement paginationElement)
    {
        _pagesCount = count;
        _parent = window;
        _pages = pages;
        _paginationElement = paginationElement;
    }
    public void ChangePage(Page @new, bool isFirst) {
        try
        {
            _parent.GridCategories.Children.Clear();
            foreach (var (i, val) in _pages[@new].Select((val, index) => (index, val)))
            {
                var wind = new CategoryWindow(val.Id, _parent)
                {
                    NameOfCategory =
                    {
                        Content = val.Name
                    },
                    Width = 300
                };
                Grid.SetColumn(wind, i);
                _parent.GridCategories.Children.Add(wind);
            }

            if (!isFirst)
            {
                UpdateButtons(@new);
            }
            _current = @new;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void UpdateButtons(Page except)
    {
        foreach (UIElement button in _paginationElement.PanelButtons.Children)
        {
            button.IsEnabled = true;
        }

        _paginationElement.PanelButtons.Children[except].IsEnabled = false;
    }
}