using System.Windows;
using System.Windows.Controls;
using PenkiControlApp.Core.OutputModels;
using EventManager = PenkiControlApp.UI.Controls.EventManager;

namespace PenkiControlApp.UI.Windows;

public partial class SearchResultContainer : UserControl
{
    public IOutputModel Data { get; set; }
    private SearchWindow _parent;
    public SearchResultContainer(SearchWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }


    private void ButtonOpenInfo_OnClick(object sender, RoutedEventArgs e)
    {
        EventManager.TriggerEvent("OpenedSearchResultInfoWindow");
        if (Data is ProductForDisplayingOutputModel pData)
        {
            _parent.InfoPanel.Children.Add(new AboutSearchResultWindow(_parent) { InfoLabel1 =
            {
                Content = $"Name: {pData.Name}"
            }, InfoLabel2 =
            {
                Content = $"Cost: {pData.Cost}"
            }, InfoLabel3 =
            {
                Content = $"Category: {pData.CategoryName}"
            }, InfoLabel4 =
            {
                Content = $"Id: {pData.Id}"
            }});
        } else if (Data is CategoryOutputModel cData)
        {
            _parent.InfoPanel.Children.Add(new AboutSearchResultWindow(_parent)
            {
                InfoLabel1 =
                {
                    Content = $"Name: {cData.Name}"
                },
                InfoLabel2 =
                {
                    Content = $"Id: {cData.Id}"
                }
            });
        } else if (Data is ClientForSearchOutputModel clData)
        {
            _parent.InfoPanel.Children.Add(new AboutSearchResultWindow(_parent)
            {
                InfoLabel1 =
                {
                    Content = $"Name: {clData.Name}"
                },
                InfoLabel2 =
                {
                    Content = $"Surname: {clData.Surname}"
                },
                InfoLabel3 =
                {
                    Content = $"Id: {clData.Id}"
                },
                InfoLabel4 =
                {
                    Content = $"Age: {clData.Age}"
                }
            });
        } else if (Data is OrderForDisplayingOutputModel oData)
        {
            _parent.InfoPanel.Children.Add(new AboutSearchResultWindow(_parent)
            {
                InfoLabel1 =
                {
                    Content = $"Id: {oData.Id}"
                },
                InfoLabel2 =
                {
                    Content = $"Sum: {oData.Sum}"
                },
                InfoLabel3 =
                {
                    Content = $"Date: {oData.Date}"
                },
                InfoLabel4 =
                {
                    Content = $"ClientId: {oData.ClientId}"
                },
                OtherInfo =
                {
                    Text = $"UserId: {oData.UserId}"
                }
            });
        } else if (Data is TagForDisplayingOutputModel tData)
        {
            _parent.InfoPanel.Children.Add(new AboutSearchResultWindow(_parent)
            {
                InfoLabel1 =
                {
                    Content = $"Name: {tData.Name}"
                },
                InfoLabel2 =
                {
                    Content = $"Id: {tData.Id}"
                },
                InfoLabel3 =
                {
                    Content = $"CategoryId: {tData.CategoryId}"
                }
            });
        }
        else
        {
            Console.WriteLine("oh no");
        }
    }
}