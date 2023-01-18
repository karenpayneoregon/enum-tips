using EnumGetDescriptionsApp.Classes;

namespace EnumGetDescriptionsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Enum descriptions[/]");

        List<KeyValuePair<string, Enum>> result = EnumHelper.GetItemsAsDictionary<BookCategories>();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Value,-20} {item.Key}");
        }

        Console.ReadLine();

    }
}