using System.Windows;
using System.Windows.Controls;

namespace PenkiControlApp.UI.Windows
{

    public partial class TagsNCategoriesWindow : UserControl

    {
        public static int categoryNumber = 1;
        public TagsNCategoriesWindow()
        {

            InitializeComponent();
            categoryNumber = 1;
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

                
                var category = new CategoryWindow()
                {
                    Id = x.Id,

                    NameOfCategory = { Text = x.Name }
                };
                //MessageBox.Show(x.Id.ToString());
                CategoriesList.Children.Add(category);
            });
        }
    }
}
