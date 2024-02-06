using ChainOfResponsibility.Models;
using Unity;

namespace DepedencyInjectionPattern.FifthVersion;

[TestFixture]
public class ProductPurchaseFacadeTests
{
    private IDriver _driver;
    private WebSite _webSite;
    private UnityContainer _container;
    private PurchaseFacade _purchaseFacade;

    [SetUp]
    public void TestInit()
    {
        _container = new UnityContainer();
        _driver = new DriverAdapter();
        _driver.Start(Browser.Chrome);
        _container.RegisterInstance(_driver);
        _webSite = new WebSite(_driver);
        _purchaseFacade = _container.Resolve<PurchaseFacade>();
        _driver.GoToUrl("https://ecommerce-playground.lambdatest.io/");
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }
   
    [Test]
    public void PurchaseTwoSameProduct()
    {
        var expectedProduct = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg",
            Quantity = "2"
        };

        var userDetails = new UserDetails
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Telephone = "1234567890",
            Password = "password123",
            ConfirmPassword = "password123",
            AccountType = AccountOption.Register
        };

        var billingAddress = new BillingAddress
        {
            FirstName = "John",
            LastName = "Doe",
            Company = "Acme Corp",
            Address1 = "123 Main St",
            Address2 = "Apt 4",
            City = "Metropolis",
            PostCode = "12345",
            Country = "United States",
            Region = "Alabama"
        };

        //_webSite.HomePage.SearchProduct("ip");
        //_webSite.ProductPage.SelectProductFromAutocomplete(expectedProduct1.Id);
        //_webSite.ProductPage.AddToCart(expectedProduct1.Quantity);
        //_webSite.CartPage.ViewCart();
        //_webSite.CartPage.AssertTotalPrice("$388.00");

        //_webSite.CartPage.Checkout();
        //_webSite.CheckoutPage.FillUserDetails(userDetails);
        //_webSite.CheckoutPage.FillBillingAddress(billingAddress);
        //_webSite.CheckoutPage.AssertTotalPrice("$396.00");

        //_webSite.CheckoutPage.AgreeToTerms();
        //_webSite.CheckoutPage.CompleteCheckout();


        _purchaseFacade.PurchaseProduct("ip", expectedProduct, userDetails, billingAddress, "$388.00", "$396.00");
    }
}
