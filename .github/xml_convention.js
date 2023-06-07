const fs = require('fs');
const marked = require('marked');

// Function to read a Markdown file and format its contents
function readAndFormatMarkdownFile(filePath) {
  // Read the Markdown file
  fs.readFile(__dirname + '\\' + filePath, 'utf8', (err, data) => {
    if (err) {
      console.error(`Error reading file: ${err}`);
    } else {
      // Format the Markdown contents using the 'marked' library
      const formattedText = marked.marked(data);

      // Write the formatted text to the console
      console.log(formattedText);
    }
  });``
}

// Specify the path to the Markdown file
const markdownFilePath = 'xml.md';

// Call the function to read and format the Markdown file
readAndFormatMarkdownFile(markdownFilePath);
