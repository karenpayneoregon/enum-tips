using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace EnumGeneralApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private enum MyEnum { Yes = 10, No = 20, Okay = 30 }
    enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }



}

public static class EnumUtils
{
    public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
        if (string.IsNullOrEmpty(value)) return defaultValue;

        foreach (T item in Enum.GetValues(typeof(T)))
        {
            if (item.ToString()!.ToLower().Equals(value.Trim().ToLower()))
            {
                return item;
            }
        }
        return defaultValue;
    }
    public static Dictionary<int, string> EnumNamedValues<T>() where T : Enum
    {
        var result = new Dictionary<int, string>();
        var values = Enum.GetValues(typeof(T));

        foreach (int item in values)
        {
            result.Add(item, Enum.GetName(typeof(T), item));
        }

        return result;
    }
}