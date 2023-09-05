$projectPath = "./../../source/Zustand.csproj"
$outputDir = "./../../source/build"
$envFilePath = "./../../.env"
$nugetApiKey = ""

# Check if .env file exists
if (Test-Path $envFilePath) {
    # Read the NuGet API key from the .env file
    $envContents = Get-Content $envFilePath -Raw
    $envVariables = ConvertFrom-StringData $envContents

    if ($envVariables.ContainsKey("NUGET_API_KEY")) {
        $nugetApiKey = $envVariables["NUGET_API_KEY"]
    }
    else {
        Write-Host "Error: The NUGET_API_KEY variable is missing in the .env file."
        exit 1
    }
}
else {
    # Create a new .env file with the required structure
    $envContents = @"
# NuGet API Key
NUGET_API_KEY=
"@
    $envContents | Set-Content $envFilePath -Force

    Write-Host "Error: The .env file doesn't exist. An empty .env file has been created. Please provide the NUGET_API_KEY value."
    exit 1
}

if ($nugetApiKey -eq "") {
    Write-Host "Error: The NUGET_API_KEY value is empty in the .env file."
    exit 1
}

# Clean and build the project as a DLL
dotnet clean $projectPath --configuration Release
dotnet build $projectPath --configuration Release --output $outputDir

# Publish the DLL as a NuGet package
dotnet pack $projectPath --configuration Release --output $outputDir

# Publish the NuGet package
$nugetPackageDir = Join-Path -Path $outputDir -ChildPath "nuget"
dotnet nuget push "$nugetPackageDir/*.nupkg" --source "https://api.nuget.org/v3/index.json" --api-key $nugetApiKey