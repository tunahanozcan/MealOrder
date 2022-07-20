using System;
using System.Collections.Generic;

namespace MealOrder.Server.Data.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual Users CreatedUser { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
