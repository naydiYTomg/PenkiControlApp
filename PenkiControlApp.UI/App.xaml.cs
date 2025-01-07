using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using PenkiControlApp.BLL;
using PenkiControlApp.Logging;
using PenkiControlApp.UI.InternalTypes;

namespace PenkiControlApp.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
///
public partial class App : Application
{
    private readonly PCALogger _logger = PCALogger.GetInstance();
    public static readonly UserManager UserManager = new();
    public static readonly ClientManager ClientManager = new();
    public static readonly ProductManager ProductManager = new();
    public static readonly CategoryManager CategoryManager = new();
    public static readonly TagManager TagManager = new();
    public static readonly ProductTagRelManager ProductTagRelManager = new();
    public static readonly OrderManager OrderManager = new();
    public static readonly OrderProductRelManager OrderProductRelManager = new();
    public static User? CurrentUser { get; set; }
    public static Language UILanguage { get; set; }
    private void App_OnExit(object sender, ExitEventArgs e)
    {
        _logger.OnExit();
    }

    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        CultureInfo ci = CultureInfo.InstalledUICulture;
        UILanguage = ci.TwoLetterISOLanguageName switch
        {
            "ru" => Language.Russian,
            "en" => Language.English,
            _ => Language.Other
        };
    }
}