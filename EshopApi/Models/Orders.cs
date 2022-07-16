using System;
using System.Collections.Generic;

namespace EshopApi.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }

        public Customer Customer { get; set; }
        public SalesPersons SalesPerson { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
