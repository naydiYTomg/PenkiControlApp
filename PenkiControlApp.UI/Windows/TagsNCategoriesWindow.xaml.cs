using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows
{
    public partial class TagsNCategoriesWindow : UserControl
    {
        public TagsNCategoriesWindow()
        {
            InitializeComponent();
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.English or InternalTypes.Language.Other => "Tags & Categories",
                InternalTypes.Language.Russian => "Тэги & Категории",
                _ => InfoLabel.Content
            };
        }

        private void TagsNCategoriesWindow_OnInitialized(object? sender, EventArgs e)
        {
            var categories = App.CategoryManager.GetCategories();
            categories.ForEach(x =>
            {
                MessageBox.Show(x.Name.ToString());

                var category = new CategoryWindow()
                {
                    //Id = x.Id,
                    NameOfCategory = { Text = x.Name }
                };

                CategoriesList.Children.Add(category);
            });
        }
    }
}
