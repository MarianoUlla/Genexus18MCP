param(
    [string]$OutputRoot = ""
)

$repoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)

if ([string]::IsNullOrWhiteSpace($OutputRoot)) {
    if ($env:RUNNER_TEMP) {
        $OutputRoot = Join-Path $env:RUNNER_TEMP "gx-coverage-artifacts"
    } else {
        $OutputRoot = Join-Path $repoRoot "artifacts\coverage"
    }
}

Remove-Item -LiteralPath $OutputRoot -Recurse -Force -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Path $OutputRoot -Force | Out-Null

function Invoke-CoverageTest {
    param(
        [Parameter(Mandatory = $true)][string]$ProjectPath,
        [Parameter(Mandatory = $true)][string]$Label,
        [Parameter(Mandatory = $true)][string]$BaseOutputPath,
        [Parameter(Mandatory = $true)][string]$SettingsPath
    )

    $resultsDir = Join-Path $OutputRoot $Label
    New-Item -ItemType Directory -Path $resultsDir -Force | Out-Null

    Write-Host "Running $Label tests with coverage..."
    & dotnet test $ProjectPath -v minimal "-p:BaseOutputPath=$BaseOutputPath" --collect "XPlat Code Coverage" --settings $SettingsPath --results-directory $resultsDir
    if ($LASTEXITCODE -ne 0) {
        throw "$Label tests failed."
    }

    $coverage = Get-ChildItem -Path $resultsDir -Recurse -Filter coverage.cobertura.xml -File |
        Select-Object -First 1

    if (-not $coverage) {
        throw "Coverage report not found for $Label."
    }

    Copy-Item -LiteralPath $coverage.FullName -Destination (Join-Path $OutputRoot "$Label.cobertura.xml") -Force
}

function Get-BaseOutputPath {
    param([Parameter(Mandatory = $true)][string]$Label)

    $baseOutput = Join-Path (Join-Path $repoRoot ".test-bin") $Label
    if (-not $baseOutput.EndsWith([System.IO.Path]::DirectorySeparatorChar)) {
        $baseOutput += [System.IO.Path]::DirectorySeparatorChar
    }
    return $baseOutput
}

Invoke-CoverageTest `
    -ProjectPath (Join-Path $repoRoot "src\GxMcp.Gateway.Tests\GxMcp.Gateway.Tests.csproj") `
    -Label "gateway" `
    -BaseOutputPath (Get-BaseOutputPath -Label "gateway") `
    -SettingsPath (Join-Path $PSScriptRoot "gateway.runsettings")

$workerSdk = "C:\Program Files (x86)\GeneXus\GeneXus18\Artech.Architecture.Common.dll"
if (Test-Path $workerSdk) {
    try {
        Invoke-CoverageTest `
            -ProjectPath (Join-Path $repoRoot "src\GxMcp.Worker.Tests\GxMcp.Worker.Tests.csproj") `
            -Label "worker" `
            -BaseOutputPath (Get-BaseOutputPath -Label "worker") `
            -SettingsPath (Join-Path $PSScriptRoot "worker.runsettings")
    } catch {
        New-Item -ItemType File -Path (Join-Path $OutputRoot "worker.failed.txt") -Force | Out-Null
        Write-Host $_.Exception.Message -ForegroundColor Yellow
    }
} else {
    New-Item -ItemType File -Path (Join-Path $OutputRoot "worker.skipped.txt") -Force | Out-Null
    Write-Host "GeneXus 18 SDK not installed; skipping Worker.Tests."
}

Get-ChildItem -Path $OutputRoot -Recurse | ForEach-Object {
    Write-Host $_.FullName
}
