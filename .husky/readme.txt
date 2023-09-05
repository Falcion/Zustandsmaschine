In some cases, errors via husky's git hooks may occure:

- PROBLEM: 
- "jq command not found":

- SOLUTION:
- Copy and paste into the bash of your repository's root:
- curl -L -o /usr/bin/jq.exe https://github.com/stedolan/jq/releases/latest/download/jq-win64.exe
- SOLUTION FROM: 
- https://stackoverflow.com/questions/65202170/bash-jq-command-not-found-after-adding-jq-execuable-file-to-env-variable-w