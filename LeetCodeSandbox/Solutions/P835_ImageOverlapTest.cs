using LeetCodeTestbench.Solutions.P835_ImageOverlap;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P835_ImageOverlap;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    public static TheoryData<int[][], int[][], int> TestCases => new()
    {
        { [[1,1,0], [0,1,0], [0,1,0]], [[0,0,0], [0,1,1], [0,0,1]], 3 },
        { [[1]], [[1]], 1 },
        { [[0]], [[0]], 0 },
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void LargestOverlap_ReturnsExpectedResult(int[][] img1, int[][] img2, int expected)
    {
        var actual = _sut.LargestOverlap(img1, img2);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
