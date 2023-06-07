const fs = require('fs');
const path = require('path');

// Define the files to be cloned
const filesToClone = ['LICENSE.md', 'README.md', 'SECURITY.md'];

// Specify the subfolder to clone the files to
const subfolder = 'source';

// Get the current directory where the script is located
const currentDirectory = __dirname;

// Create the target subfolder if it doesn't exist
const targetDirectory = path.join(currentDirectory, subfolder);
if (!fs.existsSync(targetDirectory)) {
  fs.mkdirSync(targetDirectory);
}

// Clone each file to the target subfolder
filesToClone.forEach(file => {
  const sourceFilePath = path.join(currentDirectory, file);
  const targetFilePath = path.join(targetDirectory, file);

  fs.copyFile(sourceFilePath, targetFilePath, err => {
    if (err) {
      console.error(`Failed to clone ${file}: ${err}`);
    } else {
      console.log(`Successfully cloned ${file}`);
    }
  });
});

const FOLDER_MAX_SIZE = 40 * 1024 * 1024; // 40MB in bytes

const sourceDirectory = path.join(__dirname, 'source');

// Function to calculate the size of a directory recursively
function getDirectorySize(directory) {
  let totalSize = 0;

  const files = fs.readdirSync(directory);

  files.forEach(file => {
    const filePath = path.join(directory, file);
    const stats = fs.statSync(filePath);

    if (stats.isFile()) {
      totalSize += stats.size;
    } else if (stats.isDirectory()) {
      totalSize += getDirectorySize(filePath);
    }
  });

  return totalSize;
}

// Function to clear the "obj" and "bin" folders if their size exceeds the threshold
function clearFoldersIfExceedMaxSize() {
  const objDirectory = path.join(sourceDirectory, 'obj');
  const binDirectory = path.join(sourceDirectory, 'bin');

  const objSize = getDirectorySize(objDirectory);
  const binSize = getDirectorySize(binDirectory);

  const totalSize = objSize + binSize;

  if (totalSize > FOLDER_MAX_SIZE) {
    deleteFolderRecursive(objDirectory);
    deleteFolderRecursive(binDirectory);
    console.log('Folders "obj" and "bin" cleared successfully.');
  } else {
    console.log('Total size of "obj" and "bin" folders is within the limit.');
  }
}

// Function to delete a folder and its contents recursively
function deleteFolderRecursive(directory) {
  if (fs.existsSync(directory)) {
    fs.readdirSync(directory).forEach(file => {
      const filePath = path.join(directory, file);

      if (fs.lstatSync(filePath).isDirectory()) {
        deleteFolderRecursive(filePath);
      } else {
        fs.unlinkSync(filePath);
      }
    });

    fs.rmdirSync(directory);
  }
}

// Call the function to clear folders if needed
clearFoldersIfExceedMaxSize();
