using Microsoft.EntityFrameworkCore;

namespace BE_U2_W1_D5.Models.Entity
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Anagrafica> Anagrafica { get; set; }

        public DbSet<Verbale> Verbale { get; set; }

        public DbSet<TipoViolazione> TipoViolazione { get; set; }

        public DbSet<Verbale_Violazione> Verbale_Violazione { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verbale_Violazione>()
                .HasKey(vv => new { vv.IDVerbale, vv.IDViolazione });
            modelBuilder.Entity<Verbale_Violazione>()
                .HasOne(vv => vv.verbale)
                .WithMany()
                .HasForeignKey(v => v.IDVerbale);
            modelBuilder.Entity<Verbale_Violazione>()
                .HasOne(vv => vv.violazione)
                .WithMany()
                .HasForeignKey(v => v.IDViolazione);

            modelBuilder.Entity<Verbale>()
                .HasOne(v=> v.anagrafica)
                .WithMany(a=> a.Verbali)
                .HasForeignKey(v => v.IDVerbale);
        }
    }
}
