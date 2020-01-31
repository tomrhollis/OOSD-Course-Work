using CustomerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Billing Calcuator for Max Power Inc 
 * (c) 2019 Max Power Inc
 * 
 * Calculates bill amounts for various customer types based on their different parameters
 * 
 * Author: Tom Hollis
 * Date: December 2019
 */

namespace Lab1
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }

        List<Customer> Customers = new List<Customer>(); // initialize the customer list
        bool selectionDone = false; // a flag to keep the list selection change event from looping

        /// <summary>
        /// Clear all text boxes, switch back to Residential mode, and return focus to kWh entry field
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO **UNSELECT CUSTOMER** (probably will call reset itself)
            fullReset(); // clear all the text fields and return label text to defaults
        }


        /// <summary>
        /// Close the program
        /// </summary>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Refresh the customer list
        /// </summary>
        private void refreshList()
        {
            decimal r = 0m, c = 0m, i = 0m, current = 0m; // variables for each type of total we're calculating
                                                          // and one to hold the amount we're currently adding


            lstCustomers.Items.Clear();
            foreach (Customer cust in Customers)
            {
                lstCustomers.Items.Add(cust);
                current = cust.ChargeAmount;

                switch (cust.CustomerType)
                {
                    case 'R':
                        r += current;
                        break;
                    case 'C':
                        c += current;
                        break;
                    case 'I':
                        i += current;
                        break;
                }

                txtResTotal.Text = r.ToString("c");
                txtComTotal.Text = c.ToString("c");
                txtIndTotal.Text = i.ToString("c");
                txtTotal.Text = (r + c + i).ToString("c");
                txtNumCust.Text = Customers.Count().ToString();
            }
        }

        /// <summary>
        /// What the Clear button and successful calculation does
        /// </summary>
        private void fullReset()
        {
            // clear the text boxes
            txtkWh.Text = "";
            txtBill.Text = "";
            txtOffkWh.Text = "";

            softReset();

        }

        /// <summary>
        /// Shared reset functionality between the things that need a fullReset and customer selection
        /// </summary>
        private void softReset()
        {
            // by default, hide the industrial-only objects and change the first label
            lblOffkWh.Visible = false;
            txtOffkWh.Visible = false;
            lblkWh.Text = "kWh:";

            if (lstCustomers.SelectedIndex > -1) // if something's selected, let's try to see if it's an industrial customer
            {
                try // playing it safe in case somehow the thing in the customer list isn't a customer.  shouldn't be possible at all, but doing this anyway
                {
                    Customer c = (Customer)lstCustomers.SelectedItem; // get the selected object in the list
                    if (c.CustomerType == 'I')  // if it's industrial, unhide the off-peak field
                    {
                        lblOffkWh.Visible = true;
                        txtOffkWh.Visible = true;
                        lblkWh.Text = "Peak kWh:";
                    }
                    // if it isn't industrial, the defaults further above apply
                }
                catch
                {
                    MessageBox.Show("The selection is not a customer somehow", "Perplexing Error");
                }
            }

            // leave the focus on the first kWh entry box
            txtkWh.Focus();
        }


        /// <summary>
        /// Handle the form input and output regarding the billing calculation
        /// </summary>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            int kWh, offkWh = 0;            // variable to receive the kWh amount from the text box (peak kWh for industrial)
            decimal bill = 0;   // variable to hold the calculated bill amount(s)
            char custType;

            // Validate inputs
            if (!Validator.IsPresent(txtkWh, "kWh") || !Validator.IsNonNegativeInt32(txtkWh, "kWh") || !Validator.IsSelected(lstCustomers, "Customer List"))
            {
                // if there are problems with the input (no kWh, non-integer kWh, or no customer selected), don't continue
                return;
            }
            
            kWh = Convert.ToInt32(txtkWh.Text);
            custType = ((Customer)lstCustomers.SelectedItem).CustomerType;

            if(custType == 'I') // only get the offkWh amount for industrial customers. Will be zero for others.
            {
                if (!Validator.IsPresent(txtOffkWh, "Off-peak kWh") || !Validator.IsNonNegativeInt32(txtOffkWh, "Off-peak kWh"))
                {
                    // if there are problems with the input, don't continue
                    return;
                }
                offkWh = Convert.ToInt32(txtOffkWh.Text);
            }
            
            bill = ((Customer)lstCustomers.SelectedItem).CalculateCharge(kWh, offkWh);
            refreshList();  // make sure the customer display is up to date
            fullReset();    // clear the fields
            txtBill.Text = bill.ToString("c"); // put the result into its text box as currency*/
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            // TODO bring up a new dialog that takes the customer data

            // if everything went OK in the dialog, add the customer
            FrmAddCust adder = new FrmAddCust();  // make the customer addition form
            adder.ShowDialog();                   // and show it
            if(adder.Tag != null)   // if we got something back from the form...
            {
                switch (adder.Tag.GetType().ToString()) // figure out which data type the tag is
                {                                       // and add it to the list as the proper type
                    case "CustomerData.ResidentialCustomer":
                        Customers.Add((ResidentialCustomer)adder.Tag);
                        break;
                    case "CustomerData.CommercialCustomer":
                        Customers.Add((CommercialCustomer)adder.Tag);
                        break;
                    case "CustomerData.IndustrialCustomer":
                        Customers.Add((IndustrialCustomer)adder.Tag);
                        break;
                    default:
                        break;
                }
                //update the customer list
                refreshList();
            }
        }

        /// <summary>
        /// When the customer selection changes, we have to update the interface to reflect whether it's industrial or not and leave focus on the (peak)kWh field 
        /// Changing the focus loses the selection, so we need to save the selection first and put it back after the focus changes.
        /// Changing the selection back calls this function again, so we have to guard against loops
        /// </summary>
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(selectionDone) // avoid infinite loops from the last statement in this method
            {
                return;
            }

            int selected = lstCustomers.SelectedIndex; // store this because it will be lost

            softReset();  // check that everything is how it should be
            
            selectionDone = true;
            lstCustomers.SelectedIndex = selected;
            selectionDone = false;
            
        }













        /// <summary>
        /// Save method (broken out from form closing event just in case this needs to be used elsewhere)
        /// </summary>
        private void save()
        {
            string filename = "Customers.txt"; // just using the working directory, bin/debug

            FileStream fs;
            StreamWriter sw;

            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);


                foreach (Customer c in Customers) // write out data in CSV form
                {
                    sw.WriteLine(c.CustomerType + "," + c.CustomerName + "," + c.AccountNo + "," + c.ChargeAmount);
                }
                sw.Close();
                fs.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Unable to open the file " + filename);
            }
            catch (IOException ex)
            {
                MessageBox.Show("I/O Error writing to " + filename + ": " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown and Unexpected Error: " + ex.Message);
            }            
        }


        /// <summary>
        /// Catch the form closing and make sure to save everything first
        /// </summary>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }


        /// <summary>
        /// Load method
        /// </summary>
        private void loadfile()
        {
            string filename = "Customers.txt"; // just using the working directory, bin/debug
                       
            try
            {
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                //from Day 4 slides
                string line;
                string[] parts;
                int account;
                decimal balance;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    parts = line.Split(',');

                    if(!Int32.TryParse(parts[2], out account)) {
                        continue;   // if the data in this line has a problem, go to the next line
                    }
                    if(!Decimal.TryParse(parts[3], out balance))
                    {
                        continue;   // if the data in this line has a problem, go to the next line
                    }


                    switch (parts[0]) // parts 0 is the customer type, add it to the list as the proper type
                    {                                      
                        case "R":
                            Customers.Add(new ResidentialCustomer(parts[1],account,balance));
                            break;
                        case "C":
                            Customers.Add(new CommercialCustomer(parts[1], account, balance));
                            break;
                        case "I":
                            Customers.Add(new IndustrialCustomer(parts[1], account, balance));
                            break;
                        default:
                            break;
                    }
                }
                refreshList();
                sr.Close();
                fs.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Unable to open the file " + filename);
            }
            catch (IOException ex)
            {
                MessageBox.Show("I/O Error reading from " + filename + ": " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown and Unexpected Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Make sure any saved info is reloaded when the application starts
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadfile();
        }
    }
}


