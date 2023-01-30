using EnumGetDescriptionsApp.Classes;
using System.Reflection;

namespace EnumGetDescriptionsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Enum descriptions[/]");


        var name = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name;
        Type type = Type.GetType($"EnumGetDescriptionsApp.Classes.BookCategories, {name}");
        Console.WriteLine();
        //List<KeyValuePair<string, Enum>> result = EnumHelper.GetItemsAsDictionary<BookCategories>();

        //foreach (var item in result)
        //{
        //    Console.WriteLine($"{item.Value,-20} {item.Key}");
        //}

        //Console.WriteLine("---------------------");

        //foreach (BookCategories categories in Enum.GetValues<BookCategories>())
        //{
        //    Console.WriteLine($"{categories,-20} {categories.GetDisplayName()}");
        //}

        //Console.WriteLine("---------------------");
        //foreach (BookCategories categories in (BookCategories[])Enum.GetValues(typeof(BookCategories)))
        //{
        //    Console.WriteLine($"{categories,-20} {categories.GetDisplayName()}");
        //}


        foreach (BookCategories categories in Enum.GetValues<BookCategories>())
        {
            Console.WriteLine($"{categories,-20} {Helpers.GetDisplayName(categories)}");
        }
        Console.ReadLine();

    }
}