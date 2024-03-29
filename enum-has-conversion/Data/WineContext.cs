﻿using System.Diagnostics;
using ConfigurationLibrary.Classes;
using EnumHasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
#pragma warning disable CS8618

namespace EnumHasConversion.Data;

public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<WineTypes> WineTypes { get; set; }

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

        modelBuilder.Entity<WineTypes>().HasData(
            new WineTypes() {Id = 1, TypeName = "Red", Description = "Classic red"},
            new WineTypes() {Id = 2, TypeName = "White", Description = "Dinner white"},
            new WineTypes() {Id = 3, TypeName = "Rose", Description = "Imported rose"}
        );

        modelBuilder.Entity<Wine>().HasData(
            new Wine() { WineId = 1, Name = "Veuve Clicquot Rose", WineType = WineType.Red },
            new Wine() { WineId = 2, Name = "Whispering Angel Rose", WineType = WineType.Rose },
            new Wine() { WineId = 3, Name = "Pinot Grigi", WineType = WineType.White },
            new Wine() { WineId = 4, Name = "Zinfandel", WineType = WineType.Rose },
            new Wine() { WineId = 5, Name = "Banyuls Traditional French", WineType = WineType.Red },
            new Wine() { WineId = 6, Name = "Louis Jdot", WineType = WineType.White }
        );
    }
}