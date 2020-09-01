using System;
using System.Collections.Generic;

namespace PQS.FSChalenge2.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersItems = new HashSet<OrdersItems>();
        }

        public int OrderId { get; set; }
        public int Status { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }

        public virtual ICollection<OrdersItems> OrdersItems { get; set; }
    }
}
