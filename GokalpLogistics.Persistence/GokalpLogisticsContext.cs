using GokalpLogistics.Domain.Abstract;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GokalpLogistics.Persistence
{
    /// <summary>
    /// GokalpLogisticsContext : DbContext => Veri tabanımıza bağlanmak için GokalpLogisticsContext
    ///     sınıfına sorumluluk yükledik.
    /// ----------------------------------------------------
    /// Dbset<> => Veri tabanımızda ki tablolara karşılık gelir.
    /// ---------------------------------------------------
    /// void OnConfiguring(DbContextOptionsBuilder) => 
    ///     Veri tabanımıza bağlanan stringi ayarlıyoruz.
    /// ---------------------------------------------------
    /// void OnModelCreating(ModelBuilder) => Bu fonksiyonun içinde eklediğimiz her model
    ///     veri tabanımıza eklenen tablolarımız daki default olarak atanan özellikleri
    ///     değiştirmemize olanak sağlar.
    /// ----------------------------------------------------
    /// Task<int> SaveChangesAsync(bool, CancellationToken) =>
    ///     Veri tabanında bir veri silindliğinde tam olarak silmemek için yazıyoruz.
    /// </summary>
    public class GokalpLogisticsContext : DbContext
    {
        #region Tables
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        #endregion

        #region Constructor
        public GokalpLogisticsContext(DbContextOptions<GokalpLogisticsContext> opt) : base(opt)
        {

        }
        #endregion

        #region Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=GLOGISTICSDB8;Trusted_Connection=True;TrustServerCertificate=True");
        }
        #endregion

        #region ModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new DriverMapping());
            modelBuilder.ApplyConfiguration(new TruckMapping());

            //Aşağıdaki entity türleri için isDeleted bilgisi false olanların otomatik olarak filtrelenmesi sağlanır.
            //modelBuilder.Entity<Truck>().HasQueryFilter(x => x.IsDeleted == null);
            //modelBuilder.Entity<Driver>().HasQueryFilter(x => x.IsDeleted == null);

            //modelBuilder.Entity<Driver>()
            //        .HasOne(d => d.Truck)
            //        .WithOne(t => t.Driver)
            //        .HasForeignKey<Truck>(t => t.driverId)
            //        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Truck>()
            //        .HasOne(t => t.Driver)
            //        .WithOne(t => t.Truck)
            //        .HasForeignKey<Truck>(t => t.driverId)
            //        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Driver>().HasOne(d => d.Truck).WithOne(t => t.Driver).HasForeignKey<Truck>(t => t.DriverId);
        }
        #endregion

        #region SaveAsync
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Herhangi bir kayıt işleminde yapılan işlem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.
            //Herhangi bir kayıt işleminde yapılan işlem güncelleme ise ModifiedDate ve ModifiedBy bilgileri otomatik olarak set edilir.

            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion
    }
}

