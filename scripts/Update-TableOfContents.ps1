[CmdletBinding()]
param()

$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$WorkspaceRoot = Split-Path -Parent $ScriptDir
$SandboxDir = Join-Path $WorkspaceRoot "LeetCodeSandbox"
$SolutionsDir = Join-Path $SandboxDir "Solutions"
$TocPath = Join-Path $SandboxDir "TableOfContents.md"

if (-not (Test-Path $SolutionsDir)) {
    Write-Error "Solutions directory not found at $SolutionsDir"
    exit 1
}

function ConvertTo-RepoPath {
    param([string]$Path)
    $fullSandboxPath = [System.IO.Path]::GetFullPath($SandboxDir).TrimEnd([char[]]@('\', '/'))
    $fullPath = [System.IO.Path]::GetFullPath($Path)

    if (-not $fullPath.StartsWith($fullSandboxPath, [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Path' is outside the LeetCode sandbox."
    }

    $fullPath.Substring($fullSandboxPath.Length).TrimStart([char[]]@('\', '/')) -replace '\\', '/'
}

$Solutions = foreach ($file in Get-ChildItem -Path $SolutionsDir -Recurse -File -Filter "*.cs" | Where-Object { $_.Name -notlike "*Test.cs" }) {
    $content = Get-Content -Path $file.FullName -Raw
    $id = 0
    $title = ""
    $difficulty = "Unknown"
    $topics = @()
    $url = ""

    if ($content -match '//\s*(https://leetcode\.com/problems/[^/\s]+/)') {
        $url = $Matches[1].Trim()
    }

    if ($content -match '\[Problem\(\s*(\d+)\s*,\s*"([^"]+)"\s*,\s*Difficulty\.(\w+)(.*?)\)\]') {
        $id = [int]$Matches[1]
        $title = $Matches[2]
        $difficulty = $Matches[3]
        foreach ($topicMatch in [regex]::Matches($Matches[4], 'Topic\.(\w+)')) {
            $topics += [regex]::Replace($topicMatch.Groups[1].Value, '([a-z0-9])([A-Z])', '$1 $2')
        }
    }
    else {
        if ($file.BaseName -match '^P(\d+)_') { $id = [int]$Matches[1] }
        $titlePart = $file.BaseName -replace '^P\d+_', ''
        $title = [regex]::Replace($titlePart, '([a-z0-9])([A-Z])', '$1 $2')
    }

    $readmePath = Join-Path $file.DirectoryName "README.md"
    [PSCustomObject]@{
        Id = $id; Title = $title; Difficulty = $difficulty; Topics = ($topics -join ', '); Url = $url
        FilePath = ConvertTo-RepoPath $file.FullName; FileName = $file.Name
        ExplanationPath = if (Test-Path $readmePath) { ConvertTo-RepoPath $readmePath } else { $null }
    }
}

$SortedSolutions = @($Solutions | Sort-Object Id, FilePath)
$EasyCount = @($SortedSolutions | Where-Object Difficulty -eq 'Easy').Count
$MediumCount = @($SortedSolutions | Where-Object Difficulty -eq 'Medium').Count
$HardCount = @($SortedSolutions | Where-Object Difficulty -eq 'Hard').Count

$MdLines = @(
    "# LeetCode Solutions Table of Contents", "", "> Auto-generated index of solved LeetCode problems.", "",
    "### Progress Summary", "- **Total Solved**: $($SortedSolutions.Count)", "- **Easy**: $EasyCount", "- **Medium**: $MediumCount", "- **Hard**: $HardCount", "", "---", "",
    "| # | Problem Title | Difficulty | Topic Tags | Solution File | Explanation |",
    "| :---: | :--- | :---: | :--- | :---: | :---: |"
)

foreach ($solution in $SortedSolutions) {
    $titleCell = if ($solution.Url) { "[{0}]({1})" -f $solution.Title, $solution.Url } else { $solution.Title }
    $fileCell = "[{0}]({1})" -f $solution.FileName, $solution.FilePath
    $explanationCell = if ($solution.ExplanationPath) { "[README]({0})" -f $solution.ExplanationPath } else { "-" }
    $topicsCell = if ($solution.Topics) { $solution.Topics } else { "-" }
    $MdLines += "| $($solution.Id) | $titleCell | $($solution.Difficulty) | $topicsCell | $fileCell | $explanationCell |"
}

$MdLines | Set-Content -Path $TocPath -Encoding UTF8
Write-Host "Successfully generated Table of Contents at $TocPath ($($SortedSolutions.Count) problems indexed)." -ForegroundColor Green
