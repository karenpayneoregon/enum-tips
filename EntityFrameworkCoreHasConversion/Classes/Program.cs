using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace HasConversion;

partial class Program
{

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: EF Core with enum";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
}