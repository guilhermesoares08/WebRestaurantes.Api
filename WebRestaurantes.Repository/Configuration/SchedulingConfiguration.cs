using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebRestaurantes.Domain;
using static WebRestaurantes.Repository.Constants;

namespace WebRestaurantes.Repository
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Scheduling");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.TableId).HasColumnName("TableId").IsRequired(false).HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.RestaurantId).HasColumnName("RestaurantId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.ScheduleDate).HasColumnName("ScheduleDate").IsRequired().HasColumnType(SqlServerDbTypes.DATE);
            builder.Property(p => p.ScheduleTime).HasColumnName("ScheduleTime").IsRequired().HasColumnType(SqlServerDbTypes.TIME);
            builder.Property(p => p.Expired).HasColumnName("Expired").IsRequired().HasColumnType(SqlServerDbTypes.BIT);
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate").IsRequired().HasColumnType(SqlServerDbTypes.DATE);
            builder.Property(p => p.UpdateDate).HasColumnName("UpdateDate").IsRequired().HasColumnType(SqlServerDbTypes.DATE);
            builder.Property(p => p.StatusId).HasColumnName("StatusId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            //builder.HasOne(p => p.Restaurant).WithOne().HasForeignKey<Restaurant>(p => p.Id);
        }
    }
}
