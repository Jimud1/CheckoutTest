using CheckoutTest.Models;
using System.Collections.Generic;

namespace CheckoutTest.Business.Checkout
{
    public interface ICheckoutService
    {
        /// <summary>
        /// Blahhh
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        decimal Total(List<Product> products);
    }
}
