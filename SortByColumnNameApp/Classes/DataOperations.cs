using Microsoft.EntityFrameworkCore;
using SortByColumnNameApp.Data;
using SortByColumnNameApp.Models;

namespace SortByColumnNameApp.Classes
{
    internal class DataOperations
    {
        private const int Count = 50;




        /// <summary>
        /// Order by using an enum
        /// </summary>
        public static async Task SortCustomerOnCountryName()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.CountryNavigation)
                .OrderByEnum(PropertyAlias.CountryName, Direction.Ascending)
                .ToListAsync();


            var table = CreateTableForCountries();

            for (int index = 0; index < Count; index++)
            {
                table.AddRow(customers[index].CompanyName, customers[index].CountryNavigation.Name);
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Order by using an enum
        /// </summary>
        public static async Task SortCustomerOnContactLastName()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.Contact)
                .OrderByEnum(PropertyAlias.LastName, Direction.Descending)
                .ToListAsync();

            var table = CreateTableForContacts();

            for (int index = 0; index < Count; index++)
            {
                table.AddRow(customers[index].CompanyName, customers[index].Contact.LastName);
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Order by using an enum
        /// </summary>
        public static async Task SortCustomerOnContactTitle()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.Contact)
                .Include(c => c.ContactTypeNavigation)
                .OrderByEnum(PropertyAlias.Title, Direction.Descending)
                .ToListAsync();

            var table = CreateTableForContactTitle();

            for (int index = 0; index < Count; index++)
            {
                table.AddRow(
                    customers[index].CompanyName, 
                    customers[index].ContactTypeNavigation.ContactTitle, 
                    customers[index].Contact.LastName);
            }

            AnsiConsole.Write(table);
        }

        private static Table CreateTableForCountries()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Customer[/]")
                .AddColumn("[b]Country[/]")
                .Title("[cyan]By country[/]")
                .Alignment(Justify.Center);
        }

        private static Table CreateTableForContacts()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Customer[/]")
                .AddColumn("[b]Contact last name[/]")
                .Title("[cyan]By last name[/]")
                .Alignment(Justify.Center);
        }
        private static Table CreateTableForContactTitle()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Customer[/]")
                .AddColumn("[b]Title[/]")
                .AddColumn("[b]Contact last name[/]")
                .Title("[cyan]By title[/]")
                .Alignment(Justify.Center);
        }
    }
}
