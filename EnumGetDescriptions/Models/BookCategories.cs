using System.ComponentModel;

namespace EnumGetDescriptions.Models;

public enum BookCategories
{
    [Description("Options")]
    Select = 0,
    [Description("Space Travel like Star wars")]
    SpaceTravel = 1,
    [Description("Adventure let's go")]
    Adventure = 2,
    [Description("Popular sports like baseball")]
    Sports = 3,
    [Description("Cars zoom")]
    Automobile = 4,
    [Description("Programming with C#")]
    Programming = 5
}