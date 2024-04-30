using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Entities
{
    public class Billing
    {
        public int Id { get; set; }
        public DateTime BillingDate { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
