using SeleniumTests.Pages;

namespace SeleniumTests.Tests;

public class LoginTest: SetupTestBase
{
    private LoginPage _loginPage;
    private InventoryPage _inventoryPage;
    
    
    [OneTimeSetUp]
    public void BeforeTest()
    {
        _loginPage = new LoginPage(Driver);
        _inventoryPage = new InventoryPage(Driver);
    }

    [Test]
    public void Login_ValidCredentials()
    {
        Driver.Navigate().GoToUrl(SeleniumClient.GetActualAppSettings().BaseUrl);
        _loginPage.AssertPageIsLoaded();
        
        _loginPage.SetUsername("standard_user");
        _loginPage.SetPassword("secret_sauce");
        _loginPage.ClickLoginButton();
        _inventoryPage.AssertPageIsLoaded();
    }
    
    [Test]
    public void Login_InvalidCredentials()
    {
        Driver.Navigate().GoToUrl(SeleniumClient.GetActualAppSettings().BaseUrl);
        _loginPage.AssertPageIsLoaded();

        // Assert empty/missing credentials 
        _loginPage.ClickLoginButton();
        _loginPage.AssertInputError("Epic sadface: Username is required");
        
        _loginPage.SetUsername("invalid_user");
        _loginPage.ClickLoginButton();
        _loginPage.AssertInputError("Epic sadface: Password is required");

        // Assert invalid credentials
        _loginPage.SetUsername("invalid_user");
        _loginPage.SetPassword("invalid_password");
        _loginPage.ClickLoginButton();
        _loginPage.AssertInputError("Epic sadface: Username and password do not match any user in this service");
        
    }
}