using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
