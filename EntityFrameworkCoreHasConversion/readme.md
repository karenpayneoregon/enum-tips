# Example for using enum in EF Core 

:pushpin: Main Model: Wine

```csharp
public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineType { get; set; }
    public override string ToString() => $"{WineType} {Name}";
}
```


:pushpin: Our enum for types of Wine

```csharp
public enum WineType : int
{
    Red = 0,
    White = 1,
    Rose = 2
}
```

:pushpin: Setup conversion in the DbContext, `WineType` to `int`

```csharp
public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .LogTo(message => 
                Debug.WriteLine(message), 
                LogLevel.Information);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();
    }
}
```

:pushpin: Querying for a specific wine category

```csharp
List<Wine> rose = context.Wines.Where(x => x.WineType == WineType.Rose).ToList();
```

## See also

[EF Core Value Conversions](https://github.com/karenpayneoregon/ef-core-transforming)
