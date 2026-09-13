using LeetCodeTestbench.Solutions.P3875_ConstructUniformParityArrayI;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P3875_ConstructUniformParityArrayI;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2,3 }, true)]
    [InlineData(new[] { 4,6 }, true)]
    [InlineData(new[] { 1 }, true)]
    [InlineData(new[] { 2 }, true)]
    [InlineData(new[] { 2, 4, 6, 8 }, true)]
    [InlineData(new[] { 1, 3, 5, 7 }, true)]
    [InlineData(new[] { 2, 4, 6, 8, 10, 3 }, true)]
    [InlineData(new[] { 1, 3, 5, 7, 9, 2 }, true)]
    [InlineData(new[] { 100, 99 }, true)]
    [InlineData(new[] { 1, 2 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, true)]
    public void UniformArray_ReturnsExpectedResult(int[] nums1, bool expected)
    {
        var actual = _sut.UniformArray(nums1);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
