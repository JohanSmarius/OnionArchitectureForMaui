using Moq;
using TiramisuApp.Services;
using TiramisuApp.ViewModels;

namespace App.Tests
{
    public class NewRequestsViewModelTests
    {
        [Fact]
        public void AddNewRequetAsync_Given_Correct_Input_Should_Navigate()
        {
            var mockNavigationService = new Mock<INavigationService>();
            var sut = new NewRequestViewModel(mockNavigationService.Object);

            sut.AddNewRequestCommand.Execute(null);

            mockNavigationService.Verify(x => x.NavigateAsync("//OpenRequests"), Times.Once);
        }
    }
}