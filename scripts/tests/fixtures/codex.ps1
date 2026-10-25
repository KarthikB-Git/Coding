# Offline CLI stand-in. Never calls a model.
$Prompt = $input | Out-String
if ($global:TestBenchFixtureMode -eq 'fail') {
    $global:LASTEXITCODE = 9
    return
}
if ($global:TestBenchFixtureMode -eq 'missing-output') {
    $global:LASTEXITCODE = 0
    return
}
if (($args -join '|') -notmatch '^exec\|--sandbox\|workspace-write\|--cd\|.+\|-$') {
    throw 'Unexpected Codex CLI arguments.'
}
if ($Prompt -notmatch '## Problem statement' -or $Prompt -notmatch 'You may update the named test file') {
    throw 'Prompt did not arrive intact through stdin.'
}
if ($Prompt -notmatch '(?m)^Test file to create/update: (.+)\r?$') { throw 'Missing test path.' }
$TestPath = $Matches[1].Trim()
if ($Prompt -notmatch '(?m)^Judge contract and verification report: (.+)\r?$') { throw 'Missing report path.' }
$ReportPath = $Matches[1].Trim()
Set-Content -LiteralPath $TestPath -Value '// CLI fixture output' -Encoding UTF8
Set-Content -LiteralPath $ReportPath -Value 'Offline CLI fixture; no generated C# was validated.' -Encoding UTF8
$global:LASTEXITCODE = 0
