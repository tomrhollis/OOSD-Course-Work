using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData.Tests
{
    [TestClass()]
    public class CommercialCustomerTests
    {


        [TestMethod()]
        public void CalculateChargeTest()
        { // Test of normal input, kWh amount greater than the base charge
            CommercialCustomer cust = new CommercialCustomer("Test", 12345);
            int kWh = 2000;
            decimal expectedCharge = 105m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh);

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        
        [TestMethod()]
        public void CalculateChargeTest1()
        { // Test of normal input, kWh amount less than the base charge
            CommercialCustomer cust = new CommercialCustomer("Test", 12345);
            int kWh = 500;
            decimal expectedCharge = 60m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh);

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}
 