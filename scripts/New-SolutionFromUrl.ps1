[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, HelpMessage = "LeetCode problem URL (e.g. https://leetcode.com/problems/shuffle-the-array/)")]
    [string]$Url
)

# ------------------------------------------------------------------
# 1. Extract the title slug from the URL
# ------------------------------------------------------------------
$CleanInput = $Url.Trim("'", '"', ' ')
if ($CleanInput -match '/problems/([a-z0-9\-]+)') {
    $Slug = $Matches[1]
}
elseif ($CleanInput -match '^[a-z0-9\-]+$') {
    $Slug = $CleanInput
}
else {
    Write-Error "Could not extract problem slug from input: '$Url'. Expected a LeetCode problem URL or slug (e.g. https://leetcode.com/problems/two-sum/)"
    exit 1
}

# ------------------------------------------------------------------
# 2. Query LeetCode's GraphQL endpoint for problem details
# ------------------------------------------------------------------
$GraphQLQuery = @"
query questionData(`$titleSlug: String!) {
  question(titleSlug: `$titleSlug) {
    questionFrontendId
    title
    difficulty
    topicTags {
      name
      slug
    }
    codeSnippets {
      langSlug
      code
    }
    content
    exampleTestcases
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
# 3. Helper functions & CleanName: P{frontendId}_{PascalCaseTitle}
# ------------------------------------------------------------------
function ConvertTo-PascalCase {
    param([string]$Text)
    $Words = $Text -split '[^a-zA-Z0-9]+' | Where-Object { $_ -ne '' }
    ($Words | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1) }) -join ''
}

function ConvertTo-TopicEnum {
    param([string]$Tag)
    $normalized = $Tag.ToLower() -replace '[^a-z0-9]', ''
    switch ($normalized) {
        "array" { "Topic.Array" }
        "string" { "Topic.String" }
        "hashtable" { "Topic.HashTable" }
        "hashmap" { "Topic.HashTable" }
        "dynamicprogramming" { "Topic.DynamicProgramming" }
        "math" { "Topic.Math" }
        "sorting" { "Topic.Sorting" }
        "greedy" { "Topic.Greedy" }
        "depthfirstsearch" { "Topic.DepthFirstSearch" }
        "dfs" { "Topic.DepthFirstSearch" }
        "breadthfirstsearch" { "Topic.BreadthFirstSearch" }
        "bfs" { "Topic.BreadthFirstSearch" }
        "binarysearch" { "Topic.BinarySearch" }
        "matrix" { "Topic.Matrix" }
        "twopointers" { "Topic.TwoPointers" }
        "bitmanipulation" { "Topic.BitManipulation" }
        "stack" { "Topic.Stack" }
        "heap" { "Topic.Heap" }
        "heappriorityqueue" { "Topic.Heap" }
        "graph" { "Topic.Graph" }
        "prefixsum" { "Topic.PrefixSum" }
        "simulation" { "Topic.Simulation" }
        "design" { "Topic.Design" }
        "counting" { "Topic.Counting" }
        "backtracking" { "Topic.Backtracking" }
        "slidingwindow" { "Topic.SlidingWindow" }
        "unionfind" { "Topic.UnionFind" }
        "linkedlist" { "Topic.LinkedList" }
        "tree" { "Topic.Tree" }
        "binarytree" { "Topic.BinaryTree" }
        "monotonicstack" { "Topic.MonotonicStack" }
        "trie" { "Topic.Trie" }
        "divideandconquer" { "Topic.DivideAndConquer" }
        "queue" { "Topic.Queue" }
        "recursion" { "Topic.Recursion" }
        "enumeration" { "Topic.Enumeration" }
        "memoization" { "Topic.Memoization" }
        "segmenttree" { "Topic.SegmentTree" }
        "binaryindexedtree" { "Topic.BinaryIndexedTree" }
        "shortestpath" { "Topic.ShortestPath" }
        "gametheory" { "Topic.GameTheory" }
        "orderedset" { "Topic.OrderedSet" }
        "rollinghash" { "Topic.RollingHash" }
        default { "Topic.Other" }
    }
}

function Format-CSharpValue {
    param(
        [string]$RawValue,
        [string]$ParamType
    )

    if (-not $RawValue) { return "null" }
    $Raw = $RawValue.Trim()

    if ($Raw -eq "null") { return "null" }

    # ListNode
    if ($ParamType -eq "ListNode" -or $ParamType -eq "ListNode?") {
        if ($Raw -match '^\[(.*)\]$') {
            $inner = $Matches[1].Trim()
            if ([string]::IsNullOrWhiteSpace($inner)) { return "null" }
            return "TestHelpers.BuildList($inner)"
        }
    }

    # TreeNode
    if ($ParamType -eq "TreeNode" -or $ParamType -eq "TreeNode?") {
        if ($Raw -match '^\[(.*)\]$') {
            $inner = $Matches[1].Trim()
            if ([string]::IsNullOrWhiteSpace($inner)) { return "null" }
            return "TestHelpers.BuildTree($inner)"
        }
    }

    # Arrays / Lists
    if ($Raw -match '^\[(.*)\]$') {
        $inner = $Matches[1].Trim()
        if ([string]::IsNullOrWhiteSpace($inner)) {
            $elemType = $ParamType -replace '\[\]', '' -replace 'IList<', '' -replace 'List<', '' -replace '>', ''
            if ([string]::IsNullOrWhiteSpace($elemType)) { $elemType = "int" }
            return "Array.Empty<$elemType>()"
        }

        # 2D array
        if ($inner.StartsWith("[")) {
            $subArrays = [regex]::Matches($inner, '\[(.*?)\]') | ForEach-Object { "new[] { $($_.Groups[1].Value) }" }
            return "new[] { $($subArrays -join ', ') }"
        }
        else {
            return "new[] { $inner }"
        }
    }

    # Strings
    if ($ParamType -eq "string" -and -not $Raw.StartsWith('"')) {
        return "`"$Raw`""
    }

    return $Raw
}

$PascalTitle = ConvertTo-PascalCase -Text $Question.title
$CleanName = "P$($Question.questionFrontendId)_$PascalTitle"
$KebabSlug = $Slug
$Difficulty = $Question.difficulty
$TopicTags = ($Question.topicTags | ForEach-Object { $_.name }) -join ', '
if (-not $TopicTags) { $TopicTags = "None" }

Write-Host "Resolved: $CleanName ($Difficulty) [Tags: $TopicTags]" -ForegroundColor Green

# ------------------------------------------------------------------
# 4. Extract C# method signature, method name, return type & params
# ------------------------------------------------------------------
$CSharpSnippet = $Question.codeSnippets | Where-Object { $_.langSlug -eq 'csharp' } | Select-Object -First 1

$MethodSignature = $null
$MethodName = "TwoSum"
$ReturnType = "void"
$Params = @()

if ($CSharpSnippet) {
    $Lines = $CSharpSnippet.code -split "`n"
    $Inner = ($Lines | Select-Object -Skip 1 | Select-Object -SkipLast 1) -join "`n"
    $MethodSignature = $Inner.TrimEnd()

    if ($MethodSignature -match 'public\s+([\w<>\[\]\?]+)\s+(\w+)\s*\((.*?)\)') {
        $ReturnType = $Matches[1]
        $MethodName = $Matches[2]
        $paramString = $Matches[3]
        if (-not [string]::IsNullOrWhiteSpace($paramString)) {
            foreach ($p in ($paramString -split ',')) {
                $parts = $p.Trim() -split '\s+'
                if ($parts.Length -ge 2) {
                    $Params += [PSCustomObject]@{ Type = $parts[0]; Name = $parts[1] }
                }
            }
        }
    }
}

# ------------------------------------------------------------------
# 5. Extract example test cases from HTML description
# ------------------------------------------------------------------
$GeneratedTestCode = $null

if ($Question.content -and $Params.Count -gt 0) {
    $Regex = '(?s)<strong>Input:</strong>\s*(.*?)\s*<strong>Output:</strong>\s*(.*?)(?=\s*<strong>Explanation:</strong>|\s*</pre>|\s*<strong|\s*&nbsp;|\r?\n\r?\n|$)'
    $MatchesFound = [regex]::Matches($Question.content, $Regex)

    if ($MatchesFound.Count -gt 0) {
        $InlineDataList = @()
        $HasComplexTypes = ($ReturnType -match 'ListNode|TreeNode') -or ($Params | Where-Object { $_.Type -match 'ListNode|TreeNode' })

        if (-not $HasComplexTypes) {
            foreach ($m in $MatchesFound) {
                $rawInput = $m.Groups[1].Value -replace '&quot;', '"' -replace '&lt;', '<' -replace '&gt;', '>' -replace '<.*?>', '' -replace '\s+', ' '
                $rawOutput = $m.Groups[2].Value -replace '&quot;', '"' -replace '&lt;', '<' -replace '&gt;', '>' -replace '<.*?>', '' -replace '\s+', ' '

                $argValues = @()
                foreach ($p in $Params) {
                    $pName = [regex]::Escape($p.Name)
                    if ($rawInput -match "$pName\s*=\s*(\[\[.*?\]\]|\[.*?\]|`".*?`"|\S+)") {
                        $valStr = $Matches[1].TrimEnd(',')
                        $argValues += Format-CSharpValue -RawValue $valStr -ParamType $p.Type
                    }
                }

                $formattedOutput = Format-CSharpValue -RawValue $rawOutput -ParamType $ReturnType

                if ($argValues.Count -eq $Params.Count) {
                    $allArgs = ($argValues + $formattedOutput) -join ', '
                    $InlineDataList += $allArgs
                }
            }

            if ($InlineDataList.Count -gt 0) {
                $paramDecls = @()
                $theoryGenerics = @()
                foreach ($p in $Params) {
                    $paramDecls += "$($p.Type) $($p.Name)"
                    $theoryGenerics += $p.Type
                }
                $expType = $ReturnType
                if ($ReturnType.StartsWith("IList<")) {
                    $expType = ($ReturnType -replace 'IList<', '' -replace '>', '') + "[]"
                }
                $paramDecls += "$expType expected"
                $theoryGenerics += $expType
                $paramDeclStr = $paramDecls -join ', '
                $theoryGenericStr = $theoryGenerics -join ', '
                $argNameStr = ($Params.Name) -join ', '

                $IsArrayOrList = ($expType -match '\[\]') -or ($ReturnType -match 'IList|List')
                if ($IsArrayOrList) {
                    $OutputWriteLines = @"
        output.WriteLine($"Expected Output: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");
"@
                } else {
                    $OutputWriteLines = @"
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
"@
                }

                $Has2DArray = ($ReturnType -match '\[\]\[\]|\[,\]|IList<IList|List<List') -or ($Params | Where-Object { $_.Type -match '\[\]\[\]|\[,\]|IList<IList|List<List' })

                if ($Has2DArray) {
                    $MemberDataRows = ($InlineDataList | ForEach-Object { "        { $_ }," }) -join "`n"
                    $GeneratedTestCode = @"
    public static TheoryData<$theoryGenericStr> TestCases => new()
    {
$MemberDataRows
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ${MethodName}_ReturnsExpectedResult($paramDeclStr)
    {
        var actual = _sut.${MethodName}($argNameStr);
$OutputWriteLines
        Assert.Equal(expected, actual);
    }
"@
                }
                else {
                    $InlineStr = ($InlineDataList | ForEach-Object { "    [InlineData($_)]" }) -join "`n"
                    $GeneratedTestCode = @"
    [Theory]
$InlineStr
    public void ${MethodName}_ReturnsExpectedResult($paramDeclStr)
    {
        var actual = _sut.${MethodName}($argNameStr);
$OutputWriteLines
        Assert.Equal(expected, actual);
    }
"@
                }
            }
        }
    }
}

# ------------------------------------------------------------------
# 6. Resolve paths
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
# 7. Load templates and perform replacements
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

if ($GeneratedTestCode) {
    $TestContent = @"
using LeetCodeTestbench.Solutions.$CleanName;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.$CleanName;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

$GeneratedTestCode
}
"@
}
elseif (Test-Path $TestTemplatePath) {
    $TestContent = Get-Content -Path $TestTemplatePath -Raw
    $TestContent = $TestContent -replace 'PXXXX_ProblemName', $CleanName
    $TestContent = $TestContent -replace 'TwoSum', $MethodName
}
else {
    $TestContent = @"
using LeetCodeTestbench.Solutions.$CleanName;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.$CleanName;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int target, int[] expected)
    {
        // Act
        // var actual = _sut.TwoSum(nums, target);
        // output.WriteLine($"Expected Output: [{string.Join(", ", expected)}]");
        // output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");

        // Assert
        // Assert.Equal(expected, actual);
    }
}
"@
}

$SolutionContent = $SolutionContent -replace 'PXXXX_ProblemName', $CleanName
$SolutionContent = $SolutionContent -replace 'problem-name', $KebabSlug

$UrlComment = "// https://leetcode.com/problems/$KebabSlug/"
$TaggedHeader = "$UrlComment`n// Difficulty: $Difficulty`n// Tags: $TopicTags"
$SolutionContent = $SolutionContent -replace [regex]::Escape($UrlComment), $TaggedHeader

$ProblemFrontendId = [int]$Question.questionFrontendId
$EscapedTitle = $Question.title -replace '"', '\"'
$EnumTopicsList = ($Question.topicTags | ForEach-Object { ConvertTo-TopicEnum $_.name }) -join ', '
if (-not $EnumTopicsList) { $EnumTopicsList = "Topic.Other" }
$ProblemAttributeLine = "[Problem($ProblemFrontendId, `"$EscapedTitle`", Difficulty.$Difficulty, $EnumTopicsList)]"
$SolutionContent = $SolutionContent -replace '\[Problem\(0, "Problem Name", Difficulty\.Easy, Topic\.Other\)\]', $ProblemAttributeLine

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

# Auto-update Table of Contents
$UpdateTocScript = Join-Path $ScriptDir "Update-TableOfContents.ps1"
if (Test-Path $UpdateTocScript) {
    & $UpdateTocScript
}
