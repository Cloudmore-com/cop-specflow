# Specflow Solution in C# for COP UI and API
This repository is proof of concept solution which has scenarios for COP UI and API. Those scenarios were written in [Gherkin](https://cucumber.io/docs/gherkin/) language.

## Tech-Stack
1. [Specflow](https://specflow.org/), BDD framework that parses Gherkin scenarios and convert them into c# code.
2. [Playwright](https://playwright.dev/dotnet/), Test automation framework for UI and API.
3. [NUnit](https://nunit.org/), unit-testing framework to make assertion between actual and expected values.
3. [.Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), framework with is compitable with Specflow.

## IDE
1. [Rider](https://www.jetbrains.com/rider/), to create/contribute project on local machine.

## How to run solution on your local machine
1. Clone repository
2. Open solution with Rider IDE
3. Download neccessary plugins [Specflow for Rider](https://docs.specflow.org/projects/getting-started/en/latest/gettingstartedrider/Step1r.html)
4. Install playwright, check [here](https://playwright.dev/dotnet/docs/intro).
4. Open terminal and cd to project directory.
```
$ cd /Users/sercansensulun/Desktop/proof-of-concept-cop-specflow/COPSpecFlowNUnit/COPSpecFlowNUnit 
```
6. Build the project. 
```
$ dotnet build
```
7. To run all scenarios
```
$ dotnet test
```
8. To run only API scenarios
```
$ dotnet test --filter:"TestCategory=CopApi"
```
9. To run only UI scenarios
```
$ dotnet test --filter:"TestCategory=CopUI"
```

## Where can I find gherkin scenarios, feature files?
API feature files are located under this **COPSpecFlowNUnit/COPSpecFlowNUnit/Features/api** path.

UI feature files are located under this **COPSpecFlowNUnit/COPSpecFlowNUnit/Features/ui** path.