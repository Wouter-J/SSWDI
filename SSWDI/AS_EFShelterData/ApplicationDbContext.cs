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
                .HasKey(ay => new { ay.AnimalID, ay.StayID });

            modelBuilder.Entity<AnimalStay>()
                .HasOne(ay => ay.Animal)
                .WithMany(a => a.AnimalStays)
                .HasForeignKey(ay => ay.AnimalID);

            modelBuilder.Entity<AnimalStay>()
                .HasOne(ay => ay.Stay)
                .WithMany(s => s.AnimalStays)
                .HasForeignKey(ay => ay.StayID);

            //One to One / One to Many relations
            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Treatments)
                .WithOne(t => t.Stay);

            modelBuilder.Entity<Stay>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stay)
                .HasForeignKey(s => s.ID);

            modelBuilder.Entity<Lodging>()
                .HasMany(l => l.AnimalStays)
                .WithOne(s => s.LodgingLocation);

            //TODO: Create SeedData file
            Lodging lodging = new Lodging
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 20,
                AnimalType = AnimalType.Dog,
                AnimalStays = new List<Stay>()
            };

            Stay stay = new Stay
            {
                ID = 1,
                AnimalStays = new List<AnimalStay>(),
                ArrivalDate = DateTime.Now,
                AdoptionDate = DateTime.Now,
                CanBeAdopted = true,
                AdoptedBy = "Barry",
                LodgingLocation = lodging,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>()
            };

            Animal dog = new Animal
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
            };

            Treatment treatment = new Treatment
            {
                ID = 1,
                Description = "Inenting voor ziekte x",
                TreatmentType = TreatmentType.Vaccination,
                Costs = 100.50M,
                RequiredAge = 1,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                Stay = stay
            };

            AnimalStay animalStay = new AnimalStay
            {
                AnimalID = dog.ID,
                StayID = stay.ID,
                //Animal = dog,
                //Stay = stay
            };

            stay.Treatments.Add(treatment);

            //Add data to DB
            modelBuilder.Entity<Lodging>().HasData(lodging);
            modelBuilder.Entity<Stay>().HasData(stay);
            modelBuilder.Entity<Animal>().HasData(dog);
            modelBuilder.Entity<Treatment>().HasData(treatment);
            modelBuilder.Entity<AnimalStay>().HasData(animalStay);
            //modelBuilder.Entity<Comment>().HasData(comment);

        }

    }
}
