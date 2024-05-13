using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;

namespace CarFactoryAPI
{
    public class OwnerRepositoryTest
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;

        public OwnerRepositoryTest()
        {
            // Create Mock of dependencies
            factoryContextMock = new Mock<FactoryContext>();

            // use fake object as dependency
            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }
        [Fact]
        [Trait("Author", "Ahmed")]

        public void GetOwnerById_AskForOwner10_ReturnOwner()
        {
            // Arrange
            // Build the mock Data
            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            Owner owner = ownerRepository.GetOwnerById(10);

            // Assert
            Assert.NotNull(owner);

        }
        [Fact]
        [Trait("Author", "Ahmed")]
        public void GetAllOwners_WhenCalled_ReturnAllOwners()
        {
            // Arrange
            // Build the mock Data
            List<Owner> owners = new List<Owner>()
            {
                new Owner() { Id = 1, Name = "Owner1" },
                new Owner() { Id = 2, Name = "Owner2" },
                new Owner() { Id = 3, Name = "Owner3" }
            };

            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            var result = ownerRepository.GetAllOwners();

            // Assert
            Assert.Equal(owners.Count, result.Count);
        }



    }
}
