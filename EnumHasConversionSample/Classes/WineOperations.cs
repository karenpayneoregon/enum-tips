using EnumHasConversionSample.Data;
using EnumHasConversionSample.Models;

namespace EnumHasConversionSample.Classes;

public class WineOperations
{
    public static void Run()
    {
        using var context = new WineContext();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Grouped");
        Console.ResetColor();

        List<WineGroupItem> allWinesGrouped = context.Wines
            .GroupBy( wine => wine.WineType)
            .Select(wineGrouped => new WineGroupItem(wineGrouped.Key, wineGrouped.ToList()))
            .ToList();

        foreach (WineGroupItem wineItem in allWinesGrouped)
        {
            Console.WriteLine(wineItem.Key);
            foreach (var wine in wineItem.List)
            {
                Console.WriteLine($"\t{wine.WineId, -5}{wine.Name}");
            }
        }

        Console.WriteLine();

        List<Wine> allWines = context.Wines.ToList();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("All");
        Console.ResetColor();

        foreach (Wine wine in allWines)
        {
            Console.WriteLine($"{wine.WineType,-8}{wine.Name}");
        }

        Console.WriteLine();

        List<Wine> rose = context.Wines.Where(wine => wine.WineType == WineType.Rose).ToList();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Rose");
        Console.ResetColor();

        if (rose.Count == 0)
        {
            Console.WriteLine("\tNone");
        }
        else
        {
            foreach (Wine roseWine in rose)
            {
                Console.WriteLine($"{roseWine.Name,30}");
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Red");
        Console.ResetColor();

        List<Wine> redWines = context.Wines.Where(wine => wine.WineType == WineType.Red).ToList();
        foreach (Wine wine in redWines)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}