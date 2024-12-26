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
    public partial class SellsWindows : UserControl
    {
        public SellsWindows()
        {
            InitializeComponent();
            var ProductAddingListStackPanel = (StackPanel)this.FindName("ProductAddingListStackPanel");
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            ProductAddingListStackPanel.Children.Add(new ProductAddingElement());
            //var ProductAddingListStackPanel = (TextBlock)this.FindName("myTextBlock");
        }
    }
}