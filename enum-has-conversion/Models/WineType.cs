using System.CodeDom.Compiler;
using System.ComponentModel;

namespace EnumHasConversion.Models
{
    /// <summary>
    /// WineType auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum WineType
    {
        [Description("Classic red")] 
        Red = 1,
        [Description("Dinner white")] 
        White = 2,
        [Description("Imported rose")] 
        Rose = 3,
        [Description("Cheap wine")] 
        Cheap = 4}
}
