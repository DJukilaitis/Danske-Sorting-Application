using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.Services;
using Moq;

public class NumberOrderingServiceTests
{
    private readonly Mock<INumberOrderingRepository> numberOrderingRepository;
    private readonly NumberOrderingService numberOrderingService;

    public NumberOrderingServiceTests()
    {
        numberOrderingRepository = new Mock<INumberOrderingRepository>();
        numberOrderingService = new NumberOrderingService(numberOrderingRepository.Object);
    }

    [Fact]
    public async Task OrderNumbers_ShouldSortAndSave()
    {
        var numbers = new List<int> { 5, 3, 8, 1, 2 };
        var sortedNumbers = new List<int> { 1, 2, 3, 5, 8 };

        await numberOrderingService.OrderNumbers(numbers);

        numberOrderingRepository.Verify(repo => repo.SaveToFileAsync(It.Is<List<int>>(n => n.SequenceEqual(sortedNumbers)), It.IsAny<CancellationToken>()), Times.Once);
    }
}
