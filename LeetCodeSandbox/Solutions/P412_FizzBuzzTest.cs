using LeetCodeTestbench.Solutions.P412_FizzBuzz;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P412_FizzBuzz;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(3, new[] { "1","2","Fizz" })]
    [InlineData(5, new[] { "1","2","Fizz","4","Buzz" })]
    [InlineData(15, new[] { "1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" })]
    public void FizzBuzz_ReturnsExpectedResult(int n, string[] expected)
    {
        var actual = _sut.FizzBuzz(n);
        output.WriteLine($"Expected Output: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");
        Assert.Equal(expected, actual);
    }
}
