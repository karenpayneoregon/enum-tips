using EnumHasConversion.Data;
using EnumHasConversion.Models;

namespace EnumHasConversion.Classes;

public class WineOperations
{
    public static List<Wine> GetWinesByType(WineType wineType)
    {
        using var context = new WineContext();
        return context.Wines
            .Where(wine => wine.WineType == wineType)
            .ToList();
    }
    public static void Run()
    {
        using var context = new WineContext();
            

        AnsiConsole.MarkupLine("[white on red]Grouped[/]");

        List<WineGroupItem> allWinesGrouped = context.Wines
            .GroupBy( wine => wine.WineType)
            .Select(w => new WineGroupItem(w.Key, w.ToList()))
            .ToList();

        foreach (WineGroupItem top in allWinesGrouped)
        {
            Console.WriteLine(top.Key);
            foreach (var wine in top.List)
            {
                Console.WriteLine($"\t{wine.WineId, -5}{wine.Name}");
            }
        }

        Console.WriteLine();

        List<Wine> allWines = context.Wines.ToList();
        
        AnsiConsole.MarkupLine("[white on red]All[/]");

        foreach (var wine in allWines)
        {
            Console.WriteLine($"{wine.WineType,-8}{wine.Name}");
        }

        Console.WriteLine();

        List<Wine> rose = context.Wines.Where(wine => wine.WineType == WineType.Rose).ToList();

        AnsiConsole.MarkupLine("[white on red]Rose[/]");
        if (rose.Count == 0)
        {
            Console.WriteLine("\tNone");
        }
        else
        {
            foreach (var wine in rose)
            {
                Console.WriteLine($"{wine.Name,30}");
            }
        }
        
        AnsiConsole.MarkupLine("[white on red]Red[/]");

        List<Wine> red = context.Wines
            .Where(wine => wine.WineType == WineType.Red)
            .ToList();

        foreach (var wine in red)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}