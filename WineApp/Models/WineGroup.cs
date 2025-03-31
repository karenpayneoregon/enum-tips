namespace WineApp.Models;

/// <summary>
/// Represents a grouped collection of wines categorized by a specific wine type.
/// </summary>
/// <remarks>
/// This class is used to group wines by their associated <see cref="WineType"/> and provides
/// additional metadata such as the type name for display purposes.
/// </remarks>
public class WineGroup(WineType key, List<Wines> list, string typeName)
{
    public WineType Key { get; } = key;
    public List<Wines> List { get; } = list;
    public string TypeName { get; } = typeName;
}