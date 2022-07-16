using System;
using System.Collections.Generic;

namespace EshopApi.Models
{
    public partial class OrderItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
