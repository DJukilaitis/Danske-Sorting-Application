using Danske_Sorting_Application.Utils;

public class SortingAlgorithmsTests
{
    [Fact]
    public void SortingAlgorithms_ShouldSort()
    {
        var numbers = new List<int> { 5, 3, 8, 1, 2 };
        var sortedNumbers = new List<int> { 1, 2, 3, 5, 8 };

        var bubbleSortedList = SortingAlgorithms.BubbleSort(numbers);
        var quickSortedList = SortingAlgorithms.QuickSort(numbers);

        Assert.Equal(sortedNumbers, bubbleSortedList);
        Assert.Equal(sortedNumbers, quickSortedList);
    }
}
