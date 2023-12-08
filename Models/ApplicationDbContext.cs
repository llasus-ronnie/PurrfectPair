using Microsoft.EntityFrameworkCore;
using PurrfectPair.Models;

namespace PurrfectPair.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<PetAdopting> PetAdoptings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Pets>().ToTable("PetAdoption");

        }

        public DbSet<PetSubmission> PetSubmissions { get; set; }
        //public DbSet<Pet> Pets { get; set; }

    }
}






