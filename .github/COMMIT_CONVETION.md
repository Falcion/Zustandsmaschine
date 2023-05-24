Conventional commits specification is a lightweight convention on top of commit messages, it provides an easy set of rules for creating an explicit commit history; which makes it easier to write automated tools on top of - this convention dovetails with , by describing the features, fixes, and breaking changes made in commit messages.

- created with: https://www.conventionalcommits.org/en/v1.0.0/

Comitting convention
---------------------

For consistency throughout the source code, keep these rules in mind as you are working with project's open source:

- all features or bug fixes must be tested;
- all public API methods must be documented;

Each commit message consists of a header, a body, and a footer:

```html
<header>
BLANK_LINE
<body>
BLANK_LINE
<footer>
```

And there is some advanced explanation for each param in commit's message structure:

- param `<HEADER>` is mandatory and must conform to commit message header formatting (specified below);
- param `<BODY>` is mandatory for every commit except for commits of documentation purpose: when the body is present it must conform to the commit message body formatting;
- param `<FOOTER>` is optional, the same as others must conform specified formatting;

#### Commit message - header

Header is just an HTML header of a commit, not its description or something else, this is what other contributors first see about a commit.

Construction of header of commit's message is a joint of multiple params which defines entire commit preposition:

```html
Final structure of HEADER param:
<TYPE>(<SCOPE>): <SUMMARY>
```

- param `<TYPE>` is defined by a range of categories, there is a list of them:\
  - **`build`** - changes that affect the build system or external dependencies (for example GULP or NPM);
  - **`ci`** - changes to CI and workflows configurations files and scripts;
  - **`docs`** - changes only about documentation (including repository files like README);
  - **`feat`** - new feature in future release;
  - **`perf`** - code changes improving and working with perfomace preferences;
  - **`refactor`** - code change neither fixes something nor adds a feature;
  - **`ref`** - referencing something entirely new based on old changes (in case of full rework of a repository);
  - **`fix`** - code changes defining fix of a bugs, crashes and some misimprovements (fast-deploy cases);

- param `<SCOPE>` should be a name of the package affected or a code block (as perceived by the person reading changelog generated from the commit messages) - names below are given for an example:
    > None or empty strings which useful for a test or a refactor changes that are done across all packages;
    - **`calculus`** - code changes which are working with math and calculus tasks;
    - **`requests`** - referencing with requests either to database or server and etc.;
    - **`logs`** - changes about logging and other debugging methods;

- param `<SUMMARY>` is a field used for the providing a succint description of the change:
  - use the imperative, present tense just like in default committing convetions of git;
  - don't capitalize first letter just like in the button list;
  - don't enter dot at the end of summary.

#### Commit message - body

Body of a commit message doesn't have any unique syntax, like in default summary - explain the motivation for the change in the commit message body, this commit message should explain why you are making the change.

- you CAN start with capitalized letter, this is a description;
- you can enter dot at the end of summary;
- you can use imperative and custom grammatics;

You can include comparison of the previous behaviour with new behaviour in order to illustrate the impact of the change.

#### Commit message - footer

Footer, as the part of a body's message, can contain information about breaking changes and deprecations and is also the place to reference issues, PRs, tickets from other issue tracking products (like Jira) and everything other that this commit closes or is related to.

- you CAN start with capitalized letter, this is a description;
- you can enter dot at the end of summary;
- you can use imperative and custom grammatics;

Breaking change section should start with the phrase of "BREAKING CHANGE: " followed by a short description of what is deprecated, a blank line and a detailed description of the deprecation that also metions the recommended update path.

#### Reverting commits

If this commit reverts a previous commit, it should begin with "REVERT: " keyword followed by the header of the reverted commit.

Content of the commit message body should contain:

- information about the SHA of the commit being reverted in the following format:

    ```powershell
    Change reverts commit [SHA]
    ```
- a clear description of the reason for reverting the commit message;

Signing the CLA
---------------

Sometimes you can be asked to sign the CLA (or contributor license agreement) before sending the PR: for any code changes to be accepted, the CLA must be signed - its a quick and easy process.

- for individuals:\
    https://cla.developers.google.com/about/google-individual
- for corporations, print, sign and scan with email, fam or mail the given form:\
  https://cla.developers.google.com/about/google-corporate

If you have more than one accounts, or multiple email addresses associated with a single account, you must sign the CLA using the primary email address of the GITHUB account used to author git commits and sending PRs.

Following documents can help with sorting out issues with accounts and multiple email addresses:

- https://help.github.com/articles/setting-your-commit-email-address-in-git/
- https://help.github.com/articles/about-commit-email-addresses/
- https://help.github.com/articles/blocking-command-line-pushes-that-expose-your-personal-email-address/