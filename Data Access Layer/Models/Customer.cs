using Data_Access_Layer.Models.Generic;

namespace Data_Access_Layer.Models
{
    public class Customer : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}
