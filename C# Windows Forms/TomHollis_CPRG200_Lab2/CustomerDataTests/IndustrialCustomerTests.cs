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
    public class IndustrialCustomerTests
    {

        [TestMethod()]
        public void CalculateChargeTest()
        { // Test of normal input, kWh amount greater than the base charge
            IndustrialCustomer cust = new IndustrialCustomer("Test", 12345);
            int kWh = 2000;
            int offkWh = 2000;
            decimal expectedCharge = 209m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh, offkWh);

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        
        [TestMethod()]
        public void CalculateChargeTest2()
        { // Test of normal input, kWh amount less than the base charges
            IndustrialCustomer cust = new IndustrialCustomer("Test", 12345);
            int kWh = 500;
            int offkWh = 500;
            decimal expectedCharge = 116m;
            decimal actualCharge;

            actualCharge = cust.CalculateCharge(kWh, offkWh);

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}
 