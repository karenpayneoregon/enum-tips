using System.Data;
using ConsoleConfigurationLibrary.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using WineApp.Models;

namespace WineApp.Classes;


public class WineService
{
    public static List<WineGroup> WineGroups()
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
}
