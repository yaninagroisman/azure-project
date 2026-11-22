# Azure DevOps CI/CD Pipeline

## Overview

This project demonstrates the implementation of a **CI/CD pipeline using Microsoft Azure DevOps** for a .NET application.

The pipeline automates building, versioning, code analysis, packaging, and artifact publishing. It also includes branch-based conditional execution and pipeline status notifications.

## Technologies

- **.NET SDK / C#** – Application development
- **Git & GitHub** – Source code management
- **Azure DevOps Pipelines** – CI/CD automation
- **Microsoft-hosted Agents** – Pipeline execution
- **Azure Artifacts** – Package management
- **NuGet** – .NET package creation and distribution
- **SonarQube** – Static code analysis
- **YAML** – Pipeline configuration

## Project Structure

```text
azure-devops-project/
├── HelloWorld/
│   ├── Program.cs
│   └── HelloWorld.csproj
├── azure-pipelines.yml
├── .gitignore
└── README.md
```

### Prerequisites

- .NET SDK 8.0
- Git
- Azure DevOps account
- GitHub account


## CI/CD Pipeline

The Azure DevOps pipeline is designed to perform the following operations:

1. Checkout source code from GitHub.
2. Restore .NET dependencies.
3. Build the application.
4. Automatically increment the application version.
5. Print the generated version to the pipeline logs.
6. Publish build artifacts to Azure Artifacts.
