using HasConversion.Data;
using HasConversion.Models;
using Spectre.Console;

namespace HasConversion.Classes;

public class WineOperations
{
    /// <summary>
    /// Query wines
    /// </summary>
    /// <param name="reCreate">if true creates the Wine table and populates it, false if the database exists</param>
    /// <remarks>
    /// passing true for <see cref="reCreate"/> will wipe out the WineType table
    /// </remarks>
    public static void Run(bool reCreate = false)
    {
        using var context = new WineContext();
            
        if (reCreate)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Wines.Add(new Wine
            {
                Name = "Veuve Clicquot Rose",
                WineType = WineType.Red,
            });

            context.Wines.Add(new Wine
            {
                Name = "Whispering Angel Rose",
                WineType = WineType.Red,
            });

            context.Wines.Add(new Wine
            {
                Name = "Pinot Grigio",
                WineType = WineType.White,
            });

            context.SaveChanges();
        }

        AnsiConsole.MarkupLine("[white on red]Grouped[/]");
        var allWinesGrouped = context.Wines
            .GroupBy( wine => wine.WineType)
            .Select(w => new {w.Key, List = w.ToList()})
            .ToList();

        foreach (var top in allWinesGrouped)
        {
            Console.WriteLine(top.Key);
            foreach (var wine in top.List)
            {
                Console.WriteLine($"\t{wine.WineId, -5}{wine.Name}");
            }
        }

        Console.WriteLine();

        var all = context.Wines.ToList();
        AnsiConsole.MarkupLine("[white on red]All[/]");
        foreach (var wine in all)
        {
            Console.WriteLine($"{wine.WineType,-15}{wine.Name}");
        }


        Console.WriteLine();
        List<Wine> rose = context.Wines.Where(x => x.WineType == WineType.Rose).ToList();

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
        var red = context.Wines.Where(x => x.WineType == WineType.Red).ToList();
        foreach (var wine in red)
        {
            Console.WriteLine($"{wine.Name,30}");
        }


    }

}