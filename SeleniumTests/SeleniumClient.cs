using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public static class SeleniumClient
{
    private static AppSettings _actualAppSettings;
    private static DriverSettings _actualDriverSettings;
    

    static SeleniumClient()
    {
        LoadAppSettings();
    }

    public static IWebDriver CreateDriver()
    {
        switch (_actualDriverSettings.browserType)
        {
            case "Chrome":
                return CreateChromeDriver();
            case "Firefox":
                throw new NotImplementedException("Firefox not implemented");
            default:
                throw new Exception("Invalid browser type");
        }
    }
    
    private static IWebDriver CreateChromeDriver()
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        if (_actualDriverSettings.headless) chromeOptions.AddArgument("--headless");
        if (_actualDriverSettings.maximized) chromeOptions.AddArgument("--start-maximized");
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddArgument("--test-type");
        chromeOptions.AddArgument("--ignore-certificate-errors");
        chromeOptions.AddArgument("--disable-search-engine-choice-screen");
        chromeOptions.AddArgument("--disable-infobars");
        chromeOptions.AddArgument("--disable-notifications");
        chromeOptions.AddArgument("--disable-popup-blocking");
        chromeOptions.AddArgument("--disable-translate");
        chromeOptions.AddArgument("--disable-extensions");
        chromeOptions.AddArgument("--disable-save-password-bubble");
        chromeOptions.AddArgument("--disable-password-manager");
        chromeOptions.AddArgument("--disable-password-generation");
        chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        chromeOptions.AddArgument($"--window-size={_actualDriverSettings.width},{_actualDriverSettings.height}");
        var driver = new ChromeDriver(chromeOptions);
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(_actualDriverSettings.turnOnWait);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(_actualDriverSettings.pageLoadTimeout);
        return driver;   
    }
    
    private static void LoadAppSettings()
    {
        var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        var jsonText = File.ReadAllTextAsync($"{projectDir}/appsettings.json");
        var config = JsonSerializer.Deserialize<RootConfig>(jsonText.Result);

        _actualAppSettings = config.Applications[config.SelectedApp];
        _actualDriverSettings = config.DriverSettings;
    }

    public static AppSettings GetActualAppSettings()
    {
        return _actualAppSettings;   
    }
    
    public static DriverSettings GetActualDriverSettings()
    {
        return _actualDriverSettings;   
    }
}