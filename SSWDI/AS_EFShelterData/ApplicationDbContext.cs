using System;
using System.Collections.Generic;
using AS_Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AS_EFShelterData
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        // Define DBSets
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Lodging> Lodgings { get; set; }

        public DbSet<Stay> Stays { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<InterestedAnimal> InterestedAnimals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make sure email is unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // One to One / One to Many relations
            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Treatments)
                .WithOne(t => t.Stay);

            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stay);

            modelBuilder.Entity<Stay>()
                .HasOne(a => a.Animal);

            modelBuilder.Entity<Lodging>()
                .HasMany(l => l.Stays)
                .WithOne(s => s.LodgingLocation);



            // Many to many relations; EF 5.0 update
            /*
            modelBuilder.Entity<User>()
                .HasMany(a => a.InterestInAnimals)
                .WithMany(p => p.InterestedAnimals)
                .UsingEntity<InterestedAnimal>( );
            */

            // Many-toMany EF 3.8
            modelBuilder.Entity<InterestedAnimal>()
                .HasKey(x => new { x.AnimalID, x.UserID });

            modelBuilder.Entity<InterestedAnimal>()
                .HasOne(x => x.User)
                .WithMany(y => y.InterestedAnimals)
                .HasForeignKey(y => y.UserID);

            modelBuilder.Entity<InterestedAnimal>()
                .HasOne(x => x.Animal)
                .WithMany(y => y.InterestedAnimals)
                .HasForeignKey(y => y.AnimalID);

            // Uses ModelBuilderExtensions; Seed method
            modelBuilder.Seed();
        }

    }
}
