using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQS.FSChalenge2.DTOs
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }

        public virtual List<OrdersItemsDTO> OrdersItems { get; set; }
    }
}
