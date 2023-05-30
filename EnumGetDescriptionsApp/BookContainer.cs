using EnumGetDescriptionsApp.Classes;

namespace EnumGetDescriptionsApp;

public class BookContainer
{
    public BookCategories Name { get; }
    public string Description { get; }

    public BookContainer(BookCategories name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString() => Description;

}