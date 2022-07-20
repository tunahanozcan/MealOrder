using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.Shared.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }

        public string CreatedUserFullName { get; set; }
        public string SupplierName { get; set; }

    }
}
