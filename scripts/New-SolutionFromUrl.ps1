[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, HelpMessage = "LeetCode problem URL (e.g. https://leetcode.com/problems/shuffle-the-array/)")]
    [string]$Url
)

# ------------------------------------------------------------------
# 1. Extract the title slug from the URL
# ------------------------------------------------------------------
if ($Url -notmatch '/problems/([a-z0-9\-]+)') {
    Write-Error "Could not find a problem slug in URL: '$Url'. Expected something like https://leetcode.com/problems/two-sum/"
    exit 1
}
$Slug = $Matches[1]

# ------------------------------------------------------------------
# 2. Query LeetCode's GraphQL endpoint for problem details
# ------------------------------------------------------------------
$GraphQLQuery = @"
query questionData(`$titleSlug: String!) {
  question(titleSlug: `$titleSlug) {
    questionFrontendId
    title
    difficulty
    codeSnippets {
      langSlug
      code
    }
  }
}
"@

$Body = @{
    operationName = "questionData"
    variables     = @{ titleSlug = $Slug }
    query         = $GraphQLQuery
} | ConvertTo-Json -Depth 5

$Headers = @{
    "Content-Type" = "application/json"
    "Referer"      = "https://leetcode.com/problems/$Slug/"
    "User-Agent"   = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0 Safari/537.36"
}

Write-Host "Fetching problem data for '$Slug' from LeetCode..." -ForegroundColor Cyan

try {
    $Response = Invoke-RestMethod -Uri "https://leetcode.com/graphql" -Method Post -Headers $Headers -Body $Body -ErrorAction Stop
}
catch {
    Write-Warning "Failed to reach LeetCode's API: $($_.Exception.Message)"
    Write-Warning "Falling back to manual entry. Run the 'Create New Solution & Test' task instead and type the name yourself."
    exit 1
}

$Question = $Response.data.question

if (-not $Question -or -not $Question.title) {
    Write-Error "LeetCode returned no data for slug '$Slug'. Check the URL is correct."
    exit 1
}

# ------------------------------------------------------------------
# 3. Build CleanName: P{frontendId}_{PascalCaseTitle}
# ------------------------------------------------------------------
function ConvertTo-PascalCase {
    param([string]$Text)
    $Words = $Text -split '[^a-zA-Z0-9]+' | Where-Object { $_ -ne '' }
    ($Words | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1) }) -join ''
}

$PascalTitle = ConvertTo-PascalCase -Text $Question.title
$CleanName = "P$($Question.questionFrontendId)_$PascalTitle"
$KebabSlug = $Slug

Write-Host "Resolved: $CleanName ($($Question.difficulty))" -ForegroundColor Green

# ------------------------------------------------------------------
# 4. Extract the C# method signature and method name from codeSnippets
# ------------------------------------------------------------------
$CSharpSnippet = $Question.codeSnippets | Where-Object { $_.langSlug -eq 'csharp' } | Select-Object -First 1

$MethodSignature = $null
$MethodName = "~#methodname#~"

if ($CSharpSnippet) {
    # Grab the line(s) between the outer "public class Solution {" and the final closing brace
    $Lines = $CSharpSnippet.code -split "`n"
    $Inner = $Lines | Select-Object -Skip 1 | Select-Object -SkipLast 1
    $MethodSignature = ($Inner -join "`n").TrimEnd()

    if ($MethodSignature -match '\b([A-Za-z0-9_]+)\s*\(') {
        $MethodName = $Matches[1]
    }
}

# ------------------------------------------------------------------
# 5. Resolve paths
# ------------------------------------------------------------------
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

# ------------------------------------------------------------------
# 6. Load templates
# ------------------------------------------------------------------
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

# ------------------------------------------------------------------
# 7. Perform template replacements
# ------------------------------------------------------------------
$SolutionContent = $SolutionContent -replace 'PXXXX_ProblemName', $CleanName
$SolutionContent = $SolutionContent -replace 'problem-name', $KebabSlug

$TestContent = $TestContent -replace 'PXXXX_ProblemName', $CleanName
$TestContent = $TestContent -replace '~#methodname#~', $MethodName

if ($MethodSignature) {
    if ($MethodSignature -match '\{\s*\}') {
        $MethodSignature = $MethodSignature -replace '\{\s*\}', "{`n        throw new System.NotImplementedException();`n    }"
    }
    $ReplacementBlock = "    $($MethodSignature.Trim())"
}
else {
    $ReplacementBlock = "    // Paste LeetCode solution method signature here:"
}

$SafeReplacementBlock = $ReplacementBlock -replace '\$', '$$$$'

if ($SolutionContent -match '(?ms)// Paste LeetCode solution method signature here:.*?(\r?\n\})') {
    $SolutionContent = $SolutionContent -replace '(?ms)// Paste LeetCode solution method signature here:.*?(\r?\n\})', "$SafeReplacementBlock`n}"
}
else {
    $SolutionContent = $SolutionContent.TrimEnd()
    $SolutionContent = $SolutionContent.Substring(0, $SolutionContent.LastIndexOf('}'))
    $SolutionContent += "`n$ReplacementBlock`n}`n"
}

# ------------------------------------------------------------------
# 8. Write files
# ------------------------------------------------------------------
if (Test-Path $SolutionFilePath) {
    Write-Warning "Solution file already exists: $SolutionFilePath"
}
else {
    Set-Content -Path $SolutionFilePath -Value $SolutionContent -Encoding UTF8
    Write-Host "Created Solution File: $SolutionFilePath" -ForegroundColor Green
}

if (Test-Path $TestFilePath) {
    Write-Warning "Test file already exists: $TestFilePath"
}
else {
    Set-Content -Path $TestFilePath -Value $TestContent -Encoding UTF8
    Write-Host "Created Test File: $TestFilePath" -ForegroundColor Green
}
