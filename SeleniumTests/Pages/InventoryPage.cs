using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class InventoryPage: BasePage
{
    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }
    
    #region UI Elements
    protected By Header => By.CssSelector("[data-test='title']");
    protected By DropdownFilter => By.CssSelector("[data-test='product-sort-container']");
    protected By LabelItemPrice(string itemTitle) => By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//div[@data-test='inventory-item-price']");
    protected By ButtonItemAddToCart(string itemTitle) => By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//button[contains(@id,'add')]");
    protected By ButtonItemRemoveFromCart(string itemTitle) => By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemTitle}']/ancestor::div[@data-test='inventory-item']//button[contains(@id,'remove')]");
    #endregion
    
    public void AssertPageIsLoaded()
    {
        WaitUntilVisible(Header);
        AssertTexEquals(Header, "Products");
        WaitUntilClickable(DropdownFilter);
    }
    
    public void ClickButtonItemAddToCart(string itemTitle)
    {
        Click(ButtonItemAddToCart(itemTitle));
    }
    
    public void ClickButtonItemRemoveFromCart(string itemTitle)
    {
        Click(ButtonItemRemoveFromCart(itemTitle));
    }

    public void AssertItemWithPriceDisplayed(string itemTitle, string price)
    {
        AssertTexEquals(LabelItemPrice(itemTitle), price);   
    }
    
}