using System;
using System.Collections.Generic;

namespace EshopApi.Models
{
    public partial class SalesPersons
    {
        public SalesPersons()
        {
            Orders = new HashSet<Orders>();
        }

        public int SalesPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
