using LeetCodeTestbench.Solutions.P1700_NumberOfStudentsUnableToEatLunch;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1700_NumberOfStudentsUnableToEatLunch;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1,1,0,0 }, new[] { 0,1,0,1 }, 0)]
    [InlineData(new[] { 1,1,1,0,0,1 }, new[] { 1,0,0,0,1,1 }, 3)]
    public void CountStudents_ReturnsExpectedResult(int[] students, int[] sandwiches, int expected)
    {
        var actual = _sut.CountStudents(students, sandwiches);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
