using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutTest.Business.Checkout;

namespace CheckoutTest.Test
{
    [TestClass]
    public class CheckoutTest
    {
        ICheckoutService _checkoutService;
        public CheckoutTest()
        {
            _checkoutService = new CheckoutService();
        }

        [TestMethod]
        public void TestTotals()
        {

        }
    }
}
