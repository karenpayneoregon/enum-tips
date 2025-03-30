#pragma warning disable CS8618
namespace EnumGetDescriptions.Models;

/// <summary>
/// Represents a container for books, associating an enumeration value with its description.
/// </summary>
public class BookContainer : IEquatable<BookContainer>
{
    public Enum Name { get; set; }
    public string Description { get; set; }
    public bool Equals(BookContainer? other) => Name.Equals(other!.Name);
    public override string ToString() => Description;
}