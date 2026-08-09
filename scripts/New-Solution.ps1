[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, HelpMessage = "Name of the problem/solution (e.g., P1470_ShuffleTheArray)")]
    [string]$Name
)

# Normalize Name
# If user inputs a problem starting with digits like "1470_ShuffleTheArray", prefix with "P"
if ($Name -match '^\d') {
    $Name = "P$Name"
}

# Remove invalid characters (keep alphanumeric and underscores)
$CleanName = $Name -replace '[^\w]', ''

if ([string]::IsNullOrWhiteSpace($CleanName)) {
    Write-Error "Invalid solution name provided: '$Name'"
    exit 1
}

# Generate kebab-case problem slug for LeetCode URL (e.g. ShuffleTheArray -> shuffle-the-array)
$TitlePart = $CleanName -replace '^P?\d*_?', ''
if ([string]::IsNullOrWhiteSpace($TitlePart)) {
    $TitlePart = $CleanName
}
$KebabSlug = [regex]::Replace($TitlePart, '([a-z0-9])([A-Z])', '$1-$2').ToLower()

# Resolve paths relative to script location
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$WorkspaceRoot = Split-Path -Parent $ScriptDir
$SandboxDir = Join-Path $WorkspaceRoot "LeetCodeSandbox"
$SolutionsDir = Join-Path $SandboxDir "Solutions"
$TemplatesDir = Join-Path $SandboxDir "Templates"

$SolutionTemplatePath = Join-Path $TemplatesDir "SolutionBoilerplate.cs"
$TestTemplatePath = Join-Path $TemplatesDir "SolutionTestsBoilerplate.cs"

if (-not (Test-Path $SolutionsDir)) {
    New-Item -ItemType Directory -Path $SolutionsDir -Force | Out-Null
}

$SolutionFilePath = Join-Path $SolutionsDir "$CleanName.cs"
$TestFilePath = Join-Path $SolutionsDir "${CleanName}Test.cs"

# 1. Load Solution Template
if (Test-Path $SolutionTemplatePath) {
    $SolutionContent = Get-Content -Path $SolutionTemplatePath -Raw
}
else {
    $SolutionContent = @"
namespace LeetCodeTestbench.Solutions.PXXXX_ProblemName;

// https://leetcode.com/problems/problem-name/
public class Solution
{
    // Paste LeetCode solution method signature here:
    // public int ExampleMethod(int[] nums)
    // {
    //     
    // }
}
"@
}

# 2. Load Test Template
if (Test-Path $TestTemplatePath) {
    $TestContent = Get-Content -Path $TestTemplatePath -Raw
}
else {
    $TestContent = @"
using LeetCodeTestbench.Common;
using LeetCodeTestbench.Solutions.PXXXX_ProblemName;
using Xunit;

namespace LeetCodeTestbench.Tests.PXXXX_ProblemName;

public class SolutionTests
{
    private readonly Solution _sut = new();

    // Example 1: Testing primitive/array inputs
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int target, int[] expected)
    {
        // Act
        // var actual = _sut.TwoSum(nums, target);

        // Assert
        // Assert.Equal(expected, actual);
    }
}
"@
}

# Perform template replacements
$SolutionContent = $SolutionContent -replace 'PXXXX_ProblemName', $CleanName
$SolutionContent = $SolutionContent -replace 'problem-name', $KebabSlug

$TestContent = $TestContent -replace 'PXXXX_ProblemName', $CleanName

# Create Solution File
if (Test-Path $SolutionFilePath) {
    Write-Warning "Solution file already exists: $SolutionFilePath"
}
else {
    Set-Content -Path $SolutionFilePath -Value $SolutionContent -Encoding UTF8
    Write-Host "Created Solution File: $SolutionFilePath" -ForegroundColor Green
}

# Create Test File
if (Test-Path $TestFilePath) {
    Write-Warning "Test file already exists: $TestFilePath"
}
else {
    Set-Content -Path $TestFilePath -Value $TestContent -Encoding UTF8
    Write-Host "Created Test File: $TestFilePath" -ForegroundColor Green
}