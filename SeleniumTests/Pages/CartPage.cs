using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class CartPage: BasePage
{
    public CartPage(IWebDriver driver) : base(driver)
    {
    }
    
    #region UI Elements
    protected By Header => By.CssSelector("[data-test='title']");
    protected By LabelItemPrice(string itemTitle) => By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//div[@data-test='inventory-item-price']");
    protected By ButtonItemRemoveFromCart(string itemTitle) => By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//button[contains(@id,'remove')]");
    protected By InventoryItem => By.CssSelector("[data-test='inventory-item']");
    protected By ButtonContinueShopping => By.Id("continue-shopping");
    protected By ButtonCheckout => By.Id("checkout");
    #endregion
    
    public void AssertPageIsLoaded()
    {
        WaitUntilVisible(Header);
        AssertTexEquals(Header, "Your Cart");
        WaitUntilVisible(ButtonContinueShopping);
        WaitUntilVisible(ButtonCheckout);
    }

    public void ClickButtonItemRemoveFromCart(string itemTitle)
    {
        Click(ButtonItemRemoveFromCart(itemTitle));
    }
    
    public void ClickButtonContinueShopping()
    {
        Click(ButtonContinueShopping);
    }
    
    public void ClickButtonCheckout()
    {
        Click(ButtonCheckout);
    }

    public void AssertItemWithPriceDisplayed(string itemTitle, string price)
    {
        AssertTexEquals(LabelItemPrice(itemTitle), price);   
    }

    public void AssertItemIsRemoved(string itemTitle)
    {
        WaitUntilNotVisible(LabelItemPrice(itemTitle));
    }

    public void AssertCartIsEmpty()
    {
        WaitUntilNotVisible(InventoryItem);   
    }
}