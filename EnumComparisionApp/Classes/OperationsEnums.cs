using EnumComparisionApp.Models;
using Spectre.Console;

namespace EnumComparisionApp.Classes;
internal class OperationsEnums
{
    public static void Sample1()
    {
        Helpers.Print();

        List<string> list = new()
        {
            "DairyProducts", "dairyproducts",
            "GrainsAndCereals",
            "Beverages", "BEVERAGES"
        };

        AnsiConsole.MarkupLine("[yellow]Enum.TryParse case insensitive[/]");
        foreach (var item in list)
        {
            AnsiConsole.MarkupLine(Enum.TryParse(item, true, out Category category)
                ? $"Found: {category}"
                : $"[red]Could not find the specified[/] {nameof(Category)}.{item}");

        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[yellow]Enum.TryParse case sensitive[/]");
        foreach (var item in list)
        {
            AnsiConsole.MarkupLine(Enum.TryParse(item, out Category categoryNotFound)
                ? $"Found: {categoryNotFound}"
                : $"[red]Could not find the specified[/] {nameof(Category)}.{item}");
        }

        Console.WriteLine();

    }

    public static void Sample2()
    {
        Helpers.Print();

        AnsiConsole.MarkupLine("[yellow]From file[/]");

        string[] lines = File.ReadAllLines("Transactions1.txt")
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        foreach (var currentLine in lines)
        {
            var parts = currentLine.Split(',');

            /*
             * Pattern matching works as expected but Enum.Parse fails as it is
             * not case insensitive so we have a try-catch to show TryParse works.
             */
            if (parts is [_, _, "Beverages" or "beverages" or "DairyProducts" or "GrainsCereals" or "Produce", var amount])
            {

                try
                {
                    AnsiConsole.MarkupLine($"      [cyan]Match[/] [[{string.Join(",", parts)}]]");
                    AnsiConsole.MarkupLine($"             [yellow]{Enum.Parse(typeof(Category), parts[2])}[/] [green]{amount}[/]");
                }
                catch (Exception)
                {
                    var result = Enum.TryParse(parts[2], true, out Category category)
                        ? $"Found: {category}"
                        : $"[red]Could not find the specified[/] {nameof(Category)}.{parts[2]} with case sensitive";

                    AnsiConsole.MarkupLine($"\t[white on red]Parse failed but not TryParse case insensitive[/] {result}");

                }
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Not a match[/] [[{string.Join(",", parts)}]]");
            }
        }

        Console.WriteLine();
    }

    [Flags] enum Colors { None = 0, Red = 1, Green = 2, Blue = 4 };
    // tweaks by Karen Payne
    public static void MicroSoftExample()
    {
        Helpers.Print();

        string[] colorStrings = { "0", "2", "8", "blue", "Blue", "Yellow", "Red, Green" };

        foreach (var colorString in colorStrings)
        {
            if (Enum.TryParse(colorString, true, out Colors colorValue))
            {
                if (Enum.IsDefined(typeof(Colors), colorValue) | colorValue.ToString().Contains(","))
                {
                    Console.WriteLine($"Converted '{colorString}' to {colorValue}.");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[white on red]{colorString}[/] is [red]not an underlying value of the Colors enumeration[/].");
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"[white on red]{colorString}[/] is [red]not a member of the Colors enumeration[/].");
            }
        }

        Console.WriteLine();
    }
}
