using System;
using System.Collections.Generic;

namespace MealOrder.Server.Data.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
