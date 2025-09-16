using Microsoft.EntityFrameworkCore;
using SortByColumnNameApp.Data;
using SortByColumnNameApp.Models;

namespace SortByColumnNameApp.Classes
{
    internal class DataOperations
    {
        private const int Count = 50;

        /// <summary>
        /// Sorts customers by their associated country name in ascending order and displays the results in a formatted table.
        /// </summary>
        /// <remarks>
        /// This method retrieves customer data from the database, including their associated country information,
        /// sorts the customers by the country name using an enum-based ordering helper, and displays the top results
        /// in a console table.
        /// </remarks>
        public static async Task SortCustomerOnCountryName()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.CountryNavigation)
                .OrderByEnum(Column.CountryName, Direction.Ascending)
                .ToListAsync();


            var table = CreateTableForCountries();

            for (int index = 0; index < Count; index++)
            {
                table.AddRow(customers[index].CompanyName, customers[index].CountryNavigation.Name);
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Sorts the customers by their contact's last name in descending order and displays the results in a formatted table.
        /// </summary>
        /// <remarks>
        /// This method retrieves customer data from the database, orders it by the contact's last name using an enum-based sorting mechanism, 
        /// and displays the top results in a table format. The table includes the customer's company name and the contact's last name.
        /// </remarks>
        public static async Task SortCustomerOnContactLastName()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.Contact)
                .OrderByEnum(Column.LastName, Direction.Descending)
                .ToListAsync();

            var table = CreateTableForContacts();

            for (int index = 0; index < Count; index++)
            {
                table.AddRow(customers[index].CompanyName, customers[index].Contact.LastName);
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Sorts the customers based on their contact title in descending order.
        /// </summary>
        /// <remarks>
        /// This method retrieves customer data from the database, including related contact and contact type information.
        /// It orders the customers by their contact title using the <see cref="Column.Title"/> enum value and the <see cref="Direction.Descending"/> direction.
        /// The sorted data is then displayed in a formatted table.
        /// </remarks>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task SortCustomerOnContactTitle()
        {
            await using var context = new NorthWindContext();
            List<Customers> customers = await context.Customers
                .Include(c => c.Contact)
                .Include(c => c.ContactTypeNavigation)
                .OrderByEnum(Column.Title, Direction.Descending)
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

        /// <summary>
        /// Creates a formatted table for displaying customer information grouped by their associated country.
        /// </summary>
        /// <remarks>
        /// The table includes two columns: one for the customer's name and another for the country name.
        /// It is styled with a rounded border, a light slate grey border color, and a centered alignment.
        /// </remarks>
        /// <returns>
        /// A <see cref="Table"/> object configured for displaying customer and country information.
        /// </returns>
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

        /// <summary>
        /// Creates a formatted table for displaying customer information, specifically their company name and contact's last name.
        /// </summary>
        /// <remarks>
        /// The table is styled with a rounded border and light slate grey color. It includes two columns: 
        /// one for the customer's company name and another for the contact's last name. The table is titled "By last name" 
        /// and is centered for better readability.
        /// </remarks>
        /// <returns>
        /// A <see cref="Table"/> object configured with the specified columns, title, and styling.
        /// </returns>
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
        
        /// <summary>
        /// Creates a formatted table for displaying customer information sorted by contact title.
        /// </summary>
        /// <remarks>
        /// The table includes the following columns:
        /// - Customer: Displays the customer's company name.
        /// - Title: Displays the contact's title.
        /// - Contact last name: Displays the contact's last name.
        /// The table is styled with a rounded border and a centered alignment.
        /// </remarks>
        /// <returns>
        /// A <see cref="Table"/> object configured with columns for customer, title, and contact last name.
        /// </returns>
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
