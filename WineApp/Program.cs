using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WineApp.Data;
using WineApp.Models;

namespace WineApp;

internal partial class Program
{
    static void Main(string[] args)
    {


        using var context = new Context();

        AnsiConsole.MarkupLine("[white]Grouped[/]");

        var allWinesGrouped = context.Wines.AsNoTracking()
            .GroupBy(wine => wine.WineType)
            .Select(w => new WineGroup(
                context.WineType.FirstOrDefault(wt => wt.Id == w.Key),
                w.OrderBy(wine => wine.Name).ToList(),
                context.WineType.FirstOrDefault(wt => wt.Id == w.Key).TypeName))
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