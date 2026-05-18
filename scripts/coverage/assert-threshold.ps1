param(
    [string]$CoverageRoot = "",
    [double]$MinLineRatePercent = 50
)

$repoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
if ([string]::IsNullOrWhiteSpace($CoverageRoot)) {
    if ($env:RUNNER_TEMP) {
        $CoverageRoot = Join-Path $env:RUNNER_TEMP "gx-coverage-artifacts"
    } else {
        $CoverageRoot = Join-Path $repoRoot "artifacts\coverage"
    }
}

function Get-LineRatePercent {
    param([Parameter(Mandatory = $true)][string]$Path)
    if (-not (Test-Path -LiteralPath $Path)) {
        throw "Coverage file not found: $Path"
    }

    [xml]$doc = Get-Content -LiteralPath $Path
    return [math]::Round(([double]$doc.coverage.'line-rate') * 100, 2)
}

$gatewayPath = Join-Path $CoverageRoot "gateway.cobertura.xml"
$workerPath = Join-Path $CoverageRoot "worker.cobertura.xml"

$gatewayRate = Get-LineRatePercent -Path $gatewayPath
$workerRate = Get-LineRatePercent -Path $workerPath

Write-Host "Gateway line-rate: $gatewayRate%"
Write-Host "Worker line-rate: $workerRate%"
Write-Host "Required minimum: $MinLineRatePercent%"

$failed = @()
if ($gatewayRate -lt $MinLineRatePercent) { $failed += "gateway=$gatewayRate%" }
if ($workerRate -lt $MinLineRatePercent) { $failed += "worker=$workerRate%" }

if ($failed.Count -gt 0) {
    throw "Coverage threshold failed: $($failed -join ', ')"
}

Write-Host "Coverage threshold satisfied."
