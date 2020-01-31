using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Order Detail Class Controller
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */
namespace Northwind
{
    /// <summary>
    /// class handler for orderdetail data
    /// </summary>
    public class OrderDetail
    {
        
        // public properties
        public int OrderID { get; set; } // key for this order in the DB
        public int ProductID { get; set; } // key for the product in question
        public decimal UnitPrice { get; set; } // how much per item
        public int Quantity { get; set; } // how many items
        public double Discount { get; set; } // any discount applied to this item
        public decimal ItemTotal { get { return UnitPrice * (1.0m - (decimal)Discount) * (decimal)Quantity; } } // Calculate the total for this line item


        // no constructor, properties will be set individually on a blank object
    }
}

