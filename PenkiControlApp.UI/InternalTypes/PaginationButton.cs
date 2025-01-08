using System.Windows.Controls;
using PenkiControlApp.UI.Windows;

namespace PenkiControlApp.UI.InternalTypes;

public class PaginationButton(TagsNCategoriesWindow parent) : Button
{
    private TagsNCategoriesWindow _parent = parent;

    protected override void OnClick()
    {
        _parent.ChangePage(int.Parse(Content.ToString()!));
    }
}