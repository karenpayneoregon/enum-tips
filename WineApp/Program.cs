using WineApp.Classes;

namespace WineApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[yellow]Dapper[/]");
        var groupedWines = WineService.WineGroupsDapper();

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
        
        var allWinesGrouped = WineService.WineGroupsEf();
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