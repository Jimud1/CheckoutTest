# CheckoutTest
Test for Degree53
+Checkout test
+
+First steps, created Console application as specified in the requirements.
+Added business layer for Checkout service,
+Next step, Create the product models for the service
+
+Product
+{
+	SKU : String
+	Description: String 
+	Unit Price: Decimal
+	SpecialOffer: SpecialOffer
+}
+
+I have taken it upon myself to assume all offers will be buy xAmount for yPrice 
+so I have created this class to give it the ability to be changed easily
+SpecialOffer
+{
+	OfferOn : Int
+	OfferPrice: Decimal
+}
+
+Once Models created, onto create the Checkout.Total function.
+Total function is easy enough, add up the totals from all the items in list,
+then create a function to apply special offers
+
+CalculateSpecialOffer(List<Product> specialOffers)
+First off we group offers by SKU(Product type)
+then we find out how many items we need for the offer also the price,
+then we apply special offers to our price with the values we need to add and remove from the total.
+
+
+As specified in the document I have added null checks for security
