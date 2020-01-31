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
    public class ResidentialCustomerTests
    {

        [TestMethod()]
        public void CalculateChargeTest()
        { // Test of normal input, kWh amount greater than the base charge
            ResidentialCustomer cust = new ResidentialCustomer("Test", 12345);
            int kWh = 2000;
            decimal expectedCharge = 110m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh);

            Assert.AreEqual(expectedCharge,actualCharge);
        }

        
        [TestMethod()]
        public void CalculateChargeTest1()
        {   // Test of abnormal input
            // validation should save the method from seeing a negative number, but if it does get there somehow,
            // it's expected to treat it as a zero and only charge the base amount
            ResidentialCustomer cust = new ResidentialCustomer("Test", 12345);
            int kWh = -2000;
            decimal expectedCharge = 6m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh);

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}