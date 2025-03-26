using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumHasConversionSample.Classes
{
    class Utilities
    {
        /// <summary>
        /// Gets the connection string for the master database on the SQL Server Express instance.
        /// </summary>
        /// <returns>A connection string for the master database.</returns>
        private static string MasterConnectionString()
            => "Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=False";


        /// <summary>
        /// Checks if a database with the specified name exists on the SQL Server Express instance.
        /// </summary>
        /// <param name="databaseName">The name of the database to check for existence.</param>
        /// <returns><c>true</c> if the database exists; otherwise, <c>false</c>.</returns>
        /// <remarks>Using Dapper NuGet package</remarks>
        public static bool ExpressDatabaseExists1(string databaseName)
        {
            using var cn = new SqlConnection(MasterConnectionString());
            return cn.QuerySingleOrDefault<int?>("SELECT DB_ID(@DatabaseName);",
                new { DatabaseName = databaseName }).HasValue;
        }

        /// <summary>
        /// Determine the database has records
        /// </summary>
        /// <param name="databaseName">name of database</param>
        /// <returns>true if all tables have records</returns>
        public static bool LocalDbDatabaseExists(string databaseName)
        {
            using var cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;integrated security=True;Encrypt=False");
            using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

            cn.Open();
            return cmd.ExecuteScalar() != DBNull.Value;

        }


        public static bool WineDatabaseExists()
        {
            return LocalDbDatabaseExists("EF.Wines");
        }
    }
}
