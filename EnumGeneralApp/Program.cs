using static EnumGeneralApp.EnumUtils;

namespace EnumGeneralApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var map = EnumNamedValues<Rainbow>();

        foreach (var pair in map)
        {
            Console.WriteLine($"{pair.Key,-4}{pair.Value}");
        }

        var map1 = ParseEnum<Rainbow>("green", Rainbow.Blue);
        var map2 = ParseEnum("green", Rainbow.Blue);

        Console.WriteLine(map1);
        Console.WriteLine(map2);

        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }

    /*
     * https://github.com/dotnet/samples/blob/3ee82879284e3f4755251fd33c3b3e533f7b3485/snippets/csharp/keywords/GenericWhereConstraints.cs#L180-L190
     */
}