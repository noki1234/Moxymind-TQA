using SeleniumTests.Pages;
using SeleniumTests.Pages.Navigation;

namespace SeleniumTests.Tests;

public class ItemOrderTest: SetupTestBase
{
    private LoginPage _loginPage;
    private InventoryPage _inventoryPage;
    private TopBar _topBar;
    private CartPage _cartPage;
    private CheckoutStepOnePage _checkoutStepOnePage;
    private CheckoutStepTwoPage _checkoutStepTwoPage;
    private CheckoutCompletePage _checkoutCompletePage;
    
    [OneTimeSetUp]
    public void BeforeTest()
    {
        _loginPage = new LoginPage(Driver);
        _inventoryPage = new InventoryPage(Driver);
        _topBar = new TopBar(Driver);
        _cartPage = new CartPage(Driver);
        _checkoutStepOnePage = new CheckoutStepOnePage(Driver);
        _checkoutStepTwoPage = new CheckoutStepTwoPage(Driver);
        _checkoutCompletePage = new CheckoutCompletePage(Driver);
    }

    [Test]
    public void CreateAndFinishOrderProcess()
    {
        Driver.Navigate().GoToUrl(SeleniumClient.GetActualAppSettings().BaseUrl);
        _loginPage.AssertPageIsLoaded();
        _loginPage.LoginWithUser("standard_user", "secret_sauce");
        
        _inventoryPage.AssertPageIsLoaded();
        // Assert cart is empty - badge is hidden 
        _topBar.AssertShoppingCartCountBadgeIsHidden();
        // Add item to cart and assert badge is visible with correct count
        _inventoryPage.AssertItemWithPriceDisplayed("Sauce Labs Bike Light", "$9.99");
        _inventoryPage.ClickButtonItemAddToCart("Sauce Labs Bike Light");
        _topBar.AssertShoppingCartCountBadge(1);
        _topBar.ClickButtonOpenShoppingCart();
        
        _cartPage.AssertPageIsLoaded();
        _cartPage.AssertItemWithPriceDisplayed("Sauce Labs Bike Light", "$9.99");
        _cartPage.ClickButtonCheckout();
        
        _checkoutStepOnePage.AssertPageIsLoaded();
        _checkoutStepOnePage.SetMandatoryValues("John", "Doe", "04011");
        _checkoutStepOnePage.ClickButtonContinue();
        
        _checkoutStepTwoPage.AssertPageIsLoaded();
        _checkoutStepTwoPage.AssertItemWithPriceDisplayed("Sauce Labs Bike Light", "$9.99");
        _checkoutStepTwoPage.ClickButtonFinish();
        
        _checkoutCompletePage.AssertPageIsLoaded();
        _checkoutCompletePage.AssertOrderIsSuccess();
        _checkoutCompletePage.ClickBackHomeButton();
        
        _inventoryPage.AssertPageIsLoaded();
        // Assert cart cleared after order - badge is hidden
        _topBar.AssertShoppingCartCountBadgeIsHidden(); 
    }
    
    [Test]
    public void RemoveOrderProcessFromCart()
    {
        Driver.Navigate().GoToUrl(SeleniumClient.GetActualAppSettings().BaseUrl);
        _loginPage.LoginWithUser("standard_user", "secret_sauce");
        
        _inventoryPage.AssertPageIsLoaded();
        // Assert cart is empty - badge is hidden 
        _topBar.AssertShoppingCartCountBadgeIsHidden();
        _inventoryPage.AssertItemWithPriceDisplayed("Sauce Labs Bike Light", "$9.99");
        _inventoryPage.ClickButtonItemAddToCart("Sauce Labs Bike Light");
        _topBar.AssertShoppingCartCountBadge(1);
        
        // Assert its possible to remove item from cart - from inventory page
        _inventoryPage.ClickButtonItemRemoveFromCart("Sauce Labs Bike Light");
        _topBar.AssertShoppingCartCountBadgeIsHidden();
        
        // Add item to cart again
        _inventoryPage.ClickButtonItemAddToCart("Sauce Labs Bike Light");
        _topBar.ClickButtonOpenShoppingCart();
        _cartPage.AssertPageIsLoaded();
        _cartPage.AssertItemWithPriceDisplayed("Sauce Labs Bike Light", "$9.99");
        
        // Assert its possible to remove item from cart - from cart page
        _cartPage.ClickButtonItemRemoveFromCart("Sauce Labs Bike Light");
        _cartPage.AssertCartIsEmpty();
        _topBar.AssertShoppingCartCountBadgeIsHidden();
    }
}