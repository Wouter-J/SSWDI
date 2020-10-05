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

        //Define DBSets
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ManyToMany Relations
            modelBuilder.Entity<AnimalStay>()
                .HasOne(ay => ay.Animal)
                .WithMany(a => a.AnimalStays);

            modelBuilder.Entity<AnimalStay>()
                .HasOne(ay => ay.Stay)
                .WithMany(s => s.AnimalStays);

            //One to One / One to Many relations
            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Treatments)
                .WithOne(t => t.Stay);

            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stay);

            modelBuilder.Entity<Lodging>()
                .HasMany(l => l.AnimalStays)
                .WithOne(s => s.LodgingLocation);

            //TODO: Create SeedData file
            //modelBuilder.Entity<Lodging>().HasData(
            //    new Lodging { ID = 1, LodgingType = LodgingType.Group, MaxCapacity = 20,
            //        AnimalType = AnimalType.Dog, AnimalStays = new List<Stay>() }
            //);

            modelBuilder.Entity<Animal>().HasData(
                new Animal { ID = 1, Name = "Doggo", Birthdate = DateTime.Now, Age = 1, EstimatedAge = 1,
                    Description = "Good boi", AnimalType = AnimalType.Dog, Race = "Best Bois", Picture = "Goodboi.png",
                    DateOfDeath = null, Castrated = true, ChildFriendly = ChildFriendly.Yes, ReasonGivenAway = "Too good a boi",
                    AnimalStays = new List<AnimalStay>() {
                        new AnimalStay { Animal = { ID = 1 }, Stay = { ID = 1 } }
                    },
                }
            );

            modelBuilder.Entity<Treatment>().HasData(
                new Treatment { ID = 1, Description = "Inenting voor ziekte x", TreatmentType = TreatmentType.Vaccination, 
                                Costs = 100.50M, RequiredAge = 1, DoneBy = "Some Person", Date = DateTime.Now, Stay = new Stay { ID = 1 } }
            );

            modelBuilder.Entity<Stay>().HasData(
                new Stay { ID = 1, AnimalStays = new List<AnimalStay>(), ArrivalDate = DateTime.Now, 
                    AdoptionDate = DateTime.Now, CanBeAdopted = true, AdoptedBy = "Barry", 
                    LodgingLocation = new Lodging { ID = 1, LodgingType = LodgingType.Group, MaxCapacity = 20,
                    AnimalType = AnimalType.Dog, AnimalStays = new List<Stay>() }, 
                    Comments = new List<Comment>(), Treatments = new List<Treatment>() }    
            );


        }
    }
}
