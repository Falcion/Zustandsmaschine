# Issue Policy

This Issue Policy outlines the different categories of issues in the Project's GitHub repository and provides guidelines and processes associated with each type of issue.

Before creating a new issue, please search for related issues and check if they address your concern.

For general support inquiries or questions (e.g., "How do I do X?"), please ask on [Stack Overflow](https://stackoverflow.com/questions/).

## Issue Categories

Our issue categorization follows the following categories:

1. Feature Requests
2. Bug Reports
3. Documentation Issues
4. Installation Issues
5. Questions

Each category has its own GitHub issue template. Please avoid deleting the issue template unless you are certain your issue falls outside its scope.

### Feature Requests

#### Guidelines

Feature requests that are more likely to be accepted:

- Are focused and minimal in scope (note that it's usually easier to add additional functionality later than remove functionality).
- Are designed with extensibility in mind (e.g., if proposing an integration with a specific framework, consider the potential for similar integrations with other frameworks).
- Have clear user impact and value that justifies the maintenance effort required to support the feature in the long term. Refer to the [JQuery contributor guide](https://contribute.jquery.org/open-source/#contributing-something-new) for an excellent discussion on this.

#### Lifecycle

The lifecycle of a feature request typically involves the following steps:

1. Submit a feature request GitHub issue, providing a high-level description of the proposal and its motivation. If possible, include an overview of the feature's implementation.
2. The issue is triaged to determine if more information is needed from the author, assign a priority, and route it to the appropriate committers.
3. The feature request is discussed with a committer. The committer may provide input on the implementation overview or request a more detailed design, if necessary.
4. After discussing and reaching an agreement on the feature request and its implementation, an implementation owner is identified.
5. The implementation owner starts developing the feature and ultimately submits associated pull requests against the project.

### Bug Reports

#### Guidelines

To ensure that maintainers can effectively assist with reported bugs, please follow these guidelines:

- Fill out the bug report template completely, providing appropriate levels of detail, especially in the `Code to reproduce the issue` section.
- Verify that the bug meets one of the following criteria:
  - It is a regression, meaning that a recent release of the project no longer supports an operation that an earlier release did.
  - A documented feature or functionality does not work properly when following the provided examples in the documentation.
  - Any exceptions raised are directly related to the project and not the result of an underlying package's exception (e.g., do not file an issue if the project cannot log a model due to a TensorFlow exception).
- Make a best effort to diagnose and troubleshoot the issue before filing a report.
- Ensure that the environment in which you are experiencing the bug is supported as defined in the documentation.
- Confirm that the project supports the functionality you are having an issue with. Note that the absence of a feature does not necessarily constitute a bug.
- Read the documentation related to the feature you are reporting on. If you are certain that you are following the documented guidelines, please file a bug report.

#### Lifecycle

The lifecycle of a bug report typically involves the following steps:

1. Submit a bug report GitHub issue, providing a high-level description of the bug and all the information required to reproduce it.
2. The bug report is triaged to determine if more information is needed from the author, assign a priority, and route it to the appropriate

 committers.
3. A project committer reproduces the bug and provides feedback on how to address it.
4. Once an approach is agreed upon, an owner for the fix is identified. For critical bugs, project committers may take ownership to ensure a timely resolution.
5. The fix owner begins implementing the solution and ultimately submits associated pull requests.

### Documentation Issues

#### Lifecycle

The lifecycle of a documentation issue typically involves the following steps:

1. Submit a documentation GitHub issue, describing the issue and indicating its location(s) in the project documentation.
2. The issue is triaged to determine if more information is needed from the author, assign a priority, and route it to the appropriate committers.
3. A project committer confirms the documentation issue and provides feedback on how to address it.
4. Once an approach is agreed upon, an owner for the fix is identified. For critical documentation issues, project committers may take ownership to ensure a timely resolution.
5. The fix owner begins implementing the solution and ultimately submits associated pull requests.

### Installation Issues

#### Lifecycle

The lifecycle of an installation issue typically involves the following steps:

1. Submit an installation GitHub issue, describing the issue and indicating the affected platforms.
2. The issue is triaged to determine if more information is needed from the author, assign a priority, and route it to the appropriate committers.
3. A project committer confirms the installation issue and provides feedback on how to address it.
4. Once an approach is agreed upon, an owner for the fix is identified. For critical installation issues, project committers may take ownership to ensure a timely resolution.
5. The fix owner begins implementing the solution and ultimately submits associated pull requests.

### Questions

#### Guidelines

Questions should be relevant to the project and its scope. They can range from asking for clarification on specific features to seeking guidance on best practices.

#### How to Ask

1. Use the "Question" issue template when creating a new question.
2. Provide a clear and concise description of your question, ensuring it is relevant to the project.
3. Include any necessary context or background information to help others understand the question.
4. Be respectful and considerate when interacting with others in the discussion.

### Conclusion

By adhering to the appropriate issue template and following these guidelines, you can help us efficiently address your concerns and contribute to the project's improvement.

