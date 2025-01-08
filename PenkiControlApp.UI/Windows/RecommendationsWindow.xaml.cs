using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.BLL;
using PenkiControlApp.UI.InternalTypes;
using PenkiControlApp.UI.InternalTypes.ComboBoxItems;

namespace PenkiControlApp.UI.Windows;

public partial class RecommendationsWindow : UserControl
{
    public RecommendationsWindow()
    {
        InitializeComponent();
    }

    private void RecommendationsWindow_OnInitialized(object? sender, EventArgs e)
    {
        switch (App.UILanguage)
        {
            case InternalTypes.Language.Russian:
                List<string> labelsRu = ["Посчитать!", "Рекомендовать!", "Получить!"];
                CalculateButton.Content = labelsRu.Choice();
                LabelChoose.Content = "Выберите клиента: ";
                break;
            default:
                List<string> labelsEn = ["Calculate!", "Recommend!", "Get!"];
                CalculateButton.Content = labelsEn.Choice();
                LabelChoose.Content = "Choose client: ";
                break;
        }
        var clients = App.ClientManager.GetAllClients();
        clients.ForEach(x =>
        {
            ClientsComboBox.Items.Add(new ClientForRecommendationsComboBoxItem
                { Id = x.Id, Content = $"{x.Name} {x.Surname}" });
        });
    }

    private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (ClientsComboBox.SelectedIndex != -1)
        {
            RecommendationsPanel.Children.Clear();
            var selected = (ClientsComboBox.SelectedItem as ClientForRecommendationsComboBoxItem)!;
            var tags = App.ClientManager.GetClientFavoriteTags(selected.Id, 3);
            List<int> tagIds = [];
            tags.ForEach(x =>
            {
                tagIds.Add(x.Id);
            });
            var got = App.ProductManager.GetRecommendedProductsByIds(tagIds.ToArray());
            got.ForEach(async x =>
            {
                RecommendationsPanel.Children.Add(new RecommendationContainer { IdLabel =
                {
                    Content = $"ID: {x.Id}"
                }, NameLabel =
                {
                    Content = x.Name
                }, CategoryLabel =
                {
                    Content = $"{App.UILanguage switch 
                    {
                        InternalTypes.Language.Russian => "в категории",
                        _ => "in category"
                    }} {x.CategoryName}"
                }, CostLabel =
                {
                    Content = $"{App.UILanguage switch 
                    {
                        InternalTypes.Language.Russian => "Цена",
                        _ => "Cost"
                    }}: {App.UILanguage switch 
                     {
                         InternalTypes.Language.Russian => x.Cost,
                         _ =>(int) await CBRUtils.ConvertToDollars(x.Cost)
                     }}{App.UILanguage switch
                    {
                        InternalTypes.Language.Russian => "\u20bd",
                        _ => "$",
                    }}"
                }, Height = 70});
            });
        }
    }
}