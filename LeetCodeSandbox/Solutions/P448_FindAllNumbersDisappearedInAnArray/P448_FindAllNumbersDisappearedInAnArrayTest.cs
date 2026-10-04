using System.Text.Json;
using LeetCodeTestbench.Solutions.P448_FindAllNumbersDisappearedInAnArray;

namespace LeetCodeTestbench.Tests.P448_FindAllNumbersDisappearedInAnArray;

public record FindDisappearedNumbersCase(int[]? Input, int[]? Expected);

public class SolutionTests
{
    private readonly Solution _sut = new();

    public static TheoryData<int[], int[]> CasesFromJson
    {
        get
        {
            var data = new TheoryData<int[], int[]>();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            const string problemDirectory = "P448_FindAllNumbersDisappearedInAnArray";
            string directoryPath = Path.Combine(AppContext.BaseDirectory, "Solutions", problemDirectory);
            if (!Directory.Exists(directoryPath))
            {
                directoryPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "LeetCodeSandbox",
                    "Solutions",
                    problemDirectory);
            }
            if (Directory.Exists(directoryPath))
            {
                foreach (string jsonPath in Directory.GetFiles(directoryPath, "*.json"))
                {
                    string json = File.ReadAllText(jsonPath).Trim();
                    if (string.IsNullOrWhiteSpace(json)) continue;

                    if (json.StartsWith("["))
                    {
                        var cases = JsonSerializer.Deserialize<List<FindDisappearedNumbersCase>>(json, options);
                        if (cases is not null)
                        {
                            foreach (var tc in cases)
                            {
                                if (tc is { Input: not null, Expected: not null })
                                {
                                    data.Add(tc.Input, tc.Expected);
                                }
                            }
                        }
                    }
                    else
                    {
                        var tc = JsonSerializer.Deserialize<FindDisappearedNumbersCase>(json, options);
                        if (tc is { Input: not null, Expected: not null })
                        {
                            data.Add(tc.Input, tc.Expected);
                        }
                    }
                }
            }
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(CasesFromJson), DisableDiscoveryEnumeration = true)]
    public void Solution_ReturnsExpectedResult(int[] nums, int[] expected)
    {
        // Act
        var actual = _sut.FindDisappearedNumbers((int[])nums.Clone());

        // Assert
        Assert.Equal(expected, actual);
    }
}
