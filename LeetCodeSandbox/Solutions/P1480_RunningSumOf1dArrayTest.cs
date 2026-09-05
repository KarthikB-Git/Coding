using LeetCodeTestbench.Solutions.P1480_RunningSumOf1dArray;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1480_RunningSumOf1dArray;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1,2,3,4 }, new[] { 1,3,6,10 })]
    [InlineData(new[] { 1,1,1,1,1 }, new[] { 1,2,3,4,5 })]
    [InlineData(new[] { 3,1,2,10,1 }, new[] { 3,4,6,16,17 })]
    public void RunningSum_ReturnsExpectedResult(int[] nums, int[] expected)
    {
        var actual = _sut.RunningSum(nums);
        output.WriteLine($"Expected Output: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");
        Assert.Equal(expected, actual);
    }
}
