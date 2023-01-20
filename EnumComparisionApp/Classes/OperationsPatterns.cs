using Spectre.Console;

namespace EnumComparisionApp.Classes;
/// <summary>
/// Has nothing to do with enum, this can help get a better idea about List patterns which are used in <seealso cref="OperationsEnums.Sample2"/>
/// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching#list-patterns
///
/// See also
/// https://github.com/karenpayneoregon/csharp-11-ef-core-7-features/tree/master/ListPatternApp
/// </summary>
internal class OperationsPatterns
{
    static decimal GetDecimal(string sender) 
        => decimal.TryParse(sender, out var value) ? value : 0;

    /// <summary>
    /// Taken from Microsoft and enhanced by Karen Payne as the original sample used decimal.Parse which will throw
    /// an unhandled exception if the value is not a decimal
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Sample1()
    {
        List<string[]> ReadTransFromFile()
        {
            var items = new List<string[]>();
            var lines = File.ReadAllLines("Transactions2.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                items.Add(parts);
            }

            return items;
        }

        List<string[]> records = ReadTransFromFile();
        decimal balance = 0m;

        foreach (string[] transaction in records)
        {
            balance += transaction switch
            {
                [_, "DEPOSIT" or "deposit", _, var amount] => GetDecimal(amount),
                [_, "WITHDRAWAL", .., var amount] => -GetDecimal(amount),
                [_, "INTEREST", var amount] => GetDecimal(amount),
                [_, "FEE", .., var fee] => -GetDecimal(fee),
                /*
                 * If transaction type is not recognized throw an exception. In this case
                 * I setup one line with deposit lowercase so we don't throw.
                 */
                _ => throw new InvalidOperationException(
                    $"Record {string.Join(", ", transaction)} is invalid"),
            };

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (balance < 1000)
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [white on red]Balance[/] {balance:C}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [yellow]Balance[/] {balance:C}");
            }

        }
    }
}
