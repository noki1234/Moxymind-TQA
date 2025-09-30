using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages.Navigation;

public class LeftMenuPanel: BasePage
{
    public LeftMenuPanel(IWebDriver driver) : base(driver)
    {
    }
    
    #region UI Elements
    protected By ButtonClose => By.Id("react-burger-cross-btn");
    protected By ButtonAllItems => By.Id("inventory_sidebar_link");
    protected By ButtonAbout => By.Id("about_sidebar_link");
    protected By ButtonLogout => By.Id("logout_sidebar_link");
    protected By ButtonResetAppState => By.Id("reset_sidebar_link");

    #endregion

    public void AssertLeftMenuPanelIsLoaded()
    {
        WaitUntilClickable(ButtonClose);
        WaitUntilClickable(ButtonAllItems);
        WaitUntilClickable(ButtonAbout); 
        WaitUntilClickable(ButtonLogout); 
        WaitUntilClickable(ButtonResetAppState);
    }
    
    public void ClickLogoutButton()
    {
        Click(ButtonLogout);
    }
}