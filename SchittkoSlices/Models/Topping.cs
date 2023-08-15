using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping1Navigation = new HashSet<Pizza>();
            PizzaTopping2Navigation = new HashSet<Pizza>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Pizza> PizzaTopping1Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaTopping2Navigation { get; set; }
    }
}
