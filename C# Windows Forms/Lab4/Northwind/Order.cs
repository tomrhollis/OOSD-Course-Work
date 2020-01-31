using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Order Class Controller
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */

namespace Northwind
{
    /// <summary>
    /// class handler for order data
    /// </summary>
    public class Order
    {
        // private data
        private DateTime? shippedDate;

        // public properties
        public int OrderID { get; set; } // key for this order in the DB
        public string CustomerID { get; set; } // key for the customer who ordered it
        public DateTime? OrderDate { get; set; } // when it was ordered
        public DateTime? RequiredDate { get; set; } // when they need it by
        public DateTime? ShippedDate // extra check here. if bad data got through the View checks then the change will be thrown out (no error message though)
        {                            // must be greater than order date and less than required date
            get 
            { 
                return shippedDate;
            } 
            set 
            {
                if ((OrderDate != null && OrderDate > value) || (RequiredDate != null && RequiredDate < value))
                {
                    shippedDate = null;
                } else
                {
                    shippedDate = value;
                }
            }
        }

        // no constructor, properties will be set individually on a blank object
    }
}
