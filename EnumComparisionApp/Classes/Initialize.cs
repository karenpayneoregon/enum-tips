using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;

namespace EnumComparisionApp.Classes;
internal class Initialize
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight + 4);
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
