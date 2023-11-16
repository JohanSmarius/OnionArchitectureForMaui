using Domain;   

namespace Domain.Tests
{
    public class ClotingRequestTests
    {
        [Fact]
        public void DesiredSize_Given_Smallest_Baby_Size_Should_Set_Size()
        {
            var sut = new ClothingRequest() { DesiredSize = "50" };
            Assert.Equal("50", sut.DesiredSize);
        }

        [Fact]
        public void DesiredSize_Given_Smaller_Than_Baby_Size_Should_Set_Size()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ClothingRequest() { DesiredSize = "49" });
        }

        [Fact]
        public void DesiredSize_Given_Greater_Than_Baby_Size_Should_Set_Size()
        {
            var sut = new ClothingRequest() { DesiredSize = "51" };
            Assert.Equal("51", sut.DesiredSize);
        }

        [Fact]
        public void DesiredSize_Given_Largest_Child_Size_Should_Set_Size()
        {
            var sut = new ClothingRequest() { DesiredSize = "168" };
            Assert.Equal("168", sut.DesiredSize);
        }

        [Fact]
        public void DesiredSize_Given_Greater_Than_Largest_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ClothingRequest() { DesiredSize = "169" });
        }

        [Fact]
        public void DesiredSize_Given_Smaller_Than_Largest_Child_Size_Should_Set_Size()
        {
            var sut = new ClothingRequest() { DesiredSize = "167" };
            Assert.Equal("167", sut.DesiredSize);
        }

    }
}