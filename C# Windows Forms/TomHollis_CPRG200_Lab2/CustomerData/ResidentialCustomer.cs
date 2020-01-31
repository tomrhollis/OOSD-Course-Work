using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData
{
    public class ResidentialCustomer : Customer
    {
        private const decimal RES_RATE = 0.052m;        // residential rate per kWh
        private const decimal RES_BASE = 6.00m;         // residential base cost
        private const int RES_FLOOR = 0;                // residential kWh "floor", the amount included in the base cost

        public override char CustomerType
        {
            get
            {
                return 'R';
            }
            set
            { 
                // nothing to set 
            }
        }

        // constructor: just call the default
        public ResidentialCustomer(string n, int a, decimal c) : base(n, a, c) { }
        public ResidentialCustomer(string n, int a) : base(n, a) { }

        public override decimal CalculateCharge(int peakkWh, int offkWh)
        {
            return CalculateCharge(peakkWh + offkWh); // residential customers don't have a difference between peak and off-peak
        }

        public decimal CalculateCharge(int kWh)
        {
            decimal bill = 0; // create a variable to hold the money billed

            bill += RES_BASE; // start with the base amount that's charged no matter what
            kWh -= RES_FLOOR; // remove the starting kWh amount
            if (kWh < 0) // if the subtraction put the kWh in the negatives, make it 0
            {
                kWh = 0;
            }

            bill += (RES_RATE * kWh); // Charge the rate for the remaining kWh
            ChargeAmount += bill; // assuming that we're keeping a running tally, not just replacing the chargeAmount (who knows if they've paid?)

            return bill;

        }
    }
}
