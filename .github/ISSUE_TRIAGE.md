# Issue Triage

This document serves as a hands-on manual for performing issue and pull request triage for the project's issues on GitHub. The primary objective of triage is to expedite issue management and provide faster responses to community members.

Issue and pull request triage involves three key steps:

1. Assigning one or more process labels, such as "needs design" or "help wanted."
2. Marking a priority for each issue.
3. Labeling one or more relevant areas, languages, or integrations to facilitate issue routing to the appropriate contributors or reviewers.

The purpose of this guide is to outline the labels used in each of these steps and provide instructions on how to apply them effectively.

## Assigning Process Labels

Every triaged issue should have at least one process label assigned to it. The following process labels are used:

- `needs author feedback`: This label indicates that input from the issue or pull request author is required to proceed further.
- `needs design`: Use this label for features that are sufficiently complex or substantial to warrant a design document and review before implementation.
- `needs committer feedback`: Assign this label to issues or pull requests that require feedback from a committer regarding the approach or appropriateness of the contribution, or if the design is ready for committer review.
- `needs review`: Apply this label to issues that necessitate a detailed design review or to pull requests that are ready for review (all questions answered, PR updated if necessary, tests passing).
- `help wanted`: Issues labeled as "help wanted" indicate that community assistance is sought for their resolution.
- `good first issue`: This label is used to identify issues that would be suitable for first-time contributors.

## Assigning Priority

Assigning a priority to each triaged issue is crucial for effective issue management. The project follows the `kubernetes-style` priority labels, which are as follows:

- `priority/critical-urgent`: This is the highest priority level and should be assigned to critical issues that require immediate attention, such as security bugs, regressions, or release blockers.
- `priority/important-soon`: Issues labeled as "important-soon" are actively being worked on by the community or will be addressed in the near future, ideally before the next release.
- `priority/important-longterm`: This priority level is assigned to issues that are deemed important in the long term but may require multiple releases or additional resources to complete. It is also used for issues on contributors' roadmaps for the coming months. To indicate active development and potential inclusion in the next release, change the priority to `priority/important-soon` when someone starts actively working on an issue with this label.
- `priority/backlog`: Issues labeled as "backlog" are considered useful but not prioritized for the next few months. Community members are encouraged to tackle these issues, although there may be some delay in receiving support through design review or pull request feedback.
- `priority/awaiting-more-evidence`: This is the lowest priority level. Issues assigned this label are potentially valuable but lack sufficient evidence or support to prioritize their implementation. It is essential to avoid using this label as a way to decline issues. If an issue does not fit within the project's scope, it is better to explain why rather than assigning this label.

## Labeling Relevant Areas

To facilitate efficient issue routing, it is important to assign one or more labels representing relevant components, interface surface areas, languages, or integrations. The project aims to use a minimal set of labels required for effective routing. The following labels are used:

### Components

- `area/artifacts`: Artifact stores and artifact logging.
- `area/build`: Build and test infrastructure for the project.
- `area/docs`: Project documentation pages.
- `area/examples`: Example code.
- `area/model-registry`: Model Registry service, APIs, and fluent client calls for Model Registry.
- `area/models`: MLmodel format, model serialization/deserialization, flavors.
- `area/recipes`: Recipes, Recipe APIs, Recipe configs, Recipe Templates.
- `area/projects`: MLproject format, project execution backends.
- `area/scoring`: Project Model server, model deployment tools, Spark UDFs.
- `area/server-infra`: Project Tracking server backend.
- `area/tracking`: Tracking Service, tracking client APIs, autologging.

### Interface Surface

- `area/uiux`: Front-end development, user experience, plotting, JavaScript, JavaScript dev server.
- `area/docker`: Docker usage across the project's components, such as project Projects and project Models.
- `area/sqlalchemy`: Use of SQLAlchemy in the Tracking Service or Model Registry.
- `area/windows`: Windows support.

### Language Surface

- `language/r`: R APIs and clients.
- `language/java`: Java APIs and clients.
- `language/new`: Proposals for new client languages.

### Integrations

- `integrations/azure`: Azure and Azure ML integrations.
- `integrations/sagemaker`: SageMaker integrations.
- `integrations/databricks`: Databricks integrations.

By applying these labels, contributors and reviewers can easily identify the areas, languages, or integrations relevant to the specific issue or pull request.
