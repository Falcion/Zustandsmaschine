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


FILE_NAMES = ['README.md', 'LICENSE.md', 'CHANGELOG.md']
ROOT_FOLDER = './../'

for file_name in FILE_NAMES:
    shutil.copy(ROOT_FOLDER + file_name, './')
    remove_html_elements(os.path.join('./', file_name))

# Asking if user wants to clone additional files
while True:
    choice = input("Do you want to clone additional files? (y/n): ")
    if choice.lower() == 'y':
        file_name = input("Enter the name of the file to clone: ")
        shutil.copy(ROOT_FOLDER + file_name, './')
        remove_html_elements(os.path.join('./', file_name))
    elif choice.lower() == 'n':
        break
    else:
        print("Invalid choice. Please enter 'y' or 'n'.")

print("Files cloned and processed successfully!")
