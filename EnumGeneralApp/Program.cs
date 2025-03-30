using static EnumGeneralApp.Classes.EnumUtils;

namespace EnumGeneralApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var map = ToDictionary<Rainbow>();
        foreach (var pair in map)
        {
            Console.WriteLine($"{pair.Key,-4}{pair.Value}");
        }

        var map1 = ParseEnum<Rainbow>("green", Rainbow.Blue);
        var map2 = ParseEnum("green", Rainbow.Blue);

        Console.WriteLine(map1);
        Console.WriteLine(map2);

        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }

}