# Moxymind-TQA

Test automation framework for API and UI testing using **.NET 8.0 and C#**.

## 🛠️ Technologies

- **.NET 8.0** with **C# 12.0**
- **NUnit** - Testing framework
- **Selenium WebDriver** - UI automation
- **Reqnroll** - BDD for API tests
- **RestSharp** - API client

## 📁 Project Structure

- **ApiTests** - API testing with BDD approach
- **SeleniumTests** - UI testing with Page Object Model

### 🌐 ApiTests - Structure
**Key Components:**
- **Features** - Human-readable test scenarios (Given/When/Then)
- **Steps** - C# methods that implement feature steps
- **Models** - Request/Response object definitions
- **Executors** - Handle API calls and response processing
- **Contexts** - Store test data shared across steps
- **TestData** - External data sources for data-driven tests

### 🖥️ SeleniumTests - Structure
**Key Components:**
- **Pages** - Page Object classes representing web pages/components
- **Base** - Common page functionality (waits, clicks, assertions)
- **Navigation** - Reusable navigation elements (top bar, menus)
- **Tests** - Actual test methods and test scenarios
- **SetupTestBase** - Browser setup, teardown, and test lifecycle management
- **SeleniumClient** - WebDriver creation and configuration management


## ⚙️ Setup

1. Install .NET 8.0 SDK
2. Install Chrome browser
3. Clone repository
4. Run `dotnet restore` -> restore/download dependencies
5. Run `dotnet build` -> build project
6. Run `dotnet test` -> run all tests

Note: Possible to update configuration files (`appsettings.json`)

## 🚀 Running Tests

```bash
# Run all tests
dotnet test

# Run API tests only
dotnet test ApiTests/

# Run UI tests only  
dotnet test SeleniumTests/
```

## 📝 Configuration
`Appsettings.json` files in both projects contains:
- Browser settings ( Selenium project )
- Application URLs and Api Keys
- Timeout values ( Selenium project )

## 🎯 Features
- API Testing with data-driven scenarios and also BDD scenarios
- UI Testing with configurable browser settings
- Page Object Model for maintainable UI tests
- Configurable waits and timeouts

## What could be improved in the future?
- **Error Handling:** Adding more robust error handling in API clients
- **Logging:** Consider Adding structured logging for better debugging
- **Retry Mechanisms:** For flaky Selenium tests/API tests
- **Parallel Execution:** Configure tests for parallel execution
- **Performance Testing:** Add performance tests
- **Test Reports:** Generate test reports (integration of livingDoc/Xml) + screenshots of failed tests