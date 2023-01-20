using Spectre.Console;
using System.Runtime.CompilerServices;

namespace EnumComparisionApp.Classes;
internal class Helpers
{
    public static void Print([CallerMemberName] string? methodName = null)
    {
        var rule = new Rule($"[white on blue]{methodName!}[/]");
        rule.RuleStyle("deepskyblue4");
        AnsiConsole.Write(rule);

    }
}