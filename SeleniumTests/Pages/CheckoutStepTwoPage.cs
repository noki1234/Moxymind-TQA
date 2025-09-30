using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class CheckoutStepTwoPage : BasePage
{
    public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
    {
    }

    #region UI Elements

    protected By Header => By.CssSelector("[data-test='title']");

    protected By LabelItemPrice(string itemTitle) => By.XPath(
        $"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//div[@data-test='inventory-item-price']");

    protected By ButtonCancel => By.Id("cancel");
    protected By ButtonFinish => By.Id("finish");

    #endregion

    public void ClickButtonCancel()
    {
        Click(ButtonCancel);
    }
    
    public void ClickButtonFinish()
    {
        Click(ButtonFinish);
    }
    
    public void AssertPageIsLoaded()
    {
        WaitUntilVisible(Header);
        AssertTexEquals(Header, "Checkout: Overview");
        WaitUntilVisible(ButtonCancel);
        WaitUntilVisible(ButtonFinish);
    }

    public void AssertItemWithPriceDisplayed(string itemTitle, string price)
    {
        AssertTexEquals(LabelItemPrice(itemTitle), price);
    }
}