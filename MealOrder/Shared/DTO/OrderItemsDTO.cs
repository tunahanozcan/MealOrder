using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.Shared.DTO
{
    public class OrderItemsDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string CreatedUserFullName { get; set; }
        public string OrderName { get; set; }
    }
}
