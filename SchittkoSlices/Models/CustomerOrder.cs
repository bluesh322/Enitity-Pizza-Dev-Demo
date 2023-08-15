using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CreditCardId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
