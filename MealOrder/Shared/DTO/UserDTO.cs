using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.Shared.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsActive { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
