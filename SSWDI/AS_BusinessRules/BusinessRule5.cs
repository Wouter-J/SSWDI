using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;


namespace AS_BusinessRules
{
    /// <summary>
    /// Animals Age needs to be caluclated on Birthday
    /// Or a Guessed Age needs to be added
    /// </summary>
    public class BusinessRule5
    {
        [Fact]
        public void AnimalAgeDateTimeCalculatesProperly()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();

            IAnimalService animalService = new AnimalService(animalRepository.Object, lodgingRepository.Object);

            Animal dog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            animalService.Add(dog);

            // Assert
            // Get our dog with the calculated age
            Animal calculatedDog = animalRepository.Object.FindByID(dog.ID);

            animalRepository.Verify(x => x.Add(dog), Times.Once());
            animalRepository.Verify(x => x.Add(dog));
            Assert.Equal(4, calculatedDog.Age);
        }

        [Fact]
        public void AnimalEstimatedAgeCalculatesProperly()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();

            IAnimalService animalService = new AnimalService(animalRepository.Object, lodgingRepository.Object);

            Animal dog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                EstimatedAge = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            animalService.Add(dog);

            // Assert
            // Get our dog with the calculated age
            Animal calculatedDog = animalRepository.Object.FindByID(dog.ID);

            animalRepository.Verify(x => x.Add(dog), Times.Once());
            animalRepository.Verify(x => x.Add(dog));
            Assert.Equal(2, calculatedDog.Age);
        }

        [Fact]
        public void AnimalCantHaveGuessedAgeAndBirthday()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();

            IAnimalService animalService = new AnimalService(animalRepository.Object, lodgingRepository.Object);

            Animal dog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                EstimatedAge = 4,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => animalService.Add(dog));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Animal can't have estimated age & birthday", ex.Message);
        }

        [Fact]
        public void AnimalAgeCantBeNegative()
        {
            // Arrange
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();

            IAnimalService animalService = new AnimalService(animalRepository.Object, lodgingRepository.Object);

            Animal dog = new Animal
            {
                ID = 1,
                Name = "Doggo",
                Age = -1,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => animalService.Add(dog));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Add", ex.TargetSite.Name); // Make sure the error is thrown by the Add method; not something else
            Assert.Equal("Age can't be less then 0", ex.Message);
        }
    }
}
