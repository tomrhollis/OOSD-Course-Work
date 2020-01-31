using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Database Connectivity Class
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */
namespace Northwind
{
    /// <summary>
    /// Handles connection to the Northwind Database
    /// </summary>
    public class NorthwindDB
    {
        /// <summary>
        /// Connects to the database on localhost using the included string
        /// </summary>
        /// <returns>An SqlConnection representing the connection</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"; // hard coded connection string
            return new SqlConnection(connectionString);
        }
    }
}
