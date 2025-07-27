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
    internal class OrderItemConfigurations : BaseEntityConfigurations<OrderItem, int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.UnitPrice)
                .HasColumnType("decimal(9, 2)");

            builder.HasOne(E => E.Order)
                .WithMany(O => O.OrderItems)
                .HasForeignKey(E => E.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
