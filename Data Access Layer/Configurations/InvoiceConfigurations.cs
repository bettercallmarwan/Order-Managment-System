using Data_Access_Layer.Configurations.Base;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.Configurations
{
    internal class InvoiceConfigurations : BaseEntityConfigurations<Invoice, int>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.InvoiceDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(E => E.TotalAmount)
                .HasColumnType("decimal(9, 2)");

            builder.HasOne(E => E.Order)
            .WithMany()
            .HasForeignKey(E => E.OrderId)
            .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
