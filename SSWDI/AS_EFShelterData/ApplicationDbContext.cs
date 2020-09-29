using System;
using AS_Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AS_EFShelterData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        //Define DBSets
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO: Add entity relations here
        }
    }
}
