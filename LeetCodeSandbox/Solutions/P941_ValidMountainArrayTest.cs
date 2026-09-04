using LeetCodeTestbench.Solutions.P941_ValidMountainArray;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P941_ValidMountainArray;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2, 1 }, false)]
    [InlineData(new[] { 3, 5, 5 }, false)]
    [InlineData(new[] { 0, 3, 2, 1 }, true)]
    [InlineData(new[] { 0, 1, 2, 3, 4 }, false)]
    [InlineData(new[] { 4, 3, 2, 1, 0 }, false)]
    [InlineData(new[] { 0, 2, 3, 4, 5, 2, 1, 0 }, true)]
    [InlineData(new[] { 0, 1, 2, 2, 1, 0 }, false)]
    public void ValidMountainArray_ReturnsExpectedResult(int[] arr, bool expected)
    {
        var actual = _sut.ValidMountainArray(arr);
        output.WriteLine("Expected output: " + (expected ? "True" : "False"));
        output.WriteLine("Actual output: " + (actual ? "True" : "False"));
        Assert.Equal(expected, actual);
    }
}
