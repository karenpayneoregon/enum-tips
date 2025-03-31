using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WineToJsonApp.Models;

public enum WineType
{
    [Description("Classic red")]
    [Display(Name ="Classic red")]
    Red = 1,

    [Description("Dinner white")]
    [Display(Name ="Dinner white")]
    White = 2,

    [Description("Imported rose")]
    [Display(Name ="Imported rose")]
    Rose = 3,

}
