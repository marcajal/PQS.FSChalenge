using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQS.FSChalenge2.DTOs
{
    public class OrdersItemsDTO
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual OrdersDTO Order { get; set; }
    }
}
