using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class CategoryWindowTag : UserControl
{
    private readonly CategoryWindow _parent;
    public int Id { get; init; }
    public CategoryWindowTag(CategoryWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }
}