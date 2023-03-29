using Microsoft.EntityFrameworkCore;

namespace Projet_PFA.Models
{
    public class MyContext:DbContext
    {
        public DbSet<Employer> Employer { get; set; }
        public DbSet<HeuresSupp> HeuresSupp { get; set; }
        public DbSet<Absence> Absence { get; set; }
        public DbSet<Penalite> Penalite { get; set; }
        public DbSet<Pointage> Pointage { get; set; }
        public DbSet<Supplementaire> Supplementaire { get; set; }
        public DbSet<Retard> Retard { get; set; }
        public DbSet<Superviseur> Superviseur { get; set; }
        public DbSet<Directeur> Directeur { get; set; }
        public DbSet<UserAuthentifier> UserAuthentifier { get; set; }
        public MyContext(DbContextOptions opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAuthentifier>().UseTpcMappingStrategy();
        }
    }
}
