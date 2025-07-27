using Data_Access_Layer.Models.Generic;

namespace Data_Access_Layer.Models
{
    public class Product : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int  Stock { get; set; }
    }
}
