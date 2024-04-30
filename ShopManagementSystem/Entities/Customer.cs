using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Billing> Billings { get; set; }
    }
}
