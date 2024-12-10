using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows;

public partial class TagsNCategoriesWindow : UserControl
{
    public MainWindow MainWindow { get; set; }
    public TagsNCategoriesWindow(MainWindow window)
    {
        this.MainWindow = window;
        InitializeComponent();
    }

    private void TagsNCategoriesWindow_OnInitialized(object? sender, EventArgs e)
    {
        Console.WriteLine("Initialized tags & categories");
        MainWindow.WindowInitialized(this);
        // throw new NotImplementedException();
    }
}