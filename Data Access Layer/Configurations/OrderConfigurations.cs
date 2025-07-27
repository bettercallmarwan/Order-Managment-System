using Data_Access_Layer.Configurations.Base;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Configurations
{
    internal class OrderConfigurations : BaseEntityConfigurations<Order, int>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.OrderDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(E => E.TotalAmount)
                .HasColumnType("decimal(9, 2)");

            builder.HasOne(E => E.Customer)
                .WithMany(C => C.Orders)
                .HasForeignKey(E => E.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
