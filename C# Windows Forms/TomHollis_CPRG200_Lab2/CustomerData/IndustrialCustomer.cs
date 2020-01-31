using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData
{
    public class IndustrialCustomer : Customer
    {
        private const decimal IND_PEAK_RATE = 0.065m;   // industrial peak rate per kWh
        private const decimal IND_OFF_RATE = 0.028m;    // industrial off-peak rate per kWh
        private const decimal IND_PEAK_BASE = 76m;      // industrial peak base cost
        private const decimal IND_OFF_BASE = 40m;       // industrial off-peak base cost
        private const int IND_PEAK_FLOOR = 1000;        // industrial peak "floor"
        private const int IND_OFF_FLOOR = 1000;         // industrial off-peak "floor"

        public override char CustomerType
        {
            get
            {
                return 'I';
            }
            set
            {
                // nothing to set 
            }
        }

        // constructors: just call the default
        public IndustrialCustomer(string n, int a, decimal c) : base(n, a, c) { }
        public IndustrialCustomer(string n, int a) : base(n, a) { }

        public override decimal CalculateCharge(int peakkWh, int offkWh)
        {
            decimal bill = 0; // create a variable to hold the money billed

            bill += IND_PEAK_BASE + IND_OFF_BASE; // start with the base amount that's charged no matter what
            peakkWh -= IND_PEAK_FLOOR;            // remove the starting kWh amounts
            offkWh -= IND_OFF_FLOOR;             

            peakkWh = (peakkWh < 0) ? 0 : peakkWh;  // fix any negative amounts by setting them to 0
            offkWh = (offkWh < 0) ? 0 : offkWh;
         

            bill += (IND_PEAK_RATE * peakkWh) + (IND_OFF_RATE * offkWh); // Charge the rate for the remaining kWh
            ChargeAmount += bill; // assuming that we're keeping a running tally, not just replacing the chargeAmount (who knows if they've paid?)

            return bill;

        }
    }
}
