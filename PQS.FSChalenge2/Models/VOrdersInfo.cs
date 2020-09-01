using System;
using System.Collections.Generic;

namespace PQS.FSChalenge2.Models
{
    public partial class VOrdersInfo
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
