using GokalpLogistics.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpLogistics.Persistence.Mappings
{
    public class TruckMapping : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("TRUCKS");

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

            builder.Property(t => t.Model)
                .IsRequired()
                .HasColumnName("MODEL")
                .HasColumnType("nvarchar(15)");
        }
    }
}
