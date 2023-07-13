import os
import markdown2


def parse_markdown_to_html(folder_path):
    for root, dirs, files in os.walk(folder_path):
        for file_name in files:
            if file_name.endswith(".md"):
                md_file_path = os.path.join(root, file_name)
                html_file_path = os.path.splitext(md_file_path)[0] + ".html"

                with open(md_file_path, "r") as md_file:
                    markdown_content = md_file.read()
                    html_content = markdown2.markdown(markdown_content)

                with open(html_file_path, "w") as html_file:
                    html_file.write(html_content)

                print(f"Converted {md_file_path} to {html_file_path}")


# Specify the folder containing the markdown files
folder_path = "./../docs"

# Call the function to parse Markdown to HTML
parse_markdown_to_html(folder_path)
