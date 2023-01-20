using HasConversion.Data;
using HasConversion.Models;
using Spectre.Console;

namespace HasConversion.Classes;

public class WineOperations
{
    /// <summary>
    /// Query wines
    /// </summary>
    /// <param name="create">if true creates the Wine table and populates it, false if the database exists</param>
    /// <remarks>
    /// passing true for <see cref="create"/> will wipe out the WineType table
    /// </remarks>
    public static void Run(bool create = false)
    {
        using var context = new WineContext();
            
        /*
         * pass create = true to create the database and populate, otherwise a
         * runtime exception is thrown.
         */
        if (create)
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

            context.Wines.Add(new Wine
            {
                Name = "White Zinfandel",
                WineType = WineType.Rose,
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

        var red = context.Wines.Where(wine => wine.WineType == WineType.Red).ToList();
        foreach (var wine in red)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}