using LeetCodeTestbench.Solutions.P1441_BuildAnArrayWithStackOperations;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1441_BuildAnArrayWithStackOperations;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1,3 }, 3, new[] { "Push","Push","Pop","Push" })]
    [InlineData(new[] { 1,2,3 }, 3, new[] { "Push","Push","Push" })]
    [InlineData(new[] { 1,2 }, 4, new[] { "Push","Push" })]
    public void BuildArray_ReturnsExpectedResult(int[] target, int n, string[] expected)
    {
        var actual = _sut.BuildArray(target, n);
        output.WriteLine($"Expected Input: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");
        Assert.Equal(expected, actual);
    }
}
