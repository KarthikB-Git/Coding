using LeetCodeTestbench.Common;
using LeetCodeTestbench.Solutions.P876_MiddleOfTheLinkedList;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P876_MiddleOfTheLinkedList;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 6 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    public void MiddleNode_ReturnsExpectedMiddleLinkedList(int[] input, int[] expected)
    {
        var head = TestHelpers.BuildList(input);
        var actualNode = _sut.MiddleNode(head!);
        var actual = TestHelpers.ToArray(actualNode);

        output.WriteLine($"Input:    [{string.Join(", ", input)}]");
        output.WriteLine($"Expected: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual:   [{string.Join(", ", actual)}]");

        Assert.Equal(expected, actual);
    }
}

