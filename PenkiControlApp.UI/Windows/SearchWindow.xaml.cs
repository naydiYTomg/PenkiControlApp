using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PenkiControlApp.UI.Controls;
using PenkiControlApp.UI.InternalTypes;
using EventManager = PenkiControlApp.UI.Controls.EventManager;

namespace PenkiControlApp.UI.Windows;

public partial class SearchWindow : UserControl, IEventListener
{
    private AllDatabaseData _database = AllDatabaseData.GetInstance();
    private int _currentFrameIndex = 0;
    private GifBitmapDecoder? _gifDecoder = null;
    public SearchWindow()
    {
        InitializeComponent();
        EventManager.OnEventOccurred += HandleEvent;
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        _currentFrameIndex = (_currentFrameIndex + 1) % _gifDecoder!.Frames.Count;
        LoadingGif.Source = _gifDecoder.Frames[_currentFrameIndex];
    }
    private async void SearchWindow_OnInitialized(object? sender, EventArgs e)
    {
        _gifDecoder = new GifBitmapDecoder(new Uri(Path.GetFullPath("Resources/GIFs/loading.gif")), BitmapCreateOptions.None, BitmapCacheOption.Default);
        LoadingGif.Source = _gifDecoder.Frames[_currentFrameIndex];
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(100)
        };
        timer.Tick += TimerTick;
        timer.Start();
        var progress = new Progress<int>(value => LoadingProgressBar.Value = value);
        var state = await LoadAllDataAsync(progress);
        if (state)
        {
            MainGrid.Children.Remove(LoadingProgressBar);
            MainGrid.Children.Remove(LoadingGif);
            MainGrid.Children.Remove(LoadingBackground);
            EventManager.TriggerEvent("SearchWindowInitialized");
        }
        
    }

    private async Task<bool> LoadAllDataAsync(IProgress<int> progress)
    {
        for (int i = 0; i <= 100; i++)
        {
            await Task.Run(_database.LoadData);
            progress.Report(i);
        }

        return true;
    }

    public void HandleEvent(string name)
    {
        switch (name)
        {
            case "OpenedSearchResultInfoWindow":
            {
                foreach (UIElement searchResultsChild in SearchResults.Children)
                {
                    searchResultsChild.IsEnabled = false;
                }

                break;
            }
            case "ClosedSearchResultInfoWindow":
            {
                foreach (UIElement searchResultsChild in SearchResults.Children)
                {
                    searchResultsChild.IsEnabled = true;
                }
                InfoPanel.Children.Clear();

                break;
            }
        }
    }
}