using Unity;

namespace DepedencyInjectionPattern.FifthVersion;
public class WebSite
{
    private UnityContainer _container;
    private readonly IDriver _driver;

    public WebSite(IDriver driver)
    {
        _container = new UnityContainer();
        _driver = driver;

        _container.RegisterType<IHomePage, HomePage>();
        _container.RegisterType<IProductPage, ProductPage>();
        _container.RegisterType<ICartPage, CartPage>();
        _container.RegisterType<ICheckoutPage, CheckoutPage>();
        //HomePage = new HomePage(_driver);
        //ProductPage = new ProductPage(_driver);
        //CartPage = new CartPage(_driver);
        //CheckoutPage = new CheckoutPage(_driver);
    }

    //public HomePage HomePage { get; private set; }
    //public ProductPage ProductPage { get; private set; }
    //public CartPage CartPage { get; private set; }
    //public CheckoutPage CheckoutPage { get; private set; }
    public IHomePage HomePage => _container.Resolve<IHomePage>();
    public IProductPage ProductPage => _container.Resolve<IProductPage>();
    public ICartPage CartPage => _container.Resolve<ICartPage>();
    public ICheckoutPage CheckoutPage => _container.Resolve<ICheckoutPage>();
}
