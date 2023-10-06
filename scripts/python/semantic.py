import subprocess
import xml.etree.ElementTree as ET

def get_latest_tag_version():
    try:
        tag = subprocess.check_output(['git', 'describe', '--tags', '--abbrev=0']).decode().strip()
        version = tag.replace('v', '')
        return version
    except subprocess.CalledProcessError as e:
        print(f'Failed to get the latest tag: {e.output.decode()}')
        exit(1)

def get_package_version_from_csproj():
    try:
        csproj_path = '../../source/Zustand.csproj'
        tree = ET.parse(csproj_path)
        root = tree.getroot()
        property_group = root.find('./PropertyGroup')
        package_version = property_group.findtext('Version')
        return package_version
    except Exception as e:
        print(f'Failed to read the .csproj file: {str(e)}')
        exit(1)

def check_versions():
    tag_version = get_latest_tag_version()
    package_version = get_package_version_from_csproj()

    if tag_version != package_version:
        print(f'The .csproj version ({package_version}) is not synchronized with the latest tag version ({tag_version}).')
        exit(1)

    print('Version check passed successfully.')

check_versions()