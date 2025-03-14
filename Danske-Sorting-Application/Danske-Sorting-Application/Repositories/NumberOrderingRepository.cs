using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.Models;
using Microsoft.Extensions.Options;

namespace Danske_Sorting_Application.Repositories
{
    public class NumberOrderingRepository : INumberOrderingRepository
    {
        private string filePath;

        public NumberOrderingRepository(IOptions<FileSettings> fileSettings)
        {
            filePath = fileSettings.Value.FilePath;
        }

        public async Task SaveToFileAsync(List<int> numbers, CancellationToken cancellationToken = default)
        {
            string storagePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);

            string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileStoragePath = Path.Combine(storagePath, $"numbers_{dateTimeString}.txt");

            var content = string.Join(" ", numbers);

            await File.WriteAllTextAsync(fileStoragePath, content, cancellationToken);
        }

        public async Task<string?> GetLatestFileContentAsync(CancellationToken cancellationToken = default)
        {
            if (Directory.Exists(filePath))
            {
                var file = Directory.EnumerateFiles(filePath, "numbers_*.txt")
                                    .Select(file => new FileInfo(file))
                                    .OrderByDescending(file => file.Name)
                                    .FirstOrDefault();

                if (file != null)
                    return await File.ReadAllTextAsync(file.FullName, cancellationToken);
            }

            return null;
        }
    }
}
