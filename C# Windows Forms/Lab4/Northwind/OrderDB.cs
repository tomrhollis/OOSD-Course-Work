using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Order Database Interface
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */
namespace Northwind
{
    /// <summary>
    /// Order Database Interface
    /// </summary>
    public static class OrderDB
    {

        /// <summary>
        /// Get all the orders from the database
        /// </summary>
        /// <returns>A list of all the orders</returns>
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>(); // make a list to hold what we find

            using (SqlConnection conn = NorthwindDB.GetConnection()) // get the connection to the DB
            {
                string query = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate FROM Orders ORDER BY OrderID"; // form the SQL query
                using (SqlCommand cmd = new SqlCommand(query, conn)) // initialize and use the query object
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) // retrieve the data
                    {
                        while (reader.Read())
                        {
                            Order o = new Order(); // create a placeholder Order object

                            o.OrderID = Convert.ToInt32(reader["OrderID"]); // convert the order ID to int
                            o.CustomerID = reader["CustomerID"].ToString(); // convert the customer ID to string

                            // for each of these, if it's DBNull then the object is null.  otherwise, convert to nullable datetime
                            o.OrderDate = (reader["OrderDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["OrderDate"]);
                            o.RequiredDate = (reader["RequiredDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["RequiredDate"]);
                            o.ShippedDate = (reader["ShippedDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["ShippedDate"]);

                            orders.Add(o); // add this order to the list
                        }
                     }
                }
            }
            return orders; // send them out -- null if failure
        }

        /// <summary>
        /// Get a single order record with only the fields required for this program
        /// </summary>
        /// <param name="OrderID">The order ID for lookup</param>
        /// <returns>An order object holding the requested order</returns>
        public static Order GetOrder(int OrderID)
        {
            Order o = new Order(); // make an object to hold what we find

            using (SqlConnection conn = NorthwindDB.GetConnection()) // get the connection to the DB
            {
                string query = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate FROM Orders ORDER BY OrderID WHERE OrderID = @OrderID"; // form the SQL query
                using (SqlCommand cmd = new SqlCommand(query, conn)) // initialize and use the query object
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID); // add the parameter to fill the where clause
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow)) // retrieve the data
                    {
                        
                        o.OrderID = Convert.ToInt32(reader["OrderID"]); // convert the order ID to int
                        o.CustomerID = reader["CustomerID"].ToString(); // convert the customer ID to string

                        // for each of these, if it's DBNull then the object is null.  otherwise, convert to nullable datetime
                        o.OrderDate = (reader["OrderDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["OrderDate"]);
                        o.RequiredDate = (reader["RequiredDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["RequiredDate"]);
                        o.ShippedDate = (reader["ShippedDate"] == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(reader["ShippedDate"]);

                    }
                }
            }
            return o; // send it out -- fields null if failure
        }


        /// <summary>
        /// Update the shipping date for a single order
        /// </summary>
        /// <param name="oldOrder">The old version of the order, for the order ID</param>
        /// <param name="newDate">The new version of the date</param>
        public static void UpdateOrder(Order oldOrder, DateTime? newDate)
        {
            using (SqlConnection conn = NorthwindDB.GetConnection()) // get the connection to the DB
            {
                string query = "UPDATE Orders SET ShippedDate=@ShippedDate WHERE OrderID = @OrderID"; // we'd only ever change shipped date in this application

                using (SqlCommand cmd = new SqlCommand(query, conn)) // initialize and use the query object 
                {
                    cmd.Parameters.AddWithValue("@OrderID", oldOrder.OrderID);
                    // if the date is null, use DBnull. Otherwise use the date
                    if (newDate == null) 
                    {
                        cmd.Parameters.AddWithValue("@ShippedDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ShippedDate", newDate);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery(); // run the command

                }
            }
        }
    }
}
