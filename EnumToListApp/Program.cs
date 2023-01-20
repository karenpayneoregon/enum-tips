using EnumToListApp.Classes;

namespace EnumToListApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]All[/]");

        List<BookCategories> all = Enum.GetValues(typeof(BookCategories))
            .Cast<BookCategories>()
            .ToList();

        foreach (var cat in all)
        {
            Console.WriteLine($"\t{cat}");
        }


        AnsiConsole.MarkupLine("[yellow]Discard[/] [cyan]Select[/] [yellow]member[/]");
        List<BookCategories> noSelect = Enum.GetValues(typeof(BookCategories))
            .Cast<BookCategories>()
            .Where(x => x != BookCategories.Select)
            .ToList();

        foreach (var cat in noSelect)
        {
            Console.WriteLine($"\t{cat}");
        }


        AnsiConsole.MarkupLine("[yellow]Sorted list of string[/]");

        /*
         * Create a list and sort ascending
         */
        List<string> list = EnumToList(typeof(BookCategories)).OrderBy(x => x).ToList();

        foreach (var cat in list)
        {
            Console.WriteLine($"\t{cat}");
        }


        AnsiConsole.MarkupLine("[yellow]Member as int[/]");

        foreach (var value in Enum.GetValues(typeof(BookCategories)).Cast<int>().ToList())
        {
            Console.WriteLine($"\t{value}");
        }

        Console.ReadLine();
    }

    public static List<string> EnumToList(Type sender) 
        => Enum.GetNames(sender).ToList();
}
