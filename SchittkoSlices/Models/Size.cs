using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class Size
    {
        public Size()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
