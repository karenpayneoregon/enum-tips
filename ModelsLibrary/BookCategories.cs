using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelsLibrary;

public enum BookCategories
{
    [Description("Options")]
    [Display(Name = "Select")]
    Select = 0,
    [Description("Space Travel")]
    [Display(Name = "Space Travel")]
    SpaceTravel = 1,
    [Description("Adventure")]
    [Display(Name = "Adventure")]
    Adventure = 2,
    [Description("Popular sports")]
    [Display(Name = "Popular sports")]
    Sports = 3,
    [Description("Cars")]
    [Display(Name = "Cars")]
    Automobile = 4,
    [Description("Programming with C#")]
    [Display(Name = "Programming with C#")]
    Programming = 5
}