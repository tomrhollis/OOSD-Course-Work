using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData
{
    public class CommercialCustomer : Customer
    {
        
        private const decimal COMM_RATE = 0.045m;       // commercial rate per kWh
        private const decimal COMM_BASE = 60m;          // commercial base cost
        private const int COMM_FLOOR = 1000;            // commercial kWh "floor"

        public override char CustomerType
        {
            get
            {
                return 'C';
            }
            set
            {
                // nothing to set 
            }
        }

        // constructors: just call the default
        public CommercialCustomer(string n, int a, decimal c) : base(n, a, c) { }
        public CommercialCustomer(string n, int a) : base(n, a) { }

        public override decimal CalculateCharge(int peakkWh, int offkWh)
        {
            return CalculateCharge(peakkWh + offkWh); // residential customers don't have a difference between peak and off-peak
        }

        public decimal CalculateCharge(int kWh)
        {
            decimal bill = 0; // create a variable to hold the money billed

            bill +=COMM_BASE; // start with the base amount that's charged no matter what
            kWh -= COMM_FLOOR; // remove the starting kWh amount
            if (kWh < 0) // if the subtraction put the kWh in the negatives, make it 0
            {
                kWh = 0;
            }

            bill += (COMM_RATE * kWh); // Charge the rate for the remaining kWh
            ChargeAmount += bill; // assuming that we're keeping a running tally, not just replacing the chargeAmount (who knows if they've paid?)

            return bill;

        }
    }
}
