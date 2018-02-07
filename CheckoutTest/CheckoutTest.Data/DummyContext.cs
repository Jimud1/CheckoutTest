using CheckoutTest.Models;
using System.Collections.Generic;

namespace CheckoutTest.Data
{
    /// <summary>
    /// As noted in the requirements I haven't gone too in depth with the "Data" side, just mocking up dummy data for the products
    /// </summary>
    public class DummyContext
    {
        Product Apple,
                Biscuit,
                Coffee,
                Tissues;
        public DummyContext()
        {
            Apple = CreateProduct("A99", "Apple", (decimal)0.50, CreateSpecialOffer(3, (decimal)1.30));
            Biscuit = CreateProduct("B15", "Biscuits", (decimal)0.30, CreateSpecialOffer(2, (decimal)0.45));
            Coffee = CreateProduct("C40", "Coffee", (decimal)1.80, null);
            Tissues = CreateProduct("T23", "Tissues", (decimal)0.99, null);
            Products = new List<Product>();
            Products.Add(Apple);
            Products.Add(Biscuit);
            Products.Add(Coffee);
            Products.Add(Tissues);
        }
        public List<Product> Products { get; set; }

        #region Helper functions
        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="description"></param>
        /// <param name="unitPrice"></param>
        /// <param name="specialOffer"></param>
        /// <returns></returns>
        Product CreateProduct(string sku, string description, decimal unitPrice, SpecialOffer specialOffer)
        {
            var product = new Product
            {
                Sku = sku,
                Description = description,
                UnitPrice = unitPrice
            };

            if (specialOffer != null)
                product.SpecialOffer = CreateSpecialOffer(specialOffer.OfferOn, specialOffer.OfferPrice);

            return product;
        }

        /// <summary>
        /// Create Special Offer
        /// </summary>
        /// <param name="offerOn"></param>
        /// <param name="offerPrice"></param>
        /// <returns></returns>
        SpecialOffer CreateSpecialOffer(int offerOn, decimal offerPrice)
        {
            return new SpecialOffer
            {
                OfferOn = offerOn,
                OfferPrice = offerPrice
            };
        }
        #endregion

    }
}
