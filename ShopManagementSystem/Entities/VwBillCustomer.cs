using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Entities
{
    public class VwBillCustomer
    {
        public DateTime BillingDate { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public string CustomerName { get; set; }
    }
}
