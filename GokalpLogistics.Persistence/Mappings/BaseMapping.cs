using GokalpLogistics.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpLogistics.Persistence.Mappings
{
    public class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValueSql("0")
                .HasColumnName("IS_DELETED")
                .IsRequired();
        }
    }
}
