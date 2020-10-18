namespace AS_ServiceTests
{
    using System;
    using System.Collections.Generic;
    using AS_Core.DomainModel;
    using AS_DomainServices;
    using AS_Services;
    using Moq;
    using Xunit;

    public class AnimalServiceTest
    {
        [Fact]
        public void AnimalShouldBeAdded()
        {
            // Arrange
            // IStayRepository stayRepository;
            // Mock stayServiceMock = new StayService(stayRepository);
            var stayRepository = new Mock<IStayRepository>();
            var stayService = new Mock<StayService>();

            Animal dog = new Animal()
            {
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Best Bois",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            Lodging coolLocation = new Lodging()
            {
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };

            Stay stay = new Stay()
            {
                Animal = dog,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = string.Empty,
                LodgingLocation = coolLocation,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Act
            stayService.Setup(_ => _.Add(stay));

            // Assert
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();

            // Assert.Equal(stays)
        }
    }
}
