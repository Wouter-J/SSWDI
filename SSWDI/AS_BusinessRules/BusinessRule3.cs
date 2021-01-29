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
    /// Business Rule 03
    /// Treatments can't be added if the Animal is not placed yet.
    /// Nor can treatments be added after Animal passing
    /// </summary>
    public class BusinessRule3
    {
        [Fact]
        public void ProperTreatmentCanBeAddedToAnimal() 
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal dog = new Animal
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
            Lodging dogGroupLocation = new Lodging
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay
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
            Treatment smallOperation = new Treatment
            {
                ID = 1,
                Description = "Small operation to help recovery",
                TreatmentType = TreatmentType.Operation,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry", // TODO: This needs a relation to the user
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);


            //Act
            treatmentService.Add(smallOperation);

            //Assert
            treatmentRepository.Verify(x => x.Add(smallOperation), Times.Once());
            treatmentRepository.Verify(x => x.Add(smallOperation));
        }

        [Fact]
        public void DeceasedAnimalsCantHaveTreatments() 
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal deceasedDog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = new DateTime(2021, 01, 10),
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay
            {
                ID = 1,
                Animal = deceasedDog,
                AnimalID = deceasedDog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };
            Treatment smallOperation = new Treatment
            {
                ID = 1,
                Description = "Small operation to help recovery",
                TreatmentType = TreatmentType.Operation,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry", // TODO: This needs a relation to the user
                Date = new DateTime(2020, 12, 30),
                StayID = 1,
                Stay = stay,
            };

            animalRepository.Setup(e => e.FindByID(deceasedDog.ID))
                .Returns(deceasedDog);

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(smallOperation));

            //Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Animal must be alive in order to perform treatment", ex.Message);
        }

        [Fact]
        public void AnimalsWithoutPlacementCantHaveTreatments()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ITreatmentRepository> treatmentRepository = new Mock<ITreatmentRepository>();

            ITreatmentService treatmentService = new TreatmentService(treatmentRepository.Object, animalRepository.Object);

            Animal newDog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = new DateTime(2021, 01, 10),
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Treatment smallOperation = new Treatment
            {
                ID = 1,
                Description = "Small operation to help recovery",
                TreatmentType = TreatmentType.Operation,
                Costs = 100,
                RequiredAge = 1,
                DoneBy = "Barry", // TODO: This needs a relation to the user
                Date = new DateTime(2020, 12, 30),
            };

            animalRepository.Setup(e => e.FindByID(newDog.ID))
                .Returns(newDog);

            var ex = Assert.Throws<InvalidOperationException>(() => treatmentService.Add(smallOperation));

            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Animal needs to be placed", ex.Message);
        }
    }
}
