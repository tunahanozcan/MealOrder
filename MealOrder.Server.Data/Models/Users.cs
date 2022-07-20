using System;
using System.Collections.Generic;

namespace MealOrder.Server.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            OrderItems = new HashSet<OrderItems>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
