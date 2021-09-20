using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Table");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.Property(p => p.RestaurantId).HasColumnName("RestaurantId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Seats).HasColumnName("Seats").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.VendorId).HasColumnName("VendorId").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.Property(p => p.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType(SqlServerDbTypes.BIT);
            builder.Property(p => p.IsBusy).HasColumnName("IsBusy").IsRequired().HasColumnType(SqlServerDbTypes.BIT);
            builder.HasOne(p => p.Restaurant).WithOne().HasForeignKey<Restaurant>(p => p.Id);
        }
    }
}
