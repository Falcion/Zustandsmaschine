import os

# Function to clear lines starting with a specific string
def clear_lines_with_starting_string(file_path, starting_string):
    with open(file_path, 'r') as file:
        lines = file.readlines()

    with open(file_path, 'w') as file:
        for line in lines:
            if not line.startswith(starting_string):
                file.write(line)

# Function to search for files with a given name in a directory
def search_files_with_name(directory, file_name):
    matches = []
    for root, dirs, files in os.walk(directory):
        for file in files:
            if file.startswith(file_name):
                matches.append(os.path.join(root, file))
    
    return matches

# Get the file name from the user
file_name = input("Enter the name of the file (without extension): ")

# Get the starting string from the user
starting_string = input("Enter the starting string to delete lines: ")

# Search for files with the given name in the project directory
project_directory = os.path.abspath(os.path.join(os.path.dirname(__file__), '..'))
matching_files = search_files_with_name(project_directory, file_name)

if len(matching_files) == 0:
    print("No files found with the given name.")
elif len(matching_files) == 1:
    file_path = matching_files[0]
    clear_lines_with_starting_string(file_path, starting_string)
    print(f"File '{file_path}' cleared successfully.")
else:
    print("Multiple files found with the given name. Please choose one:")
    for index, file_path in enumerate(matching_files, start=1):
        print(f"{index}. {file_path}")
    choice = input("Enter the number corresponding to the file you want to clear: ")
    if choice.isdigit() and int(choice) in range(1, len(matching_files) + 1):
        file_path = matching_files[int(choice) - 1]
        clear_lines_with_starting_string(file_path, starting_string)
        print(f"File '{file_path}' cleared successfully.")
    else:
        print("Invalid choice. Exiting the script.")