using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Specific Treatments require comments
    /// </summary>
    public class BusinessRule4
    {
        [Fact]
        public void VaccinationTreatmentShouldHaveDescription()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal dog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };
            Treatment vaccination = new Treatment()
            {
                ID = 1,
                TreatmentType = TreatmentType.Vaccination,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry",
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(vaccination));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Vaccination needs a description", ex.Message);
        }

        [Fact]
        public void ChippingTreatmentShouldHaveDescription()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal dog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };
            Treatment vaccination = new Treatment()
            {
                ID = 1,
                TreatmentType = TreatmentType.Chipping,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry",
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(vaccination));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Chipping needs a description", ex.Message);
        }

        [Fact]
        public void OperationTreatmentShouldHaveDescription()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal dog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };
            Treatment vaccination = new Treatment()
            {
                ID = 1,
                TreatmentType = TreatmentType.Operation,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry",
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(vaccination));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Operation needs a description", ex.Message);
        }

        [Fact]
        public void EuthanasiaTreatmentShouldHaveDescription()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal dog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };
            Treatment vaccination = new Treatment()
            {
                ID = 1,
                TreatmentType = TreatmentType.Euthanasia,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry",
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(vaccination));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Euthanasia needs a description", ex.Message);
        }
    }
}
