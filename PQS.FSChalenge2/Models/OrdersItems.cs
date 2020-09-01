using System;
using System.Collections.Generic;

namespace PQS.FSChalenge2.Models
{
    public partial class OrdersItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Orders Order { get; set; }
    }
}
