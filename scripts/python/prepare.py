import os
import shutil

from bs4 import BeautifulSoup


# Function to remove HTML elements from a file
def remove_html_elements(file_path):
    with open(file_path, 'r') as file:
        soup = BeautifulSoup(file, 'html.parser')
        text = soup.get_text()

    with open(file_path, 'w') as file:
        file.write(text)


# Cloning README.md, LICENSE.md, and CHANGELOG.md to the "source" folder
file_names = ['README.md', 'LICENSE.md', 'CHANGELOG.md']
source_folder = 'source'

for file_name in file_names:
    shutil.copy(file_name, source_folder)
    remove_html_elements(os.path.join(source_folder, file_name))

# Asking if user wants to clone additional files
while True:
    choice = input("Do you want to clone additional files? (y/n): ")
    if choice.lower() == 'y':
        file_name = input("Enter the name of the file to clone: ")
        shutil.copy(file_name, source_folder)
        remove_html_elements(os.path.join(source_folder, file_name))
    elif choice.lower() == 'n':
        break
    else:
        print("Invalid choice. Please enter 'y' or 'n'.")

print("Files cloned and processed successfully!")