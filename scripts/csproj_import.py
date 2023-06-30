import json
import os

package_json_path = os.path.join("..", "package.json")  # Path to your package.json file
csproj_path = os.path.join("..", "source", "Zustand.csproj")  # Path to the generated .csproj file

with open(package_json_path, "r") as file:
    package_json = json.load(file)

target_framework = "net8.0"  # Set your desired target framework here

package_name = package_json["name"]
package_version = package_json["version"]
package_description = package_json["description"]
package_authors = package_json["author"]
package_tags = ",".join(package_json["keywords"])

csproj_content = f"""<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>{target_framework}</TargetFramework>
    <OutputType>Library</OutputType>
    <AssemblyName>{package_name}</AssemblyName>
    <RootNamespace>{package_name}</RootNamespace>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <Authors>{package_authors}</Authors>
    <Description>{package_description}</Description>
    <PackageId>{package_name}</PackageId>
    <Version>{package_version}</Version>
    <PackageTags>{package_tags}</PackageTags>
    <!-- Add other necessary properties here -->
  </PropertyGroup>

  <!-- Add other necessary item groups here -->
</Project>"""

with open(csproj_path, "w") as file:
    file.write(csproj_content)

print("Successfully generated the .csproj file.")
