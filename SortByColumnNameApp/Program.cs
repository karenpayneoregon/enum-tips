using SortByColumnNameApp.Classes;

namespace SortByColumnNameApp;

internal partial class Program
{
    private const int Count = 50;

    static async Task Main(string[] args)
    {
        // Run these once
        //Setup.CleanDatabase();
        //Setup.Populate();

        await DataOperations.SortCustomerOnCountryName();
        await DataOperations.SortCustomerOnContactLastName();
        await DataOperations.SortCustomerOnContactTitle();

        ExitPrompt();
        Console.ReadLine();
    }
}