using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Role");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired().HasColumnType(SqlServerDbTypes.NVARCHAR_MAX);
        }
    }
}
