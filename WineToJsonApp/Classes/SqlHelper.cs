using System.Text.RegularExpressions;

namespace WineToJsonApp.Classes;

public static partial class SqlHelper
{
    /// <summary>
    /// Extracts the table name without the schema from a given SQL query.
    /// </summary>
    /// <param name="query">
    /// The SQL query string from which the table name should be extracted.
    /// </param>
    /// <returns>
    /// The table name without the schema if found; otherwise, an empty string.
    /// </returns>
    /// <remarks>
    /// This method uses a regular expression to identify and extract the table name
    /// from SQL queries containing clauses like FROM or JOIN.
    /// </remarks>
    public static string GetTableNameWithoutSchema(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return string.Empty;

        // Regex to find FROM or JOIN followed by [schema].[table] or just [table]
        var match = GetTableNameRegex().Match(query);
        return match.Success ? match.Groups["table"].Value : string.Empty;
    }

    [GeneratedRegex(@"\bFROM\b\s+(?:\w+\.)?(?<table>\w+)", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex GetTableNameRegex();
}