using System.Data;
using ConsoleConfigurationLibrary.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WineApp.Data;
using WineApp.Models;

namespace WineApp.Classes;


public class WineService
{

    /// <summary>
    /// Retrieves a list of grouped wines categorized by their wine type using Dapper.
    /// </summary>
    /// <remarks>
    /// This method queries the database using Dapper to group wines by their associated
    /// <see cref="WineType"/>. Each group contains a collection of wines and metadata about the wine type.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="WineGroup"/> objects, where each group represents a collection of wines
    /// categorized by a specific wine type.
    /// </returns>
    public static List<WineGroup> WineGroupsDapper()
    {
        using IDbConnection connection = new SqlConnection(AppConnections.Instance.MainConnection);
        
        var wineTypes = connection.Query<WineType>(
                """
                SELECT Id, TypeName 
                FROM WineType
                """)
            .ToDictionary(wt => wt.Id, wt => wt.TypeName);

        var wines = connection.Query<Wines>(
                """
                SELECT WineId, Name, WineType 
                FROM Wines
                """)
            .ToList();

        var allWinesGrouped = wines
            .GroupBy(w => w.WineType)
            .Select(g =>
            {
                var wineTypeId = g.Key;
                var typeName = wineTypes.GetValueOrDefault(wineTypeId, "Unknown");

                return new WineGroup(new WineType { Id = wineTypeId, TypeName = typeName },
                    g.OrderBy(w => w.Name).ToList(),
                    typeName);
            })
            .ToList();

        return allWinesGrouped;
    }

    /// <summary>
    /// Retrieves a list of grouped wines categorized by their wine type using Dapper with an inner join query.
    /// </summary>
    /// <remarks>
    /// This method executes a SQL query to join the <see cref="Wines"/> and <see cref="WineType"/> tables,
    /// grouping the wines by their associated wine type. Each group contains metadata about the wine type
    /// and a collection of wines belonging to that type.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="WineGroup"/> objects, where each group represents a collection of wines
    /// categorized by a specific wine type.
    /// </returns>
    public static List<WineGroup> WineGroupsDapper1()
    {
        using IDbConnection connection = new SqlConnection(AppConnections.Instance.MainConnection);

        var sql = """
                  SELECT 
                      w.WineId, w.Name, w.WineType,
                      wt.Id, wt.TypeName, wt.Description
                  FROM Wines w
                  INNER JOIN WineType wt ON w.WineType = wt.Id
                  """;

        var wineWithTypes = connection.Query<Wines, WineType, (Wines Wine, WineType Type)>(
            sql,
            (wine, type) => (wine, type),
            splitOn: "Id" // splits on the first column of the second object
        ).ToList();

        var grouped = wineWithTypes
            .GroupBy(wt => wt.Type.Id)
            .Select(g =>
            {
                var wineType = g.First().Type;
                var wines = g.Select(x => x.Wine).OrderBy(w => w.Name).ToList();

                return new WineGroup(wineType, wines, wineType.TypeName);
            })
            .ToList();

        return grouped;
    }

    /// <summary>
    /// Retrieves a list of grouped wines categorized by their wine type using a SQL query and Dapper.
    /// </summary>
    /// <remarks>
    /// This method performs a SQL query that joins the <c>Wines</c> and <c>WineType</c> tables to retrieve
    /// detailed information about wines and their associated wine types. The results are grouped by wine type,
    /// and each group contains a collection of wines and metadata about the wine type.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="WineGroup"/> objects, where each group represents a collection of wines
    /// categorized by a specific wine type.
    /// </returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// var wineGroups = WineService.WineGroupsDapper2();
    /// foreach (var group in wineGroups)
    /// {
    ///     Console.WriteLine($"Wine Type: {group.TypeName}");
    ///     foreach (var wine in group.List)
    ///     {
    ///         Console.WriteLine($"   {wine.Name}");
    ///     }
    /// }
    /// </code>
    /// </example>
    public static List<WineGroup> WineGroupsDapper2()
    {
        using IDbConnection connection = new SqlConnection(AppConnections.Instance.MainConnection);

        var sql = """
                  SELECT 
                      w.WineId, w.Name, w.WineType,
                      wt.Id, wt.TypeName, wt.Description
                  FROM Wines w
                  INNER JOIN WineType wt ON w.WineType = wt.Id
                  """;

        var wineWithTypes = connection.Query<Wines, WineType, WineWithType>(sql,
            (wine, type) => new WineWithType
            {
                Wine = wine,
                WineType = type
            },
            splitOn: "Id"
        ).ToList();

        var grouped = wineWithTypes
            .GroupBy(wt => wt.WineType.Id)
            .Select(g =>
            {
                var wineType = g.First().WineType;
                var wines = g.Select(x => x.Wine).OrderBy(w => w.Name).ToList();

                return new WineGroup(wineType, wines, wineType.TypeName);
            })
            .ToList();

        return grouped;
    }


    /// <summary>
    /// Retrieves a list of grouped wines categorized by their wine type using Entity Framework Core 9.
    /// </summary>
    /// <remarks>
    /// This method queries the database using Entity Framework Core to group wines by their associated
    /// <see cref="WineType"/>. Each group contains a collection of wines and metadata about the wine type.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="WineGroup"/> objects, where each group represents a collection of wines
    /// categorized by a specific wine type.
    /// </returns>
    public static List<WineGroup> WineGroupsEf()
    {
        using var context = new Context();

        Dictionary<int, string> wineTypes = context.WineType.AsNoTracking()
            .ToDictionary(wt => wt.Id, wt => wt.TypeName);

        List<WineGroup> allWinesGrouped = context.Wines.AsNoTracking()
            .GroupBy(wine => wine.WineType)
            .Select(w => new WineGroup(
                new WineType { Id = w.Key, TypeName = wineTypes[w.Key] },
                w.OrderBy(wine => wine.Name).ToList(),
                wineTypes[w.Key]))
            .ToList();

        return allWinesGrouped;
    }
}
