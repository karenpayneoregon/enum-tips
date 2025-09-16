using System.Linq.Expressions;
using SortByColumnNameApp.Models;

namespace SortByColumnNameApp.Classes;

public static class OrderingHelpers
{

    /// <summary>
    /// Provides sorting by <see cref="Column"/> using a key specified in <see cref="key"/> and if the key is not found the default is <see cref="Customers.CompanyName"/>
    /// <para>By default the sort order is <see cref="Direction.Ascending"/></para> 
    /// </summary>
    /// <param name="query"><see cref="Customers"/> query</param>
    /// <param name="key">key to sort by</param>
    /// <param name="direction">direction to sort by</param>
    /// <returns>query with order by</returns>
    public static IQueryable<Customers> OrderByEnum(this IQueryable<Customers> query, Column key, Direction direction = Direction.Ascending)
    {
        Expression<Func<Customers, object>> exp = key switch
        {
            Column.LastName => customer => customer.Contact.LastName,
            Column.FirstName => customer => customer.Contact.FirstName,
            Column.CountryName => customer => customer.CountryNavigation.Name,
            Column.Title => customer => customer.ContactTypeNavigation.ContactTitle,
            _ => customer => customer.CompanyName
        };

        return direction == Direction.Ascending ? query.OrderBy(exp) : query.OrderByDescending(exp);
    }



    /// <summary>
    /// Generic top level order by property name
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <param name="list">List of <see cref="T"/></param>
    /// <param name="propertyName">Column/property to order or</param>
    /// <param name="sortDirection">Direction of ordering</param>
    /// <returns></returns>
    public static List<T> OrderByPropertyName<T>(this List<T> list, string propertyName, Direction sortDirection)
    {

        ParameterExpression param = Expression.Parameter(typeof(T), "item");

        Expression<Func<T, object>> sortExpression = 
            Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

        list = sortDirection switch
        {
            Direction.Ascending => list.AsQueryable().OrderBy(sortExpression).ToList(),
            _ => list.AsQueryable().OrderByDescending(sortExpression).ToList()
        };

        return list;

    }
}