using Data_Access_Layer.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class OrderItem : BaseEntity<int>
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }




        public int? OrderId { get; set; }

        public Order? Order { get; set; } = null!;
    }
}
