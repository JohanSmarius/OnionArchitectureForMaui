using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Services;
using TiramisuApp.Models;


namespace App.Tests
{
    public class RequestServiceTests
    {
        [Fact]
        public async void GetOpenRequests_Given_Network_Connection_Returns_Data_From_Api()
        {
            // Arrange
            var deviceStatus = new Mock<IDeviceStatus>();
            deviceStatus.Setup(x => x.IsOnline()).ReturnsAsync(true);
            var clothingRepository = new Mock<IClothingRepository>();
            var clothingCache = new Mock<IClothingCache>();
            var requestService = new RequestService(clothingRepository.Object, clothingCache.Object, deviceStatus.Object);
            var clothingRequests = new List<ClothingRequest>
           {
               new ClothingRequest { Id = 1, RequestedClothes = "Shirt" },
               new ClothingRequest { Id = 2, RequestedClothes = "Pants" }
           };
            clothingRepository.Setup(x => x.GetClothings()).ReturnsAsync(clothingRequests);
            clothingCache.Setup(x => x.GetClothings()).ReturnsAsync(new List<ClothingRequest>());

            // Act
            await requestService.GetOpenRequests();

            // Assert
            Assert.Equal(clothingRequests, requestService.OpenRequests);
            clothingRepository.Verify(x => x.GetClothings(), Times.Once);
            clothingCache.Verify(x => x.GetClothings(), Times.Never);
        }


        [Fact]
        public async void GetOpenRequests_Given__No_Network_Connection_Returns_Data_From_Cache()
        {
            // Arrange
            var deviceStatus = new Mock<IDeviceStatus>();
            deviceStatus.Setup(x => x.IsOnline()).ReturnsAsync(false);
            var clothingRepository = new Mock<IClothingRepository>();
            var clothingCache = new Mock<IClothingCache>();
            var requestService = new RequestService(clothingRepository.Object, clothingCache.Object, deviceStatus.Object);
            var clothingRequests = new List<ClothingRequest>
           {
               new ClothingRequest { Id = 1, RequestedClothes = "Shirt" },
               new ClothingRequest { Id = 2, RequestedClothes = "Pants" }
           };
            clothingRepository.Setup(x => x.GetClothings()).ReturnsAsync(new List<ClothingRequest>());
            clothingCache.Setup(x => x.GetClothings()).ReturnsAsync(clothingRequests);

            // Act
            await requestService.GetOpenRequests();

            // Assert
            Assert.Equal(clothingRequests, requestService.OpenRequests);
            clothingRepository.Verify(x => x.GetClothings(), Times.Never);
            clothingCache.Verify(x => x.GetClothings(), Times.Once);
        }

    }
}
