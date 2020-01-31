using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Order Details Database Interface
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */
namespace Northwind
{
    /// <summary>
    /// Order Details Database Interface
    /// </summary>
    public static class OrderDetailsDB
    {
        /// <summary>
        /// Gets a list of the order details related to a particular order
        /// </summary>
        /// <param name="OrderID">The ID of the order in question</param>
        /// <returns></returns>
        public static List<OrderDetail> GetOrderDetails(int OrderID)
        {
            List<OrderDetail> items = new List<OrderDetail>(); // make an object to hold what we find

            using (SqlConnection conn = NorthwindDB.GetConnection()) // get the connection to the DB
            {
                string query = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE OrderID = @OrderID"; // form the SQL query
                using (SqlCommand cmd = new SqlCommand(query, conn)) // initialize and use the query object
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID); // make the parameter work and send it the value passed to this method

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) // retrieve the data
                    {
                        while (reader.Read())
                        {
                            OrderDetail item = new OrderDetail();

                            item.OrderID = Convert.ToInt32(reader["OrderID"]); // convert the order ID to int
                            item.ProductID = Convert.ToInt32(reader["ProductID"]); // convert the product ID to int
                            item.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]); // convert the product ID to decimal
                            item.Quantity = Convert.ToInt32(reader["Quantity"]); // convert the quantity to int
                            item.Discount = Convert.ToDouble(reader["Discount"]); // convert the discount to double

                            items.Add(item); // add the item to the list to return later
                        }
                    }
                }
            }
            return items; // send it out -- length zero if failed
        }



    }
}
