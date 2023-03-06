using FluentAssertions;
using Hero_net.helpper;
using Hero_net.Models;
using Hero_UnitTest.Helpers;

namespace Hero_UnitTest.Service;

public class TestAlgorithmService
{
    [Theory]
    [ClassData(typeof(DataFixture.RemoveDuplicateData))]
    public void RemoveDuplicate(int[] nums, int expected)
    {
        // Arrange
        var algorithmService = new Algorithm();

        // Act
        var result = algorithmService.RemoveDuplicates(nums);

        // Assert
        Assert.Equal(expected, algorithmService.RemoveDuplicates(nums));
    }
    
    [Theory]
    [JsonFileData("algorithmData.json", "SelectionSort")]
    public void SortSelection(int[] nums, int[] expected)
    {
        // Arrange
        var algorithmService = new Algorithm();

        // Act
        var result = algorithmService.SortSelection(nums);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LargestNumber()
    {
        // Arrange
        var algorithmService = new Algorithm();

        // Act
        var result = algorithmService.LargestNumber(new int[] {30, 3, 34, 9, 5});
        
        // Assert
        Assert.Equal("9534330",result);
    }
}