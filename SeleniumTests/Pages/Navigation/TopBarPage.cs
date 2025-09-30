using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages.Navigation;

public class TopBar: BasePage
{
    public LeftMenuPanel LeftMenuPanel;
    public TopBar(IWebDriver driver) : base(driver)
    {
        LeftMenuPanel = new LeftMenuPanel(Driver);
    }

    #region UI Elements    
    protected By ButtonOpenLeftMenu => By.Id("react-burger-menu-btn");
    protected By ButtonShoppingCart => By.Id("shopping_cart_container");
    protected By ShoppingCartCountBadge => By.CssSelector("[data-test='shopping-cart-badge']");
    #endregion
    
    public void ClickButtonOpenLeftMenuPanel()
    {
        Click(ButtonOpenLeftMenu);
    }
    
    public void AssertTopBarIsLoaded()
    {
        WaitUntilClickable(ButtonOpenLeftMenu);
        WaitUntilClickable(ButtonShoppingCart);
    }
    
    public void ClickButtonOpenShoppingCart()
    {
        Click(ButtonShoppingCart);
    }
    
    public void AssertShoppingCartCountBadge(int count)
    {
        AssertTexEquals(ShoppingCartCountBadge, count.ToString());
    }
    
    public void AssertShoppingCartCountBadgeIsHidden()
    {
        WaitUntilNotVisible(ShoppingCartCountBadge);
    }
}