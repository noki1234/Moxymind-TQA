using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace SeleniumTests;

public class SetupTestBase
{
    public IWebDriver Driver;
    private DateTime _testStartTime;
    private DriverSettings _driverSettings = SeleniumClient.GetActualDriverSettings();

    [OneTimeSetUp]
    public void SetUp()
    {
        Driver = SeleniumClient.CreateDriver();
        Thread.Sleep(_driverSettings.browserStartupWait);

    }

    [OneTimeTearDown]
    public void Dispose()
    {
        Thread.Sleep(_driverSettings.browserEndupWait); 
        Driver.Dispose();
        Driver = null;
    }
    
    [SetUp]
    public void BeforeEachTest()
    {
        _testStartTime = DateTime.Now;
    }
    
    [TearDown]
    public void LogTestResult()
    {
        var testResult = TestContext.CurrentContext.Result;
        var testName = TestContext.CurrentContext.Test.Name;
        var duration = DateTime.Now - _testStartTime + TimeSpan.FromMilliseconds(_driverSettings.browserStartupWait) + TimeSpan.FromMilliseconds(_driverSettings.browserEndupWait);

        Console.WriteLine(new string('=', 60));
        
        switch (testResult.Outcome.Status)
        {
            case TestStatus.Passed:
                Console.WriteLine($"✅ TEST PASSED: {testName}");
                Console.WriteLine($"🕒 Duration: {duration:mm\\:ss}");
                TestContext.WriteLine($"{testName} completed successfully at {DateTime.Now:HH:mm:ss}");
                break;
                
            case TestStatus.Failed:
                Console.WriteLine($"❌ TEST FAILED: {testName}");
                Console.WriteLine($"🕒 Duration: {duration:mm\\:ss}");
                TestContext.WriteLine($"{testName} failed at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"💥 Error: {testResult.Message}");
                break;
                
            case TestStatus.Skipped:
                Console.WriteLine($"⏭️ TEST SKIPPED: {testName}");
                Console.WriteLine($"📝 Reason: {testResult.Message}");
                break;
        }
        
        Console.WriteLine(new string('=', 60));
    }
    
    
    
}