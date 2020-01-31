using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Northwind Order Maintenance: Shipping Date Entry Tool
 * - Program.CS
 * 
 * Author: Tom Hollis
 * Jan 2020
 *  
 */
namespace Lab4
{
    /// <summary>
    /// Where it all starts
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmOrders());
        }
    }
}
