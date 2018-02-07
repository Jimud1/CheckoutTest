using System.Linq;
using System.Collections.Generic;
using CheckoutTest.Models;
using System;

namespace CheckoutTest.Business.Checkout
{
    /// <summary>
    /// My checkout service
    /// </summary>
    public class CheckoutService : ICheckoutService
    {
        /// <summary>
        /// Main function returns total of products 
        /// </summary>
        /// <param name="products"></param>
        /// <returns>decimal</returns>
        public decimal Total(List<Product> products)
        {
            if (products.Count < 1) throw new ArgumentNullException("products is null");
            decimal total = 0;
            //Get total from all products
            foreach (Product p in products)
            {
                total = total + p.UnitPrice;
            }
            //Get products with offers and calculate
            var offerProducts = products.Where(x => x.SpecialOffer != null).ToList();
            foreach(var val in CalculateSpecialOffer(offerProducts))
            {
                total += val;
            }

            return total;
        }

        /// <summary>
        /// Apply special offer to product
        /// </summary>
        /// <param name="specialOffers"></param>
        /// <returns>toRemove, toAdd</returns>
        private decimal[] CalculateSpecialOffer(List<Product> specialOffers)
        {
            //Group our offers by Sku
            var query = specialOffers.GroupBy(x => x.Sku);
            decimal toAdd = 0,
                    toRemove = 0;
            //Get total from special offers
            //Mark offers used once applied
            foreach (var productGroup in query)
            {
                //Get the special offer model
                var product = productGroup.Select(p => p).FirstOrDefault();
                //Get how many items we need for offer to apply
                int offerOn = product.SpecialOffer.OfferOn;
                decimal offerPrice = product.SpecialOffer.OfferPrice;
                for(int i = 0; i <= Qualify(productGroup.Count(), offerOn) - 1; i ++)
                {
                    toAdd += offerPrice;
                    toRemove -= product.UnitPrice * offerOn;
                }
            }
            return new decimal[] { toRemove, toAdd };
        }

        /// <summary>
        /// How many offers to apply
        /// </summary>
        /// <param name="products"></param>
        /// <param name="offerOn"></param>
        /// <returns></returns>
        int Qualify(int products, int offerOn)
        {
            return products / offerOn;
        }
    }
}