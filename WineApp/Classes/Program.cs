using ConsoleConfigurationLibrary.Classes;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace WineApp;
internal partial class Program
{
    /// <summary>
    /// Initializes the application by setting up the console window, configuring services, 
    /// </summary>
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();

        setup.GetConnectionStrings();
        
    }
}
