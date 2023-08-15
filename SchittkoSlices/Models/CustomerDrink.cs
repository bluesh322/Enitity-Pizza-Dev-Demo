using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class CustomerDrink
    {
        public int CustomerOrderId { get; set; }
        public string? Drink { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; } = null!;
        public virtual Drink? DrinkNavigation { get; set; }
    }
}
