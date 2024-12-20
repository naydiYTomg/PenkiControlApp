﻿using System.Configuration;
using System.Data;
using System.Windows;
using PenkiControlApp.Logging;

namespace PenkiControlApp.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
///
public partial class App : Application
{
    private readonly PCALogger _logger = PCALogger.GetInstance();
    private void App_OnExit(object sender, ExitEventArgs e)
    {
        _logger.OnExit();
    }
}