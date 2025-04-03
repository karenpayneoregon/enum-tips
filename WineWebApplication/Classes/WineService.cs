using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using WineApp.Models;
using WineWebApplication.Interfaces;
using WineWebApplication.Models;

namespace WineWebApplication.Classes;

public class WineService : IWineService
{
    private readonly string _connectionString;

    public WineService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<WineGroup> GetWineGroups()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

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

        return wineWithTypes
            .GroupBy(wt => wt.WineType.Id)
            .Select(g =>
            {
                var wineType = g.First().WineType;
                var wines = g.Select(x => x.Wine).OrderBy(w => w.Name).ToList();
                return new WineGroup(wineType, wines, wineType.TypeName);
            })
            .ToList();
    }
}

