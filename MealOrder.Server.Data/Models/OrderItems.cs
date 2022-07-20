using System;
using System.Collections.Generic;

namespace MealOrder.Server.Data.Models
{
    public partial class OrderItems
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }

        public virtual Users CreatedUser { get; set; }
        public virtual Orders Order { get; set; }
    }
}
