HelloWorld CI/CD with Azure DevOps


This project started as a simple .NET console app that prints Hello, World!. The application itself is intentionally small. The main work is in the pipeline: building the app, checking the result, assigning a version, and publishing packages from different branches.

I kept the application simple so I could focus on how the release process works from a Git push to a published artifact.
Project structure
- HelloWorld/ contains the .NET 8 console application.
- ReleaseGuardian/ is a CLI used by the pipeline to validate the HelloWorld version before publishing.
- ReleaseGuardian.Core/ contains the version validation logic.
- ReleaseGuardian.Tests/ contains unit tests for that logic. The tests are kept in the repository but are not part of the current HelloWorld pipeline.
- azure-pipelines.yml defines the CI/CD workflow.
How the pipeline works
A push to feature/advanced-ci or main starts a pipeline run on a Microsoft-hosted Ubuntu 24.04 agent.

Both branches run the same basic steps:
1. Check that the HelloWorld source files exist, validate the project XML, and check for whitespace errors.
2. Install .NET 8 and restore dependencies.
3. Generate a version in the format 1.0.<BuildId> and add a build tag containing the branch and version.
4. Build HelloWorld in Release mode.
5. Run the app and check that its output is exactly Hello, World!.
6. Run Release Guardian to validate the version before packaging or publishing.
The remaining steps depend on the branch.
Feature branch: feature/advanced-ci
The feature branch runs SonarQube Cloud analysis before packaging. It then:
- Creates a NuGet package from HelloWorld and pushes it to the helloworld-feed feed in Azure Artifacts.
- Generates release-manifest.json with the application name, version, branch, commit SHA, build ID, and artifact name.
- Publishes the compiled app and manifest as a Pipeline Artifact.
The Pipeline Artifact name follows <branch_name>_<version>, for example feature-advanced-ci_1.0.28. Slashes in branch names are replaced with hyphens.
Main branch: main
After a pull request is merged, the main pipeline builds and checks HelloWorld, validates the version with Release Guardian, and publishes the app as a Universal Package named helloworld in Azure Artifacts.

SonarQube Cloud analysis, NuGet publishing, and the Pipeline Artifact manifest are configured for feature/advanced-ci, not main.
Pull requests and notifications
The main branch is protected by a GitHub ruleset. Pull requests require successful Azure Pipelines and SonarCloud status checks before they can be merged.

Azure DevOps notifications are configured to send email when a build succeeds or fails. These notifications are managed in Azure DevOps, not through an email script in YAML.
Run locally
You need the .NET 8 SDK.
dotnet run --project HelloWorld
Expected output:
Hello, World!
Run Release Guardian with a valid version:
dotnet run --project ReleaseGuardian -- 1.0.28
Try an invalid version:
dotnet run --project ReleaseGuardian -- 0.1.0
Release Guardian returns exit code 0 for a valid version and 1 for an invalid one. The pipeline uses that exit code to decide whether to continue.
What I learned
The useful part of this project was connecting the tools into one workflow: GitHub triggers, Azure Pipeline tasks and conditions, .NET builds, SonarQube analysis, NuGet and Universal Packages, build tags, release metadata, and protected pull requests.

One thing I would improve next is testing the failure paths more thoroughly, especially confirming that a failed quality gate prevents package publishing.
