using WineToJsonApp.Classes;

namespace WineToJsonApp;

internal partial class Program
{
   
    static void Main(string[] args)
    {

        Operations.GenerateWineTypeEnum();

        AnsiConsole.MarkupLine("[green]Done[/]");
        Console.ReadLine();
    }


}