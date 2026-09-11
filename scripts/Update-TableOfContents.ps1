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

$Solutions = @()

Get-ChildItem -Path $SolutionsDir -Filter "*.cs" | Where-Object { $_.Name -notlike "*Test.cs" } | ForEach-Object {
    $content = Get-Content -Path $_.FullName -Raw
    $fileName = $_.Name
    $relPath = "Solutions/$fileName"

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
        $rawTopics = $Matches[4]

        if ($rawTopics) {
            $topicMatches = [regex]::Matches($rawTopics, 'Topic\.(\w+)')
            foreach ($tm in $topicMatches) {
                $tName = $tm.Groups[1].Value
                $tDisplay = [regex]::Replace($tName, '([a-z0-9])([A-Z])', '$1 $2')
                $topics += $tDisplay
            }
        }
    }
    else {
        if ($fileName -match '^P(\d+)_') {
            $id = [int]$Matches[1]
        }
        $titlePart = $fileName -replace '^P\d+_', '' -replace '\.cs$', ''
        $title = [regex]::Replace($titlePart, '([a-z0-9])([A-Z])', '$1 $2')
    }

    $Solutions += [PSCustomObject]@{
        Id         = $id
        Title      = $title
        Difficulty = $difficulty
        Topics     = ($topics -join ', ')
        Url        = $url
        FilePath   = $relPath
        FileName   = $fileName
    }
}

$SortedSolutions = $Solutions | Sort-Object Id

$EasyCount = ($SortedSolutions | Where-Object { $_.Difficulty -eq 'Easy' }).Count
$MediumCount = ($SortedSolutions | Where-Object { $_.Difficulty -eq 'Medium' }).Count
$HardCount = ($SortedSolutions | Where-Object { $_.Difficulty -eq 'Hard' }).Count
$TotalCount = $SortedSolutions.Count

$MdLines = @(
    "# LeetCode Solutions Table of Contents",
    "",
    "> Auto-generated index of solved LeetCode problems.",
    "",
    "### Progress Summary",
    "- **Total Solved**: $TotalCount",
    "- **Easy**: $EasyCount",
    "- **Medium**: $MediumCount",
    "- **Hard**: $HardCount",
    "",
    "---",
    "",
    "| # | Problem Title | Difficulty | Topic Tags | Solution File |",
    "| :---: | :--- | :---: | :--- | :---: |"
)

foreach ($sol in $SortedSolutions) {
    $diffBadge = switch ($sol.Difficulty) {
        "Easy"   { "Easy" }
        "Medium" { "Medium" }
        "Hard"   { "Hard" }
        default  { $sol.Difficulty }
    }

    $titleCell = if ($sol.Url) { "[{0}]({1})" -f $sol.Title, $sol.Url } else { $sol.Title }
    $fileCell = "[{0}]({1})" -f $sol.FileName, $sol.FilePath
    $topicsCell = if ($sol.Topics) { $sol.Topics } else { "-" }

    $MdLines += "| $($sol.Id) | $titleCell | $diffBadge | $topicsCell | $fileCell |"
}

$MdLines | Set-Content -Path $TocPath -Encoding UTF8
Write-Host "Successfully generated Table of Contents at $TocPath ($TotalCount problems indexed)." -ForegroundColor Green
