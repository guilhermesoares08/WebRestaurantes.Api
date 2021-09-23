using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Login).HasColumnName("Login").IsRequired().HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired().HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
            builder.Property(p => p.Password).HasColumnName("Password").IsRequired().HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
            builder.Property(p => p.VendorId).HasColumnName("VendorId").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(50);
            builder.Property(p => p.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType(SqlServerDbTypes.BIT).HasMaxLength(256);
        }
    }
}
