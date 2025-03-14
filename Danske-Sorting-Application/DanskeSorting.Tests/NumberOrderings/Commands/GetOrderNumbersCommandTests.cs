using Danske_Sorting_Application.Exceptions;
using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.NumberOrderings;
using Moq;

namespace DanskeSorting.Tests.NumberOrderings.Commands
{
    public class GetOrderNumbersCommandTests
    {
        private readonly Mock<INumberOrderingRepository> numberOrderingRepositoryMock;
        private readonly GetOrderNumbersCommandHandler handler;

        public GetOrderNumbersCommandTests()
        {
            numberOrderingRepositoryMock = new Mock<INumberOrderingRepository>();
            handler = new GetOrderNumbersCommandHandler(numberOrderingRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_FileExists_ShouldReturnContent()
        {
            var expectedContent = "1 2 3 4 5";
            numberOrderingRepositoryMock
                .Setup(repo => repo.GetLatestFileContentAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedContent);

            var command = new GetOrderNumbersCommand();

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(expectedContent, result);
            numberOrderingRepositoryMock.Verify(
                repo => repo.GetLatestFileContentAsync(CancellationToken.None),
                Times.Once
            );
        }

        [Fact]
        public async Task Handle_NoFile_ShouldThrowNotFoundException()
        {
            numberOrderingRepositoryMock
                .Setup(repo => repo.GetLatestFileContentAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync((string?)null);

            var command = new GetOrderNumbersCommand();

            await Assert.ThrowsAsync<NotFoundException>(
                () => handler.Handle(command, CancellationToken.None)
            );

            numberOrderingRepositoryMock.Verify(
                repo => repo.GetLatestFileContentAsync(CancellationToken.None),
                Times.Once
            );
        }
    }
}
