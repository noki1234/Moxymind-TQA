using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests.Pages.Base;

public abstract class BasePage
{
    protected IWebDriver Driver { get; set; }
    protected WebDriverWait Wait { get; set; }
    private DriverSettings _driverSettings;

    protected BasePage(IWebDriver driver)
    {
       Driver = driver;
       Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
       _driverSettings = SeleniumClient.GetActualDriverSettings();
    }

    public IWebDriver GetDriver()
    {
        return Driver;
    } 
    
    
    public void Click(By selector)
    {
        ApplyElementDelay();
        var element = Driver.FindElement(selector);
        Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        element.Click();
    }

    public void SetInput(By selector, string value)
    {
        ApplyElementDelay();
        var element = Driver.FindElement(selector);
        element.Clear();
        element.SendKeys(value);
    }
    
    public void WaitUntilVisible(By selector)
    {
        Wait.Until(ExpectedConditions.ElementIsVisible(selector));
    }
    
    public void WaitUntilNotVisible(By selector)
    {
        Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(selector));
    }

    public void WaitUntilClickable(By selector)
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(selector));
    }
    
    public void AssertTexEquals(By selector, string text)
    {
        var element = Driver.FindElement(selector);
        Assert.That(element.Text, Is.EqualTo(text));
    }
    
    public void AssertTextContains(By selector, string text)
    {
        var element = Driver.FindElement(selector);
        Assert.That(element.Text, Contains.Substring(text));
    }
    
    private void ApplyElementDelay()
    {
        if (_driverSettings.enableSlowMode && _driverSettings.elementInteractionDelay > 0)
        {
            Thread.Sleep(_driverSettings.elementInteractionDelay);
        }
    }
    
}