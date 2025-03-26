using ConsoleConfigurationLibrary.Classes;
using EnumHasConversionSample.Classes;
using EnumHasConversionSample.Data;

namespace EnumHasConversionSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        if ( EntitySettings.Instance.CreateNew == false)
        {
            
        }

        if (EntitySettings.Instance.CreateNew)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        WineOperations.Run();

        Console.WriteLine("Finished");
        Console.ReadLine();
    }
}
