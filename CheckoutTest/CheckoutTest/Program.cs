using CheckoutTest.Business.Checkout;
using CheckoutTest.Business.ProductService;
using CheckoutTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutTest
{
    class Program
    {
        static internal ICheckoutService _checkoutService;
        static internal IProductService _productService;
        static List<Product> AvailiableProducts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        static void Initalize()
        {
            _checkoutService = new CheckoutService();
            _productService = new ProductService();
            AvailiableProducts = _productService.Get();
            DisplayCurrentOffers();
            DisplayProducts();
        }

        static void Shop()
        {
            List<Product> basket = new List<Product>();
            var chosenProducts = Console.ReadLine().Split(',');
            if (chosenProducts.Count() > 0)
            {
                foreach (string s in chosenProducts)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        Product product;
                        try
                        {
                            product = AvailiableProducts.Where(p => p.Sku == s.Trim().ToUpper()).First();
                            basket.Add(product);
                        }
                        catch(Exception)
                        {
                            Console.WriteLine($"{s} is not a valid product choice");
                            Shop();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{s} is not a valid product, please input valid items");
                        Shop();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Please input products to purchase");
                Shop();
            }

            decimal total = 0;

            if (basket.Count > 0) total = _checkoutService.Total(basket);

            Console.WriteLine($"Your total is { total,10:C}\n Thanks for using the Checkout Test :)");
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// Main entry point of application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Initalize();
            Shop();
        }

        /// <summary>
        /// 
        /// </summary>
        static void DisplayProducts()
        {
            Console.WriteLine("----------------------------------------------------------------------------\n\n");
            Console.WriteLine("Welcome to our simple to use Checkout, please select items from the list below\n");
            Console.WriteLine("Enter the SKU Code to add items\n to the basket (e.g. A99 for Apple) followed by a comma\n");

            foreach (var p in AvailiableProducts)
            {
                Console.WriteLine($"{p.Description} {p.UnitPrice, 10:C} SKU: {p.Sku} \n");
            }
        }
        /// <summary>
        /// Display current Offers
        /// </summary>
        static void DisplayCurrentOffers()
        {
            Console.WriteLine("----------------------------------------------------------------------------\n\n");
            Console.WriteLine("Promotions we have currently\n");
            var offerProductGroups = AvailiableProducts.Where(x => x.SpecialOffer != null).GroupBy(x => x.Description);

            foreach (var productGroup in offerProductGroups)
            {
                var product = productGroup.Select(p => p).FirstOrDefault();
                Console.WriteLine($"Special offer on {productGroup.Key}\n Buy {product.SpecialOffer.OfferOn} for {product.SpecialOffer.OfferPrice, 10:C}\n");
            }
        }
    }
}