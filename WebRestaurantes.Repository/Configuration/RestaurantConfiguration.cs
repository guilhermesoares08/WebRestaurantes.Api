using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Restaurants");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.HasOne(p => p.Owner).WithOne().HasForeignKey<User>(p => p.Id);
        }
    }
}
