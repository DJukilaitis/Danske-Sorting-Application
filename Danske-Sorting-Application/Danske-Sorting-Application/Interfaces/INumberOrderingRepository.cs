namespace Danske_Sorting_Application.Interfaces
{
    public interface INumberOrderingRepository
    {
        Task SaveToFileAsync(List<int> numbers, CancellationToken cancellationToken = default);
        Task<string?> GetLatestFileContentAsync(CancellationToken cancellationToken = default);
    }
}