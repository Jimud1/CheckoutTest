namespace CheckoutTest.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public SpecialOffer SpecialOffer { get; set; }
    }
}
