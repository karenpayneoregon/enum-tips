namespace WineApp.Models;

/// <summary>
/// Represents a wine along with its associated wine type.
/// </summary>
/// <remarks>
/// This class combines a <see cref="Wines"/> object with its corresponding <see cref="WineType"/> 
/// to provide a comprehensive representation of a wine and its type.
/// </remarks>
public class WineWithType
{
    public Wines Wine { get; set; }
    public WineType WineType { get; set; }
}