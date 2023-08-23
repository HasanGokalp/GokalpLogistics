using GokalpLogistics.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpLogistics.Persistence.Mappings
{
    public class DriverMapping : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("DRIVER");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("0")
                .HasColumnName("IS_DELETED");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(15)");

            builder.Property(t => t.Surname)
                .IsRequired()
                .HasColumnName("MODEL")
                .HasColumnType("nvarchar(15)");

            //builder.Property(x => x.Truck)
            //        .HasOne(d => d.Truck)
            //        .WithOne(t => t.Driver)
            //        .HasForeignKey<Truck>(t => t.Id);
        }
    }
}
