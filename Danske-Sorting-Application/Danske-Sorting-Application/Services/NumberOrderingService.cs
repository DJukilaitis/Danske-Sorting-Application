using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.Utils;

namespace Danske_Sorting_Application.Services
{
    public class NumberOrderingService : INumberOrderingService
    {
        private readonly INumberOrderingRepository numberOrderingRepository;

        public NumberOrderingService(INumberOrderingRepository numberOrderingRepository)
        {
            this.numberOrderingRepository = numberOrderingRepository;
        }

        public async Task OrderNumbers(List<int> numbers, CancellationToken cancellationToken = default)
        {
            var orderedNumbers = SortingAlgorithms.BubbleSort(numbers);

            await numberOrderingRepository.SaveToFileAsync(orderedNumbers, cancellationToken);
        }
    }
}
