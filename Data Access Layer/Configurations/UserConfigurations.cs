using Data_Access_Layer.Configurations.Base;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.Configurations
{
    internal class UserConfigurations : BaseEntityConfigurations<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.Username)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(E => E.PasswordHash)
                .IsRequired();

            builder.Property(E => E.Role)
                .IsRequired();
        }
    }
}
