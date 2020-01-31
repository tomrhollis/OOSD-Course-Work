using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Northwind Product Administration Tool
 * 
 * Author: Tom Hollis
 * Jan 2020* 
 * 
 */


namespace Lab3
{
    /// <summary>
    /// The main form holding and displaying the data
    /// </summary>
    public partial class Form1 : Form
    {

        /// <summary>
        /// Build the form object
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Code to run when the user pushes the save button
        /// </summary>
        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate(); // validate the data
            try
            {
                this.productsBindingSource.EndEdit();                       // come out of editing mode
                this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // try to push the data to the database
            }
            catch (DBConcurrencyException) // if the data's been modified already
            {
                MessageBox.Show("Another user has modified the data you are trying to save. Please review the updated data and try again if necessary.", "Concurrency Exception");
                refresh();
            }
            catch (SqlException ex) // if there's a problem with the database
            {
                MessageBox.Show("Database error saving data: " +ex.Message, ex.GetType().ToString());
            }
            catch (Exception ex) // any other problem
            {
                MessageBox.Show("Unknown error saving data: " + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Default method to call to fill the object with data from the database
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            refresh(); // pulled out to its own function since refreshing is shared between this and concurrency exceptions
        }

        /// <summary>
        /// The code for getting up to date data from the DB and handling exceptions if there are problems
        /// </summary>
        private void refresh()
        {
            try
            {
                // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
                this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
                // TODO: This line of code loads data into the 'northwindDataSet.Categories' table. You can move, or remove it, as needed.
                this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);
                // TODO: This line of code loads data into the 'northwindDataSet.Suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
                // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
                this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            }
            catch (SqlException ex)// if there's a problem with the database
            {
                MessageBox.Show("Database error loading data: " + ex.Message, ex.GetType().ToString());
            }
            catch (Exception ex)// any other problem
            {
                MessageBox.Show("Unknown error loading data: " + ex.Message, ex.GetType().ToString());                
            }
        }
    }
}
