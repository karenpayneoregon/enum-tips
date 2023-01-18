using System.ComponentModel;

namespace EnumGetDescriptionsApp.Classes;

public enum BookCategories
{
    [Description("Options")]
    Select = 0,
    [Description("Space Travel")]
    SpaceTravel = 1,
    [Description("Adventure")]
    Adventure = 2,
    [Description("Popular sports")]
    Sports = 3,
    [Description("Cars")]
    Automobile = 4,
    [Description("Programming with C#")]
    Programming = 5
}