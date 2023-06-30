- [Contribution Guidelines](#contribution-guidelines)
  - [Guidelines for Contributions](#guidelines-for-contributions)
  - [Guidelines for Submissions](#guidelines-for-submissions)
    - [Submitting an Issue](#submitting-an-issue)
    - [Submitting a Pull Request (PR)](#submitting-a-pull-request-pr)
    - [Reviewing Pull Requests](#reviewing-pull-requests)
  - [Committing Conventions](#committing-conventions)
  - [Signing the Contributor License Agreement (CLA)](#signing-the-contributor-license-agreement-cla)

## Contribution Guidelines

We greatly appreciate the contributions from our diverse community of developers who have come together from around the world to build the amazing contributor world we know today. We are fortunate to be part of such a beautiful community. To ensure a smooth experience for everyone involved, we have established some conventions and guidelines that all foreign developers must adhere to before making any changes. These guidelines will help us maintain a collaborative and welcoming environment.

### Guidelines for Contributions

When contributing to our software or documentation, please keep the following guidelines in mind:

- **Don't surprise us** with large pull requests. Instead, start a discussion by filing an issue so we can agree on the direction before investing a significant amount of time.
- **Avoid including sample code inline** in your push. Instead, use a snippet project with code that can be embedded in the article.
- **Follow these instructions and the code of conduct**.
- **Use the forked repository** as the starting point for your work.
- **Create a separate branch** on your fork before working on the project.
- **Follow the [GitHub flow](https://guides.github.com/introduction/flow/)**.
- **Feel free to blog, tweet, or share** about your contributions if you like!

Following these guidelines will ensure a better experience for you and for us.

### Guidelines for Submissions

The infrastructure of our repository in Git provides various tools for open-source communication. We pledge to make the most of these tools for effective collaboration.

#### Submitting an Issue

Before submitting an issue, please search the issue tracker to see if a similar issue already exists. The discussion in existing issues may provide you with valuable information and workarounds.

While we aim to fix issues promptly, it is crucial that we can reproduce and confirm them first. To help us with this process, we require that you provide a **minimal reproducible scenario**. This scenario should contain the essential information to reproduce the issue, saving us time and ensuring we can fix the problem effectively. We understand that extracting essential bits of code from a larger codebase can be challenging, but isolating the problem is necessary for us to address it.

Please note that we are unable to investigate or fix bugs without a minimal reproduction. If we do not receive enough information to reproduce the issue, we may have to close it.

#### Submitting a Pull Request (PR)

Before submitting your pull request, please consider the following guidelines:

1. **Search the repository** for open or closed PRs related to your submission to avoid duplicating existing efforts.
2. Make sure the issue you are fixing is described or that the feature you want to add is documented in an issue. Discussing the design upfront helps ensure that we are ready to accept your work.
3. If required, **sign the Contributor License Agreement (CLA)** before sending PRs. We cannot accept code without a signed CLA. Make sure your commits are associated with the email address used in your CLA signature.
4. **Fork the repository**.
5. In your forked repository, create a new git branch for your changes.
6. Make your changes, including appropriate checks and testing.
7. Follow the coding conventions or adhere to the existing conventions.
8. Commit your changes using a descriptive commit message that follows our [Commit Message Convention (CMC)](./docs/COMMIT_CONVENTION.md). Adhering to this convention is necessary because release notes are automatically generated from these messages.
9. Push your branch to the repository.
10. On GitHub, send a pull request to the main production branch.

```powershell
git checkout -b [BRANCH_NAME]
git commit --all
git

 push origin [BRANCH_NAME]
```

#### Reviewing Pull Requests

As maintainers, we reserve the right not to accept pull requests from community members who have not been good citizens of our community. This includes not following the Code of Conduct (COC) within or outside of our managed channels.

**Addressing Review Feedback**

If we ask for changes through code reviews:

1. Make the required updates to the code.
2. Re-run the CLI tests and build with no-traverse your version to ensure tests are still passing.
3. Create a fixup commit and push it to your forked repository. This will update your pull request.

```powershell
git commit --all --fixup HEAD
git push
```

For more information on working with fixup commits, refer to the [MD article in the Angular documentation](https://github.com/angular/angular/blob/main/docs/FIXUP_COMMITS.md).

**Updating the Commit Message**

Reviewers may suggest changes to a commit message, such as adding more context or adhering to commit message guidelines. To update the commit message of the last commit on your branch:

1. Checkout your branch.
2. Amend the last commit and modify the commit message.
3. Push to your forked repository.

```powershell
git checkout [BRANCH_NAME]
git commit --amend
git push --force-with-lease
```

> If you need to update the commit message of an earlier commit, you can use interactive mode with `git rebase`. Refer to the GIT documentation for more details on this procedure: [Interactive Mode with Git Rebase](https://git-scm.com/docs/git-rebase#_interactive_mode).

**After Your Pull Request is Merged**

If your pull request is merged, you can safely delete your branch and pull the changes from the main upstream repository. The same applies within your forked repository.

1. Delete the remote branch either through the web client UI or the local shell.
2. Checkout the main branch.
3. Delete your local branch.
4. Update your local branch of the upstream repository with the latest version from origin:

```powershell
git push origin [BRANCH_NAME]
git checkout master -f
git branch -D [BRANCH_NAME]
git pull -ff upstream master
```

### Committing Conventions

To ensure consistency throughout the source code, please keep the following rules in mind when working with our open-source project:

- All features or bug fixes must be **tested**.
- All **public API methods must be documented**.

For advanced committing conventions, refer to our specified documentation file: [Commit Convention](./COMMIT_CONVENTION.md).

### Signing the Contributor License Agreement (CLA)

Sometimes, you may be asked to sign the Contributor License Agreement (CLA) before sending a pull request. Signing the CLA is a quick and easy process, and it is required for any code changes to be accepted.

- For individuals:\
  [Google Individual CLA](https://cla.developers.google.com/about/google-individual)
- For corporations: Print, sign, scan, and email the provided form:\
  [Google Corporate CLA](https://cla.developers.google.com/about/google-corporate)

If you have multiple accounts or multiple email addresses associated with a single account, you must sign the CLA using the primary email address of the GitHub account used to author git commits and send pull requests.

The following documents can help you sort out issues with accounts and multiple email addresses:

- [Setting Your Commit Email Address in Git](https://help.github.com/articles/setting-your-commit-email-address-in-git/)
- [About Commit Email Addresses](https://help.github.com/articles/about-commit-email-addresses/)
- [Blocking Command-Line Pushes That

 Expose Your Personal Email Address](https://help.github.com/articles/blocking-command-line-pushes-that-expose-your-personal-email-address/)