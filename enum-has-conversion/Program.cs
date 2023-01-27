using EnumHasConversion.Classes;
using EnumHasConversion.Data;
using EnumHasConversion.Extensions;

namespace EnumHasConversion;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

        var success = context.CanConnectAsync(cancellationTokenSource.Token);
        if (success == false)
        {
            AnsiConsole.MarkupLine("[cyan]Creating and populating database[/]");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.Clear();
        }

        WineOperations.Run();

        ExitPrompt();
    }
}