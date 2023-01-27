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

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("All");
        Console.ResetColor();

        foreach (var wine in allWines)
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
            foreach (var wine in rose)
            {
                Console.WriteLine($"{wine.Name,30}");
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Red");
        Console.ResetColor();

        List<Wine> red = context.Wines.Where(wine => wine.WineType == WineType.Red).ToList();
        foreach (var wine in red)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}