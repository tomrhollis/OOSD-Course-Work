using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * TODO:
 * 
 * Parts 1 & 2
 * x create abstract customer class
 * x create specific customer type classes with inheritance (is overriding a thing when it's abstract?) and public properties
 * - fix everything that was moved out of the application and into the customer classes
 * - build tests (at least 6) and make sure they pass
 * 
 * Part 3
 * x link to existing lab 1 application
 * - "controls to allow the user to enter for each customer the account # and name", with an "add" button that adds it and clears the fields and preps for the next entry
 * - display all customers, one per line
 * - display up-to-date stats: total # of customers, sum of charges for each type, sum of all charges
 * - automatic bin/Debug/Customers.txt saving on add or close with exception handling (no save button)
 * - automatic bin/Debug/Customers.txt reading on form load with exception handling (no load button)
 * 
 * Cleanup
 * - Run tests again to be sure
 * - Tweak look-and-feel for the better
 * - add comments
 * - Submit with all files (include customers.txt)
 * 
 * 
 * ORDER:
 * X) make add customer trigger new dialog
 * X) have new dialog put entered info in tag or something
 * X) read the tag to get the customer and find out what kind it is
 * X) add it to the list & refresh list
 * X) only allow entering kWh data when a customer is selected
 * X) changing selection changes the kWh options (reads the type)
 * X) add charges to customers and clear fields/reset
 * X) add stats
 * X) refresh function that updates stats (add it to reset as well)
 * 10) save
 * 11) load
 * 12) go through and make sure nothing was missed
 * 13) do cleanup 
 * 
 * */


namespace CustomerData
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class Customer
    {

        // PRIVATE DATA
        protected string customerName;    // the customer's name
        protected int accountNo;          // the customer's account number
        protected decimal chargeAmount;   // what the customer owes
          

        // PUBLIC PROPERTIES


        public int AccountNo 
        {
            get
            {
                return accountNo;
            }
            set
            { 
                if (value != 0) // only proceed if value isn't zero
                {   // assume that any negative sign was a mistake and switch to positive
                    accountNo = (value < 0) ? -value : value;
                }
            }
        }


        public string CustomerName
        {
            get
            { 
                return customerName; 
            }
            set 
            {   
                if (value != "") // only store the data if it's not empty
                {
                    customerName = value;
                } else
                {
                    throw new Exception("Customer objects require a name");
                }
            }
        }

        public decimal ChargeAmount
        {
            get; set;
        }

        public abstract char CustomerType { get; set; }


        // CONSTRUCTORS
        public Customer(string n, int a, decimal c)
        {
            try
            {
                CustomerName = n;
            } 
            catch (Exception e)
            {
                throw e;
            }
            AccountNo = a;
            ChargeAmount = c; // should only be used when loading from file
        }
        public Customer(string n, int a)
        {
            try
            {
                CustomerName = n;
            }
            catch (Exception e)
            {
                throw e;
            }
            AccountNo = a;
            ChargeAmount = 0m;
        }
        // CLASS METHODS        
        public abstract decimal CalculateCharge(int peakkWh, int offkWh);
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CustomerName + " - " + AccountNo + "(" + CustomerType + "): " + ChargeAmount.ToString("c");
        }



    }
}
