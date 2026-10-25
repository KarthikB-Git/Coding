# Offline integration checks using an isolated fixture workspace. No AI calls.
$ErrorActionPreference = 'Stop'
$SourceRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
$FixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("testbench-" + [guid]::NewGuid().ToString('N'))
$OriginalPath = $env:PATH

function Assert-True($Condition, [string]$Message) {
    if (-not $Condition) { throw $Message }
}
function Assert-Throws([scriptblock]$Action, [string]$Pattern) {
    $Caught = $false
    try { & $Action | Out-Null }
    catch {
        $Caught = $true
        Assert-True ($_.Exception.Message -match $Pattern) "Unexpected error: $_"
    }
    Assert-True $Caught "Expected error matching: $Pattern"
}

try {
    New-Item -ItemType Directory -Path "$FixtureRoot/scripts", "$FixtureRoot/LeetCodeSandbox/Templates" -Force | Out-Null
    Copy-Item -LiteralPath "$SourceRoot/scripts/New-ProblemTestBench.ps1", "$SourceRoot/scripts/ProblemTestBenchPrompt.md", "$SourceRoot/scripts/New-SolutionFromUrl.ps1" -Destination "$FixtureRoot/scripts"
    Copy-Item -Path "$SourceRoot/LeetCodeSandbox/Templates/*" -Destination "$FixtureRoot/LeetCodeSandbox/Templates"

    # Mock the HTTP boundary, exercising the real URL scaffold without network access.
    $FixtureKind = 'custom'
    function Invoke-RestMethod {
        param($Uri, $Method, $Headers, $Body, $ErrorAction)
        if ($FixtureKind -eq 'void') {
            return @{ data = @{ question = @{
                questionFrontendId = '283'; title = 'Move Zeroes'; difficulty = 'Easy'
                topicTags = @(@{ name = 'Array' })
                codeSnippets = @(@{ langSlug = 'csharp'; code = "public class Solution {`n    public void MoveZeroes(int[] nums) { }`n}" })
                content = '<p>Modify nums in place.</p><pre><strong>Input:</strong> nums = [0,1] <strong>Output:</strong> [1,0]</pre>'
            } } }
        }
        if ($FixtureKind -eq 'ordinary') {
            return @{ data = @{ question = @{
                questionFrontendId = '66'; title = 'Plus One'; difficulty = 'Easy'
                topicTags = @(@{ name = 'Array' })
                codeSnippets = @(@{ langSlug = 'csharp'; code = "public class Solution {`n    public int[] PlusOne(int[] digits) { }`n}" })
                content = '<pre><strong>Input:</strong> digits = [1,2,3] <strong>Output:</strong> [1,2,4]</pre>'
            } } }
        }
        return @{ data = @{ question = @{
            questionFrontendId = '26'
            title = 'Remove Duplicates from Sorted Array'
            difficulty = 'Easy'
            topicTags = @(@{ name = 'Array' })
            codeSnippets = @(@{ langSlug = 'csharp'; code = "public class Solution {`n    public int RemoveDuplicates(int[] nums) { }`n}" })
            content = '<p>Custom Judge:</p><pre>assert k == expected.length; assert nums prefix equals expected;</pre><strong>Input:</strong> nums = [1,1,2] <strong>Output:</strong> 2, nums = [1,2,_]</pre>'
        } } }
    }
    $Name = 'P26_RemoveDuplicatesFromSortedArray'
    $ProblemDir = "$FixtureRoot/LeetCodeSandbox/Solutions/$Name"
    & "$FixtureRoot/scripts/New-SolutionFromUrl.ps1" -Url 'https://leetcode.com/problems/remove-duplicates-from-sorted-array/' | Out-Null
    $TestPath = "$ProblemDir/${Name}Test.cs"
    $TestBefore = Get-Content -LiteralPath $TestPath -Raw
    Assert-True ($TestBefore -match 'Skip =') 'Custom judge must receive an explicitly pending test.'
    Assert-True ($TestBefore -notmatch '2, nums =') 'Compound display output was parsed as a C# expected value.'
    Assert-True (Test-Path -LiteralPath "$ProblemDir/ProblemStatement.html") 'Full statement was not saved.'

    $Prompt = & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name
    Assert-True ($Prompt -match 'assert k == expected.length') 'Full judge statement missing from prompt.'
    Assert-True ($Prompt -match 'deep-clone' -and $Prompt -match 'incorrect mutation') 'Mutation/oracle guidance missing.'
    Assert-True ($Prompt -match 'Do not implement, fix') 'Solution preservation instruction missing.'
    Assert-True ($Prompt -match [regex]::Escape("FullyQualifiedName~.$Name.")) 'Filter must select the exact problem namespace.'
    Assert-True ((Get-Content -LiteralPath $TestPath -Raw) -eq $TestBefore) 'Preview changed existing tests.'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name -RunAgent } 'Test file already exists'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName 'P999_Missing' } 'Solution not found'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name -StatementPath "$FixtureRoot/missing.md" } 'Full problem statement missing'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName '../outside' } 'ValidatePattern|validation|pattern'

    $FixtureKind = 'void'
    & "$FixtureRoot/scripts/New-SolutionFromUrl.ps1" -Url 'move-zeroes' | Out-Null
    Assert-True ((Get-Content "$FixtureRoot/LeetCodeSandbox/Solutions/P283_MoveZeroes/P283_MoveZeroesTest.cs" -Raw) -match 'JudgeContract_Pending') 'Void method needs state assertions, not a return-value test.'
    $FixtureKind = 'ordinary'
    & "$FixtureRoot/scripts/New-SolutionFromUrl.ps1" -Url 'plus-one' | Out-Null
    Assert-True ((Get-Content "$FixtureRoot/LeetCodeSandbox/Solutions/P66_PlusOne/P66_PlusOneTest.cs" -Raw) -match 'Assert.Equal\(expected, actual\)') 'Ordinary scaffold regressed.'

    # CLI fixture verifies stdin transport and creates the required output artifacts.
    Copy-Item -LiteralPath "$PSScriptRoot/fixtures/codex.ps1" -Destination "$FixtureRoot/codex.ps1"
    $env:PATH = "$FixtureRoot$([IO.Path]::PathSeparator)$OriginalPath"
    $SolutionBefore = Get-Content -LiteralPath "$ProblemDir/$Name.cs" -Raw
    $global:TestBenchFixtureMode = 'fail'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name -RunAgent -ReplaceExistingTests } 'exit code 9'
    $global:TestBenchFixtureMode = 'missing-output'
    Assert-Throws { & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name -RunAgent -ReplaceExistingTests } 'Generation is incomplete'
    $global:TestBenchFixtureMode = 'success'
    & "$FixtureRoot/scripts/New-ProblemTestBench.ps1" -ProblemName $Name -RunAgent -ReplaceExistingTests
    Assert-True ((Get-Content -LiteralPath "$ProblemDir/TestBench.md" -Raw) -match 'fixture') 'CLI fixture did not run.'
    Assert-True ((Get-Content -LiteralPath "$ProblemDir/$Name.cs" -Raw) -eq $SolutionBefore) 'Solution changed during invocation.'
    Write-Host 'PASS: scaffold, statement capture, judge prompt, preview, overwrite protection, validation, CLI stdin and output checks.'
}
finally {
    $env:PATH = $OriginalPath
    Remove-Variable -Name TestBenchFixtureMode -Scope Global -ErrorAction SilentlyContinue
    # Only remove the exact GUID-named fixture folder created above.
    $ResolvedFixture = [IO.Path]::GetFullPath($FixtureRoot)
    $TempRoot = [IO.Path]::GetFullPath([IO.Path]::GetTempPath())
    if ($ResolvedFixture.StartsWith($TempRoot, [StringComparison]::OrdinalIgnoreCase) -and
        (Split-Path -Leaf $ResolvedFixture) -match '^testbench-[a-f0-9]{32}$') {
        if (Test-Path -LiteralPath $ResolvedFixture) { Remove-Item -LiteralPath $ResolvedFixture -Recurse -Force }
    }
}
