using Domain;
using DomainService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.ViewModels;

namespace App.Tests
{
    public class OpenRequestsViewmodelTests
    {
        [Fact]
        public void GetOpenRequestsAsync_WhenCalled_AddsRequestsToOpenRequests()
        {
            // Arrange
            var requestRepository = new Mock<IRequestRepository>();
            var viewModel = new OpenRequestsViewModel(requestRepository.Object);

            var requestsFromServer = new List<ClothingRequest>()
            {
                new ClothingRequest { Age = 14, Gender = Gender.Boy, DesiredSize= "M"}
            };
            requestRepository.Setup(repo => repo.GetOpenRequestsAsync()).ReturnsAsync(requestsFromServer);

            // Act
            viewModel.GetOpenRequestsCommand.Execute(null);

            // Assert
            Assert.Equal(3, viewModel.OpenRequests.Count);
            Assert.Equal(Gender.Boy, viewModel.OpenRequests[2].Gender);
        }
        
    }
}
