using System.Collections.Generic;
using CheckoutTest.Models;
namespace CheckoutTest.Business.ProductService
{
    public interface IProductService
    {
        List<Product> Get();
    }
}
