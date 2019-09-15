namespace App.Model
{
    public class OrderLineItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
}
