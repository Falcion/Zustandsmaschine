# Conventional Commits Specification

The Conventional Commits specification is a lightweight convention on top of commit messages. It provides an easy set of rules for creating an explicit commit history, making it easier to write automated tools on top of it. This convention dovetails with [Semantic Versioning](https://semver.org/) by describing the features, fixes, and breaking changes made in commit messages.

- Created with: [conventionalcommits.org](https://www.conventionalcommits.org/en/v1.0.0/)

## Commit Message Format

Each commit message consists of a header, a body, and an optional footer:

```plaintext
<header>

<body>

<footer>
```

### Commit Message Header

The header of a commit message is the first thing other contributors see about a commit. It has a specific format:

```
<TYPE>(<SCOPE>): <SUMMARY>
```

- `<TYPE>`: Defines the category of the commit. It can be one of the following:

  - **build**: Changes that affect the build system or external dependencies.
  - **ci**: Changes to CI and workflows configurations files and scripts.
  - **docs**: Changes only related to documentation.
  - **feat**: New feature in a future release.
  - **perf**: Code changes focused on performance improvements.
  - **refactor**: Code changes that neither fix a bug nor add a feature.
  - **ref**: Referencing something entirely new based on old changes.
  - **fix**: Code changes that fix bugs, crashes, or misimprovements.

- `<SCOPE>`: Specifies the package or code block affected by the commit. It helps in categorizing the changes. Use an empty string for tests or refactor changes that are done across all packages.

- `<SUMMARY>`: Provides a succinct description of the change. Use the imperative, present tense and avoid capitalizing the first letter or adding a period at the end.

### Commit Message Body

The body of a commit message explains the motivation behind the change. It is mandatory for every commit except for documentation commits. Here are some guidelines for the commit message body:

- It can start with a capitalized letter.
- You can include a period at the end.
- Use imperative and custom grammatics to describe the change.
- Comparison of the previous behavior with the new behavior can be included to illustrate the impact of the change.

### Commit Message Footer

The footer of a commit message can contain information about breaking changes, deprecations, and references to issues, PRs, or other related items. Here are some guidelines for the commit message footer:

- It can start with a capitalized letter.
- You can include a period at the end.
- Use imperative and custom grammatics.
- The breaking change section should start with "BREAKING CHANGE: " followed by a short description. Leave a blank line and provide a detailed description of the deprecation, mentioning the recommended update path.

### Reverting Commits

If a commit reverts a previous commit, it should begin with the "REVERT: " keyword followed by the header of the reverted commit. The commit message body should contain:

- Information about the SHA of the commit being reverted in the following format:

  ```plaintext
  Change reverts commit [SHA]
  ```

- A clear description of the reason for reverting the commit.

## Signing the CLA

Sometimes, you may be asked to sign the CLA (Contributor License Agreement) before sending a PR. To have your code changes accepted, the CLA must be signed. The process is quick and easy.



- For individuals, you can sign the CLA [here](https://cla.developers.google.com/about/google-individual).
- For corporations, you can print, sign, and scan the provided form and send it via email or mail. The form can be found [here](https://cla.developers.google.com/about/google-corporate).

If you have multiple accounts or multiple email addresses associated with a single account, you must sign the CLA using the primary email address of the GitHub account used to author git commits and send PRs.

For any issues related to accounts and multiple email addresses, the following documents can provide assistance:

- [Setting your commit email address in Git](https://help.github.com/articles/setting-your-commit-email-address-in-git/)
- [About commit email addresses](https://help.github.com/articles/about-commit-email-addresses/)
- [Blocking command line pushes that expose your personal email address](https://help.github.com/articles/blocking-command-line-pushes-that-expose-your-personal-email-address/)