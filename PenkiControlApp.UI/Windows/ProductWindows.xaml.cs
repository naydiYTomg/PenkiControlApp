﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PenkiControlApp.UI.Windows
{
    /// <summary>
    /// Interaction logic for ProductWindows.xaml
    /// </summary>
    public partial class ProductWindows : UserControl
    {
        private MainWindow _window;
        public ProductWindows(MainWindow window)
        {
            InitializeComponent();
            _window = window;
            InfoLabel.Content = App.UILanguage switch
            {
                InternalTypes.Language.Russian => "Продукты",
                _ => InfoLabel.Content
            };
        }

        private void ProductWindows_OnInitialized(object? sender, EventArgs e)
        {
            var result = App.ProductManager.GetAllProducts();
            result.ForEach(x =>
            {
                var product = new ProductContainer(this)
                {
                    Id = x.Id,
                    NameLabel =
                    {
                        Content = x.Name
                    },
                    CategoryLabel =
                    {
                        Content = $":{x.CategoryName}"
                    },
                    CostLabel =
                    {
                        Content = $"{x.Cost}$"
                    }
                };
                ProductsContent.Children.Add(product);
            });
        }

        private void CreateProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            _window.TabManager.ChangeTab(7);
        }
    }
}
