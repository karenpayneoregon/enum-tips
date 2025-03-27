using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.Json;
using Dapper;
using ConsoleConfigurationLibrary.Classes;

namespace WineToJsonApp.Classes;

/// <summary>
/// Provides operations for generating and managing wine type data in various formats.
/// </summary>
/// <remarks>
/// This class contains methods to generate a C# enum file and a JSON file based on wine type data.
/// It interacts with JSON files, databases, and file systems to process and serialize wine type information.
/// </remarks>
public class Operations
{
    // Where query results are stored in the executable directory
    private static readonly string InputPath = "wine-types.json";

    // Where the generated enum file is saved
    private static string _outputPath = Path.Combine(DirectoryHelper.GetProjectInfo().FullName, "Models", "WineType.cs");

    // The name of the enum type from query table name without schema
    private static string _tableName = "";

    /// <summary>
    /// Generates a C# enum file based on wine type data retrieved from a JSON file.
    /// </summary>
    /// <remarks>
    /// This method performs the following operations:
    /// <list type="bullet">
    /// <item>Reads wine type data from a JSON file.</item>
    /// <item>Deserializes the JSON data into a list of wine type entries.</item>
    /// <item>Generates a C# enum file where each enum member represents a wine type, 
    /// with its name and value derived from the JSON data.</item>
    /// <item>Saves the generated enum file to a predefined output path.</item>
    /// </list>
    /// </remarks>
    /// <exception cref="FileNotFoundException">
    /// Thrown if the input JSON file is not found at the specified path.
    /// </exception>
    /// <exception cref="JsonException">
    /// Thrown if the JSON file content cannot be deserialized into the expected format.
    /// </exception>
    /// <exception cref="IOException">
    /// Thrown if an error occurs while writing the generated enum file to the output path.
    /// </exception>
    public static void GenerateWineTypeEnum()
    {
        var json = GenerateWineTypesJson();
        var wineTypes = JsonSerializer.Deserialize<List<WineTypeEntry>>(json);

        StringBuilder sb = new();

        sb.AppendLine("using System.ComponentModel;");
        sb.AppendLine($"namespace {DirectoryHelper.AssemblyName}.Models;");
        sb.AppendLine();
        sb.AppendLine($"public enum {_tableName}");
        sb.AppendLine("{");

        foreach (var wine in wineTypes.OrderBy(w => w.Id))
        {
            var description = wine.Description.Replace("\"", "\\\"");
            sb.AppendLine($"    [Description(\"{description}\")]");
            sb.AppendLine($"    {wine.TypeName} = {wine.Id},");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        //File.WriteAllText(_outputPath, sb.ToString());

        AnsiConsole.MarkupLine($"[yellow]Enum generated:[/] [cyan]{_outputPath}[/]");

    }

    /// <summary>
    /// Generates a JSON file containing all wine types retrieved from the database.
    /// </summary>
    /// <remarks>
    /// This method executes a SQL query to fetch wine type data, including their IDs, names, and descriptions.
    /// The data is serialized into a JSON format and saved to a file named "wine-types.json".
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown if an error occurs while executing the SQL query.
    /// </exception>
    /// <exception cref="IOException">
    /// Thrown if an error occurs while writing the JSON file to disk.
    /// </exception>
    private static string GenerateWineTypesJson()
    {
        const string query = 
            """
            SELECT Id,TypeName,Description 
            FROM dbo.WineType 
            ORDER BY TypeName
            """;

        _tableName = SqlHelper.GetTableNameWithoutSchema(query);
        using var connection = new SqlConnection(AppConnections.Instance.MainConnection);

        var wineEntries = connection.Query<WineTypeEntry>(query);

        File.WriteAllText("wine-types.json", JsonSerializer.Serialize(wineEntries, Indented));

        AnsiConsole.MarkupLine("[cyan]wine-types.json[/] [yellow]has been created successfully.[/]");
        return JsonSerializer.Serialize(wineEntries, Indented);
    }

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}