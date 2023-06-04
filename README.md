<div align="center">
    <a href="https://github.com/Falcion/Zustandsmaschine/actions/workflows/codeql.yml"><img src="https://github.com/Falcion/Zustandsmaschine/actions/workflows/codeql.yml/badge.svg" alt="codeql"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/actions/workflows/dotnet.yml"><img src="https://github.com/Falcion/Zustandsmaschine/actions/workflows/dotnet.yml/badge.svg" alt="dotnet"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/graphs/contributors"><img src="https://img.shields.io/github/contributors/Falcion/Zustandsmaschine" alt="contributors"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/stargazers"><img src="https://img.shields.io/github/stars/Falcion/Zustandsmaschine" alt="stargazers"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/forks"><img src="https://img.shields.io/github/forks/Falcion/Zustandsmaschine" alt="forks"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/issues"><img src="https://img.shields.io/github/issues/Falcion/Zustandsmaschine" alt="issues"/></a>
    <a href="https://github.com/Falcion/Zustandsmaschine/commits"><img src="https://img.shields.io/github/last-commit/Falcion/Zustandsmaschine" alt="commit-activity"/></a>
    <a href="https://www.nuget.org/packages/Zustandsmaschine"><img src="https://img.shields.io/nuget/dt/Zustandsmaschine" alt="downloads"/></a>
</div>

<br/>
<div align="center">
    <img src="./.github/images/icon.png" alt="icon" width="160" height="160"/>
    <h3>Zustandsmaschine</h3>
    <p>Statemachine for your code.
    <br/>
    <a href="https://github.com/Falcion/Zustandsmaschine/wiki/"><strong>«Explore the docs»</strong></a>
    <br/>
    <br/>
    <a href="https://github.com/Falcion/Zustandsmaschine/tags/">View tags</a>
    /
    <a href="https://github.com/Falcion/Zustandsmaschine/issues/new?assignees=Falcion&labels=Error&template=issue-about-bug.md&title=ERROR%3A+Enter+the+header+of+an+issue">Report a bug</a>
    /
    <a href="https://www.nuget.org/packages/Zustandsmaschine/">NUGET package</a>
    </p>
</div>

<!-- README introduction:
 Describe your project from unknown perspective and tell,
 what it does and try to interest contributor or user to
 your project. 
 -->

About the project
-----------------

... TO-DO: (too many to write for this big project).

### Built-with

Project was created, inspired and built with this wonderfuls:

- [.NET 7.0](https://dotnet.microsoft.com/)
- https://visualstudio.microsoft.com/
- https://code.visualstudio.com/
- sophisticated with: https://github.com/angular/angular/

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

Getting started
---------------

Before using this project or working with its source code, read this paragraph so that you wouldn't have unnecessary questions or problems.

### Prerequisites

Before using this application, ensure you met this requirements:

- Any potentional IDE or text-editor with .NET native support (better if with support of NUGET);
- Downloaded .NET SDK on your working machine;
- \* if you desire to contribute to the project, also downloaded [Node.js](https://nodejs.org/) on your machine for integration with commits linting and auto-changelogs;

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

### Installation

Permission is granted for free use in any of your products.

Guide for installation of source code of the class-library:

1. clone the repository with any form of application that supports GIT;
2. initialize linterns, NPM and HUSKY for commitlintering;
3. make your changes via [contributioning policy and commit convention](#contributioning);
4. work as instructed, class-library is ready to be edited in forked repository;

Instruction about working and setting up automatically linted commits and changelog from them, read - [article about Angular.js conventions](https://mokkapps.de/blog/how-to-automatically-generate-a-helpful-changelog-from-your-git-commit-messages/).

Process of installation within NUGET package manager in VS:

1. open project in IDE with .NET native-support;
2. use the specified package manager in your IDE (in VS - find this in upper hotbar);
3. write the name of this package into packages browser;
4. download the required for you version through the menu and package is ready-to-use.

If you use a different IDE without native support for NUGET, read this article: [using new commands in .NET]( https://stackoverflow.com/questions/40675162/install-a-nuget-package-in-visual-studio-code/).

For Visual Studio 2019 you may not find `Project` -> `Add Reference option`. Use `Project` -> `Add Project Reference`. Then in dialog window navigate to Browse tab and use `Browse` to find and attach your DLL.

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

Usage
-----

Project, because of its simplicity in common sense, doesn't have any direct idea of usage, but it created to define some processes for your solutions:

- custom system of message broker;
- fully-prepared infrastructure of stateflow and its assembler;
- custom and in-time prepared analyzers;
- big program realisation of finite automaton for your methods;

If you want to use this project in your own, just install it in and reference it as namespace: nothing special.

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

<!-- Roadmap:
 Create, design and write any roadmap you want: you
 can even delete this paragraph if you don't like big
 planning ideas in your projects.
 -->

Roadmap
-------

- [x] Write demonstration code (alpha version) of this project.
- [ ] Implement new features for fully independent architecture for finite automaton.
- [ ] Fix the bugs.
- [ ] ... etc from future roadmap.

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

<!-- Contributioning idea:
 Contributors, contributing guidelines and other: here you can type random 
 contributors or simply write a contributing guideline/reference contributing 
 policy here.
 
 Github is an open source community, so I highly recommend you to setup this 
 block of your project.
 -->

Contributioning
---------------

Contributions are what make open source community such an interest place to be in - so any form of contribution are greatly appreciated.

If you think that you can help this project become better but think its not so important/realizable in the current situtation or for a full contribution, use issues block, otherwise there is a guideline and policy for contributing.

If you want to contribute to this project, please, read contributioning policy and commit convention, this repository works with CLA, commits convention and on automated deployment system.

- [Commit convention](./.github/docs/COMMIT_CONVENTION.md);
- [Contributioning policy](./.github/CONTRIBUTING.md);

**For one-single file contributioning, use a more quicker way without forking the repository through website.**

More about it in this article: in [official GIT docs](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/working-with-forks/syncing-a-fork/) about syncing one-file fork.

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

<!-- License:
 Paragraph about distribution policy in this repository and
 here, you can type any distinct references for any content.
 -->

License
-------

Project is being distributed under the [MIT License](https://choosealicense.com/licenses/mit/): see the file for more specified information.

This README was inspired by this - [best README template](https://github.com/othneildrew/Best-README-Template/).

<!-- Contact information:
 Ensure you typed atleast an abstract way to
 reach you for any interested person: in may be
 helpful for those, who are in need or in state
 of emergency.
 -->

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>


Contact
-------

Any public contact information for developer either team can be acquired here, in other case, use issues and discussions.

- DEV.TO page of developer: https://dev.to/falcion/

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>

<!-- Acknowledgements:
 Paragraph of this created for contributions and
 references to any useful web-resources which you
 could recommend in-case of project themed topic. 
 -->

Acknowledgements
----------------

- [.NET](https://dotnet.microsoft.com/en-us/)
- https://gitignore.io/
- https://gitattributes.io/
- [README template](https://github.com/othneildrew/Best-README-Template/)

<p align="right"><a href="#readme-top" title="Back to the top of README">[^]</a></p>