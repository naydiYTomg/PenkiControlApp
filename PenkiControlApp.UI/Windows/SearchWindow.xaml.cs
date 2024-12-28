using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PenkiControlApp.UI.InternalTypes;

namespace PenkiControlApp.UI.Windows;

public partial class SearchWindow : UserControl
{
    private AllDatabaseData _database = AllDatabaseData.GetInstance();
    private int _currentFrameIndex = 0;
    private GifBitmapDecoder? _gifDecoder = null;
    public SearchWindow()
    {
        InitializeComponent();
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
}