using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
