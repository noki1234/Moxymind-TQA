using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class CheckoutStepOnePage: BasePage
{
    public CheckoutStepOnePage(IWebDriver driver) : base(driver)
    {
    }
    
    #region UI Elements
    protected By Header => By.CssSelector("[data-test='title']");
    protected By InputFirstName => By.Id("first-name");
    protected By InputLastName => By.Id("last-name");
    protected By InputPostCode => By.Id("postal-code");
    protected By ButtonCancel => By.Id("cancel");
    protected By ButtonContinue => By.Id("continue");
    protected By LabelError => By.CssSelector("[data-test='error']");
    #endregion
    
    public void AssertPageIsLoaded()
    {
        WaitUntilVisible(Header);
        AssertTexEquals(Header, "Checkout: Your Information");
        WaitUntilVisible(InputFirstName);
        WaitUntilVisible(InputLastName);
        WaitUntilVisible(InputPostCode);
        WaitUntilVisible(ButtonCancel);
        WaitUntilVisible(ButtonContinue);
    }
    
    public void ClickButtonCancel()
    {
        Click(ButtonCancel);
    }

    public void ClickButtonContinue()
    {
        Click(ButtonContinue);
    }

    public void SetMandatoryValues(string firstName, string lastName, string postCode) 
    {
        SetInput(InputFirstName, firstName);
        SetInput(InputLastName, lastName);
        SetInput(InputPostCode, postCode);
    }
    
    public void AssertInputError(string error)
    {
        AssertTexEquals(LabelError, error);
    }
}