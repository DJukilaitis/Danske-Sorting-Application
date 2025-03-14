namespace Danske_Sorting_Application.Interfaces
{
    public interface INumberOrderingService
    {
        Task OrderNumbers(List<int> numbers, CancellationToken cancellationToken = default);
    }
}
