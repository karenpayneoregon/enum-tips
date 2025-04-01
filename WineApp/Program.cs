using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WineApp.Classes;
using WineApp.Data;
using WineApp.Models;

namespace WineApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[yellow]Dapper[/]");
        var groupedWines = WineService.WineGroups();

        foreach (var group in groupedWines)
        {
            AnsiConsole.MarkupLine($"[cyan]{group.TypeName}[/]");

            foreach (var wine in group.List)
            {
                Console.WriteLine($"    {wine.Name} (Id: {wine.WineId})");
            }

            Console.WriteLine(); 
        }


        AnsiConsole.MarkupLine("[yellow]EF Core[/]");

        using var context = new Context();

        var wineTypes = context.WineType.AsNoTracking()
            .ToDictionary(wt => wt.Id, wt => wt.TypeName);

        var allWinesGrouped = context.Wines.AsNoTracking()
            .GroupBy(wine => wine.WineType)
            .Select(w => new WineGroup(
                new WineType { Id = w.Key, TypeName = wineTypes[w.Key] },
                w.OrderBy(wine => wine.Name).ToList(),
                wineTypes[w.Key]))
            .ToList();

        foreach (var wineGroup in allWinesGrouped)
        {
            AnsiConsole.MarkupLine($"[cyan]{wineGroup.TypeName}[/]");
            foreach (var wine in wineGroup.List)
            {
                Console.WriteLine($"   {wine.Name}");
            }
        }




        Console.ReadLine();
    }



}