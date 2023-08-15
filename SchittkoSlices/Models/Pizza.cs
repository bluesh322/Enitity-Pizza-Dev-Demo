using System;
using System.Collections.Generic;

namespace SchittkoSlices.Models
{
    public partial class Pizza
    {
        public int Id { get; set; }
        public string? Size { get; set; }
        public string? Topping1 { get; set; }
        public string? Topping2 { get; set; }

        public virtual Size? SizeNavigation { get; set; }
        public virtual Topping? Topping1Navigation { get; set; }
        public virtual Topping? Topping2Navigation { get; set; }
    }
}
