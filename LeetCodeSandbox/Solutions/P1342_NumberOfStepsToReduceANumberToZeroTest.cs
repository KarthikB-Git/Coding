using LeetCodeTestbench.Solutions.P1342_NumberOfStepsToReduceANumberToZero;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1342_NumberOfStepsToReduceANumberToZero;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(14, 6)]
    [InlineData(8, 4)]
    [InlineData(123, 12)]
    public void NumberOfSteps_ReturnsExpectedResult(int num, int expected)
    {
        var actual = _sut.NumberOfSteps(num);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
