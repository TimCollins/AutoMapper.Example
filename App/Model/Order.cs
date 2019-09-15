using System.Collections.Generic;
using System.Linq;

namespace App.Model
{
    public class Order
    {
        public Customer Customer { get; set; }
        private IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public void AddLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public decimal GetTotal()
        {
            return _orderLineItems.Sum(l => l.GetTotal());
        }
    }
}
