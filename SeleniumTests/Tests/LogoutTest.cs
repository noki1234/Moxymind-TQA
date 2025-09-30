using SeleniumTests.Pages;
using SeleniumTests.Pages.Navigation;

namespace SeleniumTests.Tests;

public class LogoutTest: SetupTestBase
{
    private LoginPage _loginPage;
    private InventoryPage _inventoryPage;
    private TopBar _topBar;
    
    [OneTimeSetUp]
    public void BeforeTest()
    {
        _loginPage = new LoginPage(Driver);
        _inventoryPage = new InventoryPage(Driver);
        _topBar = new TopBar(Driver);
    }

    [Test]
    public void Logout()
    {
        Driver.Navigate().GoToUrl(SeleniumClient.GetActualAppSettings().BaseUrl);
        _loginPage.AssertPageIsLoaded();
        _loginPage.LoginWithUser("standard_user", "secret_sauce");
        
        _inventoryPage.AssertPageIsLoaded();
        _topBar.AssertTopBarIsLoaded();
        _topBar.ClickButtonOpenLeftMenuPanel();
        _topBar.LeftMenuPanel.AssertLeftMenuPanelIsLoaded();    
        _topBar.LeftMenuPanel.ClickLogoutButton();
        
        _loginPage.AssertPageIsLoaded();
    }
}