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
* - Windows Form: Order Details for one order
* 
* Author: Tom Hollis
* Jan 2020
*  
*/
namespace Lab4
{
    public partial class frmDetails : Form
    {
        public Order CurrentOrder { get; set; } // the order we're getting the details for
        private List<OrderDetail> details;  // the details for the order

        public frmDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Make sure all information is where it needs to be when this form loads
        /// </summary>
        private void frmDetails_Load(object sender, EventArgs e)
        {
            if (CurrentOrder==null || CurrentOrder.OrderID == null) // if there's no order to go on for some reason, kick back to the main window
            {
                MessageBox.Show("No current order set when opening details view");
                DialogResult = DialogResult.Cancel;
                this.Close();
            } 
            else
            {
                RefreshDetails(); // place all the info in the window
            }
            
        }

        /// <summary>
        /// Place the data in the form
        /// </summary>
        private void RefreshDetails()
        {
            try
            {
                details = OrderDetailsDB.GetOrderDetails(CurrentOrder.OrderID); // get the details associated with this order from the database
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message, ex.GetType().ToString());
            }

            // add each of the order fields to the text boxes
            txtOrderID.Text = CurrentOrder.OrderID.ToString();
            txtCustID.Text = CurrentOrder.CustomerID.ToString();

            //if the date is null, use an empty string. otherwise convert to date-only format
            txtOrderDate.Text = (CurrentOrder.OrderDate == null)? "" : ((DateTime)CurrentOrder.OrderDate).ToString("MM/dd/yyyy");
            txtShippedDate.Text = (CurrentOrder.ShippedDate == null) ? "" : ((DateTime)CurrentOrder.ShippedDate).ToString("MM/dd/yyyy");
            txtReqDate.Text = (CurrentOrder.RequiredDate == null) ? "" : ((DateTime)CurrentOrder.RequiredDate).ToString("MM/dd/yyyy"); 

            txtOrderTotal.Text = (from d in details select d.ItemTotal).Sum().ToString("c"); // order total must be the sum of all item totals

            dgvDetails.DataSource = details; // feed the order details to the data grid
            dgvDetails.Columns[2].DefaultCellStyle.Format = "c"; // unit price to display as currency
            dgvDetails.Columns[5].DefaultCellStyle.Format = "c"; // item total to display as currency
            dgvDetails.Columns[4].DefaultCellStyle.Format = "p"; // discount to display as a percentage

            dgvDetails.Columns[0].Visible = false; // we don't need the order ID, we already know what it is

        }

        /// <summary>
        /// Save changes to the shipping date for this order
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            // first, have to check if the date is null or invalid (treat as null) before trying to parse it
            DateTime newDate;  // somewhere to put the result
            bool parseResult = DateTime.TryParse(txtShippedDate.Text, out newDate);

            if (parseResult) // if the parse was successful (it's a legitimate date), compare against the other dates to make sure it's between them
            {
                if ((CurrentOrder.OrderDate != null && CurrentOrder.OrderDate > newDate) || (CurrentOrder.RequiredDate != null && CurrentOrder.RequiredDate < newDate))
                {
                    MessageBox.Show("Shipping Date must be later than order date and earlier than Required date");  // notify the user
                    txtShippedDate.Text = ""; // clear out the bad date and focus the field for correction
                    txtShippedDate.Focus();
                    return; // break out of this method entirely so they can fix it
                }
            }
            try
            {
                if (parseResult) // if the parse worked (and it was in the correct range), send the new date
                    OrderDB.UpdateOrder(CurrentOrder, newDate);
                else // if it's blank or isn't a date
                    OrderDB.UpdateOrder(CurrentOrder, null);

                // if we're still here and nothing messed up, close this and go back to the order list
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving shipping date: " + ex.Message, ex.GetType().ToString());
                
            }
            
        }

        /// <summary>
        /// Cancel the update and go back to the order list
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
