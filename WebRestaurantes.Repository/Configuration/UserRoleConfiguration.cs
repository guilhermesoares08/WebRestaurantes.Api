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

            builder.ToTable("AspNetUserRoles");
            builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.RoleId).HasColumnName("RoleId").IsRequired().HasColumnType(SqlServerDbTypes.INT);

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
