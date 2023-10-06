$projectPath = "./../../source/Zustand.csproj"
$outputDir = "./../../source/build"

# Clean and build the project as a DLL
dotnet clean $projectPath --configuration Release
dotnet build $projectPath --configuration Release --output $outputDir

# Publish the DLL as a NuGet package
dotnet pack $projectPath --configuration Release --output $outputDir