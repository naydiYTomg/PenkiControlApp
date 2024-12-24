using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class TagCheckbox : UserControl
{
    public int Id { get; private set; }
    public TagCheckbox(int id)
    {
        InitializeComponent();
        Id = id;
    }
}