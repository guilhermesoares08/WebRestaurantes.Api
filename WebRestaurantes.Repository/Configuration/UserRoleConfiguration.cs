using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("UserRole").HasNoKey();
            builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.RoleId).HasColumnName("RoleId").IsRequired().HasColumnType(SqlServerDbTypes.INT);

            builder.HasOne(ur => ur.User)
                .WithOne()
                .HasForeignKey<UserRole>(ur => ur.UserId)
                .IsRequired();

            builder.HasOne(ur => ur.Role)
                .WithOne()
                .HasForeignKey<UserRole>(ur => ur.RoleId)
                .IsRequired();
        }
    }
}
