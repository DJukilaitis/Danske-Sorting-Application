using System.Diagnostics;

namespace Danske_Sorting_Application.Utils
{
    public static class SortingAlgorithms
    {
        public static List<int> BubbleSort(List<int> numbers)
        {
            var numbersToSort = new List<int>(numbers);

            for (int i = 0; i < numbersToSort.Count; i++)
            {
                bool swapped = false;
                for (int j = 0; j < numbersToSort.Count - 1 - i; j++)
                {
                    if (numbersToSort[j] > numbersToSort[j + 1])
                    {
                        (numbersToSort[j], numbersToSort[j + 1]) = (numbersToSort[j + 1], numbersToSort[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }

            return numbersToSort;
        }

        public static List<int> QuickSort(List<int> numbers)
        {
            var numbersToSort = new List<int>(numbers);
            SortHelper(numbersToSort, 0, numbersToSort.Count - 1);
            return numbersToSort;
        }

        private static void SortHelper(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                SortHelper(list, low, pivotIndex - 1);
                SortHelper(list, pivotIndex + 1, high);
            }
        }

        private static int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (list[j] <= pivot)
                {
                    i++;
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            var tempPivot = list[i + 1];
            list[i + 1] = list[high];
            list[high] = tempPivot;

            return i + 1;
        }

        public static List<int> BogoSort(List<int> numbers)
        {
            Random random = new Random();

            while (!IsSorted(numbers))
            {
                Shuffle(numbers, random);
            }

            return numbers;
        }

        private static bool IsSorted(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] > numbers[i])
                    return false;
            }

            return true;
        }

        private static void Shuffle(List<int> numbers, Random random)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int j = random.Next(i, numbers.Count);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }

        public static void CompareSortingPerformance(List<int> numbers)
        {
            var sortingMethods = new Dictionary<string, Func<List<int>, List<int>>>
            {
                { "Bubble Sort", BubbleSort },
                { "Quick Sort", QuickSort }
            };

            foreach (var method in sortingMethods)
            {
                var watch = Stopwatch.StartNew();
                var sortedNumbers = method.Value(numbers); // Execute sorting algorithm
                watch.Stop();

                Console.WriteLine($"{method.Key}: {watch.ElapsedMilliseconds} ms");
            }
        }
    }
}
