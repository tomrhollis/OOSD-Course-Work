using Northwind;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/* 
* Northwind Order Maintenance: Shipping Date Entry Tool
* - Main Windows Form: Order List Display
* 
* Author: Tom Hollis
* Jan 2020
*  
*/
namespace Lab4
{
    public partial class frmOrders : Form
    {
        private List<Order> orders; // holds the orders displayed in the form

        public frmOrders()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initial load of the form
        /// </summary>
        private void FrmOrders_Load(object sender, EventArgs e)
        {
            RefreshList();                // display the data grid with all the orders
        }

        /// <summary>
        /// Method to refresh the list in any situation where it's needed
        /// </summary>
        private void RefreshList()
        {
            try
            {
                orders = OrderDB.GetOrders(); // get an updated list of orders from the database
                dgvOrders.DataSource = orders; // put it in the data grid view
                dgvOrders.Columns[2].DefaultCellStyle.Format = "d";  // set the date columns to short date format
                dgvOrders.Columns[3].DefaultCellStyle.Format = "d";
                dgvOrders.Columns[4].DefaultCellStyle.Format = "d";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the order list: " + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Update button clicked: open the order details form for updating the order
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmDetails newForm = new frmDetails(); // create the order details form
            int selection = dgvOrders.CurrentCell.RowIndex; // get the currently selected row
            Order selectedOrder = orders[selection];  // get the order that matches the selection
            newForm.CurrentOrder = selectedOrder; // hand the order to the details form

            newForm.ShowDialog(); // pop up the order details form
            RefreshList();  // refresh the list in any case (might have been updates by other users)
        }
    }

}
