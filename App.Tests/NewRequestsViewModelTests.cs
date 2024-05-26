using Moq;
using TiramisuApp.Services;
using TiramisuApp.ViewModels;
using TiramisuApp.Models;

namespace App.Tests
{
    public class NewRequestsViewModelTests
    {
        [Fact]
        public void AddNewRequetAsync_Given_Correct_Input_Should_Navigate()
        {
            // Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockRequestService = new Mock<IRequestService>();
            var sut = new NewRequestViewModel(mockNavigationService.Object, mockRequestService.Object);

            // Act
            sut.AddNewRequestCommand.Execute(null);


            // Assert
            mockNavigationService.Verify(x => x.NavigateAsync("//OpenRequests"), Times.Once);
        }

        [Fact]
        public void AddNewRequetAsync_Given_Correct_Input_Should_Save_New_Request()
        {
            // Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockRequestService = new Mock<IRequestService>();
            var sut = new NewRequestViewModel(mockNavigationService.Object, mockRequestService.Object);

            // Act
            sut.AddNewRequestCommand.Execute(null);


            // Assert
            mockRequestService.Verify(x => x.AddRequest(It.IsAny<ClothingRequest>()), Times.Once);
        }
    }
}