import os
import re

def remove_html_content(file_path):
    with open(file_path, 'r') as file:
        content = file.read()

    # Remove HTML tags and content
    cleaned_content = re.sub('<[^<]+?>', '', content)

    with open(file_path, 'w') as file:
        file.write(cleaned_content)

# Specify the paths of the Markdown files you want to clean up
markdown_files = ['README.md', 'LICENSE.md', 'SECURITY.md']

# Prompt to verify the list of files to import
print("The following Markdown files will be cleaned up:")
for file_path in markdown_files:
    print(file_path)

# Ask if additional files should be imported
choice = input("Do you want to import additional files from the root directory? (y/n): ")

if choice.lower() == 'y':
    # Ask for the file names to import
    file_names = input("Enter the file names (comma-separated) you want to import: ")
    additional_files = [file.strip() for file in file_names.split(',')]

    # Add additional files to the list
    markdown_files.extend(additional_files)

# Clean up each Markdown file
for file_path in markdown_files:
    remove_html_content(file_path)
