using OpenQA.Selenium;
using SeleniumTests.Pages.Base;

namespace SeleniumTests.Pages;

public class LoginPage: BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    #region UI Elements
    protected By ButtonLogin => By.Id("login-button");
    protected By InputUsername => By.Id("user-name");
    protected By InputPassword => By.Id("password");
    protected By LabelError => By.CssSelector("[data-test='error']");
    #endregion
    
    public void LoginWithUser(string username, string password)
    {
        SetUsername(username);
        SetPassword(password);
        ClickLoginButton();
    }

    public void AssertPageIsLoaded()
    {
        WaitUntilVisible(InputUsername);
        WaitUntilVisible(InputPassword);
        WaitUntilVisible(ButtonLogin);
    }
    
    public void ClickLoginButton()
    {
        Click(ButtonLogin);
    }
    
    public void SetUsername(string username)
    {
        SetInput(InputUsername, username);
    }
    
    public void SetPassword(string password)
    {
        SetInput(InputPassword, password);
    }
    
    public void AssertInputError(string error)
    {
        AssertTexEquals(LabelError, error);
    }
    
}