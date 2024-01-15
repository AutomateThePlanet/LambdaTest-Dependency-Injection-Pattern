using DepedencyInjectionPattern.FifthVersion;
using DepedencyInjectionPattern.Models;

namespace DepedencyInjectionPattern;

public class PurchaseFacade
{
    private IHomePage _homePage;
    private ICartPage _cartPage;
    private ICheckoutPage _checkoutPage;
    private IProductPage _productPage;

    public PurchaseFacade(
        IHomePage homePage, 
        ICartPage cartPage, 
        ICheckoutPage checkoutPage, 
        IProductPage productPage)
    {
        _homePage = homePage;
        _cartPage = cartPage;
        _checkoutPage = checkoutPage;
        _productPage = productPage;
    }

    public void PurchaseProduct(
        string searchPhase, 
        ProductDetails product, 
        UserDetails userDetails, 
        BillingAddress billingAddress, 
        string expectedCartTotal,
        string expectedCheckoutTotal)
    {
        _homePage.SearchProduct(searchPhase);
        _productPage.SelectProductFromAutocomplete(product.Id);
        _productPage.AddToCart(product.Quantity);
        _cartPage.ViewCart();
        _cartPage.AssertTotalPrice(expectedCartTotal);

        _cartPage.Checkout();
        _checkoutPage.FillUserDetails(userDetails);
        _checkoutPage.FillBillingAddress(billingAddress);
        _checkoutPage.AssertTotalPrice(expectedCheckoutTotal);

        _checkoutPage.AgreeToTerms();
        _checkoutPage.CompleteCheckout();
    }
}
