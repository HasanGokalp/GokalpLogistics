using GokalpLogistics.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpLogistics.Persistence.Mappings
{
    public class TruckMapping : BaseMapping<Truck>
    {
        public override void Configure(EntityTypeBuilder<Truck> builder)
        {
            base.Configure(builder);
            builder.ToTable("TRUCK");

            builder.Property(x => x.TruckName)
                .HasColumnName("TRUCKNAME")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.TruckModel)
                .HasColumnName("TRUCKMODEL")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Property(x => x.Lat)
                .HasColumnName("LAT")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(x => x.Lng)
                .HasColumnName("LNG")
                .HasColumnType("integer")
                .IsRequired();

            builder.HasOne(x => x.Driver)
               .WithOne(x => x.Truck)
               .HasForeignKey<Truck>(x => x.DriverId);
        }
    }
}
