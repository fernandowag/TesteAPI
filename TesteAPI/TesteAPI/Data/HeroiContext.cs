using Microsoft.EntityFrameworkCore;

using TesteAPI.Models;

namespace TesteAPI.Data
{
    public class HeroiContext : DbContext
    { 
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }
        public DbSet<Vilao> Viloes { get; set; }

        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
        {
                
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;User ID=userapi;Password = userapi; Initial Catalog = mydb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => 
            { 
                entity.HasKey( e => new { e.BatalhaId, e.HeroiId }); 
            });
        }

 
    }
}
