using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class CustomerPizza
    {
        public int? CustomerOrderId { get; set; }
        public int? PizzaId { get; set; }

        public virtual CustomerOrder? CustomerOrder { get; set; }
        public virtual Pizza? Pizza { get; set; }
    }
}
