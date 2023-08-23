using GokalpLogistics.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpLogistics.Persistence.Mappings
{
    public class DriverMapping : BaseMapping<Driver>
    {
        public override void Configure(EntityTypeBuilder<Driver> builder)
        {
            base.Configure(builder);

            builder.ToTable("DRIVER");

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("SURNAME")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.Username)
                .HasColumnName("USERNAME")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.TruckId)
                .HasColumnName("TRUCK_ID")
                .IsRequired();

            builder.HasOne(x => x.Truck)
                .WithOne(x => x.Driver)
                .HasForeignKey<Driver>(x => x.TruckId);
        }
    }
}
