﻿namespace HasConversion.Models;

public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineType { get; set; }
    public override string ToString() => $"{WineType} {Name}";
}