import os
import json

# Get the version from manifest.json if it exists, otherwise get it from package.json
if os.path.exists("../manifest.json"):
    with open("../manifest.json", "r") as manifest_file:
        manifest_data = json.load(manifest_file)
        version = manifest_data.get("version")
else:
    with open("../package.json", "r") as package_file:
        package_data = json.load(package_file)
        version = package_data.get("version")

# Ask user for the variable name
variable_name = input("Enter the variable name: ")

# Write the version to the {VARIABLE}.csproj file
with open(f"{variable_name}.csproj", "w") as csproj_file:
    csproj_file.write(f'<PackageVersion>{version}</PackageVersion>\n')

print(f"Version {version} has been written to {variable_name}.csproj as PackageVersion.")
