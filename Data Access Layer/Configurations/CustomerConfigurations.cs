using Data_Access_Layer.Configurations.Base;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.Configurations
{
    internal class CustomerConfigurations : BaseEntityConfigurations<Customer, int>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(E => E.Email)
                .IsRequired()
                .HasMaxLength(100);


        }
    }
}
