using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.NumberOrderings;
using MediatR;
using Moq;

namespace DanskeSorting.Tests.NumberOrderings.Commands
{
    public class SaveOrderedNumbersCommandTests
    {
        private readonly Mock<INumberOrderingService> numberOrderingServiceMock;
        private readonly SaveOrderedNumbersCommandHandler handler;

        public SaveOrderedNumbersCommandTests()
        {
            numberOrderingServiceMock = new Mock<INumberOrderingService>();
            handler = new SaveOrderedNumbersCommandHandler(numberOrderingServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidNumbers_ShouldCallOrderingService()
        {
            var numbers = new List<int> { 5, 3, 8, 1, 2 };
            var command = new SaveOrderedNumbersCommand(numbers);
            var cancellationToken = CancellationToken.None;

            await handler.Handle(command, cancellationToken);

            numberOrderingServiceMock.Verify(
                s => s.OrderNumbers(It.Is<List<int>>(n => n.SequenceEqual(numbers)), cancellationToken),
                Times.Once
            );
        }

        [Fact]
        public async Task Handle_NullNumbers_ShouldThrowArgumentException()
        {
            var command = new SaveOrderedNumbersCommand(null);

            await Assert.ThrowsAsync<ArgumentException>(
                () => handler.Handle(command, CancellationToken.None)
            );
        }

        [Fact]
        public async Task Handle_Numbers_ShouldSucceed()
        {
            var command = new SaveOrderedNumbersCommand([1, 2, 3, 8, 9, 0, 2, 10, 2, 0, 1]);
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(Unit.Value, result);
        }
    }
}
