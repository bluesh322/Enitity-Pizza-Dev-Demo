using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class CustomerOrderPreference
    {
        public int? CustomerId { get; set; }
        public int? CustomerOrderId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual CustomerOrder? CustomerOrder { get; set; }
    }
}
