using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Images");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.URL).HasColumnName("URL").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.Property(p => p.Extension).HasColumnName("Extension").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
            builder.Property(p => p.RestaurantId).HasColumnName("RestaurantId").IsRequired().ValueGeneratedOnAdd().HasColumnType(SqlServerDbTypes.INT);
        }
    }
}
