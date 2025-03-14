using Danske_Sorting_Application.Exceptions;
using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.NumberOrderings;
using Moq;

namespace DanskeSorting.Tests.NumberOrderings.Commands
{
    public class GetLatestOrderedNumbersCommandTests
    {
        private readonly Mock<INumberOrderingRepository> numberOrderingRepositoryMock;
        private readonly GetLatestOrderedNumbersCommandHandler handler;

        public GetLatestOrderedNumbersCommandTests()
        {
            numberOrderingRepositoryMock = new Mock<INumberOrderingRepository>();
            handler = new GetLatestOrderedNumbersCommandHandler(numberOrderingRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_FileExists_ShouldReturnContent()
        {
            var expectedContent = "1 2 3 4 5";
            numberOrderingRepositoryMock
                .Setup(repo => repo.GetLatestFileContentAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedContent);

            var command = new GetLatestOrderedNumbersCommand();

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

            var command = new GetLatestOrderedNumbersCommand();

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
