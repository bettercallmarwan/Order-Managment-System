using Data_Access_Layer.Configurations.Base;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.Configurations
{
    internal class ProductConfigurations : BaseEntityConfigurations<Product, int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.Name)
                .IsRequired();

            builder.Property(E => E.Price)
                .HasColumnType("decimal(9, 2)")
                .IsRequired();

            builder.Property(E => E.Stock)
                .IsRequired();
        }
    }
}
