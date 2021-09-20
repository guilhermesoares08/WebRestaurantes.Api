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

            builder.ToTable("AspNetUsers");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.UserName).HasColumnName("UserName").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
            builder.Property(p => p.NormalizedEmail).HasColumnName("NormalizedEmail").IsRequired(false).HasColumnType(SqlServerDbTypes.NVARCHAR).HasMaxLength(256);
        }
    }
}
