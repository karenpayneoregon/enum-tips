using System.ComponentModel;
namespace WineToJsonApp.Models;

public enum WineType
{
    [Description("Classic red")]
    Red = 1,

    [Description("Dinner white")]
    White = 2,

    [Description("Imported rose")]
    Rose = 3,

}
