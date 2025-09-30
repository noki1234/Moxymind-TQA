using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class CheckoutCompletePage: BasePage
{
    public CheckoutCompletePage(IWebDriver driver) : base(driver)
    {
    }
    
    #region UI Elements
    protected By Header => By.CssSelector("[data-test='title']");
    protected By LabelCompleteText => By.CssSelector("[data-test='complete-text']");
    protected By LabelCompleteHeader => By.CssSelector("[data-test='complete-header']");
    protected By BackHomeButton => By.Id("back-to-products");
    
    #endregion

    public void AssertPageIsLoaded()
    {
         WaitUntilVisible(Header);
         AssertTexEquals(Header, "Checkout: Complete!");
         WaitUntilVisible(LabelCompleteHeader);
         WaitUntilVisible(LabelCompleteText);
         WaitUntilClickable(BackHomeButton);
    }

    public void AssertOrderIsSuccess()
    {
        AssertTexEquals(LabelCompleteHeader, "Thank you for your order!");
        AssertTexEquals(LabelCompleteText, "Your order has been dispatched, and will arrive just as fast as the pony can get there!");
    }
    
    public void ClickBackHomeButton()
    {
        Click(BackHomeButton);
    }
}