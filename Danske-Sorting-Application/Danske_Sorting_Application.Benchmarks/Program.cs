using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Danske_Sorting_Application.Utils;

namespace Danske_Sorting_Application.Benchmarks
{
    public class SortingBenchmarks
    {
        private List<List<int>> lists = [];

        [GlobalSetup]
        public void Setup()
        {
            lists = new List<List<int>>
            {
                new List<int> { 5, 3, 8, 1, 2 },
                new List<int> { 5, 3, 8, 1, 2, 9, 6, 7, 4, 0, 11, 13, 10, 6, 8, 12 },
                new List<int> { 5, 3, 8, 1, 2, 9, 6, 7, 4, 0, 11, 13, 10, 6, 8, 12, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }
            };
        }

        [Benchmark]
        public void SortUsingBubbleSort()
        {
            foreach (var list in lists)
                SortingAlgorithms.BubbleSort(list);
        }

        [Benchmark]
        public void SortUsingQuickSort()
        {
            foreach (var list in lists)
                SortingAlgorithms.QuickSort(list);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SortingBenchmarks>();
        }
    }
}
