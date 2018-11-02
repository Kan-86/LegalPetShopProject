using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity;
using PetShopRestAPI.Models;

namespace PetApp.Infastructure.Static.Data
{
    public class PetShopAppContext:DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt): base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PetPreviousOwner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);

            // map like this for the key  
            //modelBuilder.Entity<Owner>()
            //    .HasKey(o => new { o.Id, o.Pets });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
