using Data_Access_Layer.Models.Generic;

namespace Data_Access_Layer.Models
{
    public class Order : BaseEntity<int>
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; } 

            

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }


        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
