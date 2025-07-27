using Data_Access_Layer.Models.Generic;

namespace Data_Access_Layer.Models
{
    public class User : BaseEntity<int>
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
    }
}
