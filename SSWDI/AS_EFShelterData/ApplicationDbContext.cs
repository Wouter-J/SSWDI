using System;
using System.Collections.Generic;
using AS_Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AS_EFShelterData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        // Define DBSets
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to One / One to Many relations
            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Treatments)
                .WithOne(t => t.Stay);

            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stay)
                .HasForeignKey(s => s.ID);

            modelBuilder.Entity<Lodging>()
                .HasMany(l => l.Stays)
                .WithOne(s => s.LodgingLocation);

            // TODO add animal / Stay relation

            // TODO: Create SeedData file
            modelBuilder.Entity<Lodging>().HasData(new Lodging
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 20,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>()
            });

            modelBuilder.Entity<Stay>().HasData(new
            {
                ID = 1,
                Animal = new Animal(), // TODO properly add Animal relation
                ArrivalDate = DateTime.Now,
                AdoptionDate = DateTime.Now,
                CanBeAdopted = true,
                AdoptedBy = "Barry",
                LodgingLocationID = 1,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>()
            });

            modelBuilder.Entity<Animal>().HasData(
            new Animal
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = DateTime.Now,
                Age = 1,
                EstimatedAge = 1,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Best Bois",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            }
            );

            modelBuilder.Entity<Treatment>().HasData(new
            {
                ID = 1,
                Description = "Inenting voor ziekte x",
                TreatmentType = TreatmentType.Vaccination,
                Costs = 100.50M,
                RequiredAge = 1,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                StayID = 1
            });

            modelBuilder.Entity<Comment>().HasData(new
            {
                ID = 1,
                Content = "Best boi",
                Date = DateTime.Now,
                WrittenBy = "Dr. Barry",
                StayID = 1
            });


        }


    }
}
