using System.Collections.Generic;
using CheckoutTest.Models;
using CheckoutTest.Data;

namespace CheckoutTest.Business.ProductService
{
    public class ProductService : IProductService
    {
        DummyContext _context;
        public ProductService()
        {
            _context = new DummyContext();
        }
        public List<Product> Get()
        {
            return _context.Products;
        }
    }
}
