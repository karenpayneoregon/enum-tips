using System.Text.Json;
using SortByColumnNameApp.Models;
using SortByColumnNameApp.Data;

namespace SortByColumnNameApp.Classes;

internal class Setup
{
    public static void CleanDatabase()
    {
        using var context = new NorthWindContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    
}