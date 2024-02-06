using DepedencyInjectionPattern.FifthVersion;

namespace DepedencyInjectionPattern.SixthVersion;
public class WebSite
{
    //private UnityContainer _container;
    private readonly IDriver _driver;

    public WebSite(IDriver driver)
    {
        //_container = new UnityContainer();
        _driver = driver;


        // this can be moved to AssemblyInit instead
        ServiceLocator.Instance.RegisterInstance(_driver);
        // Registering plugins by interface
        ServiceLocator.Instance.Register<IDriverPlugin, ScrollIntoViewPlugin>();
        ServiceLocator.Instance.Register<IDriverPlugin, HighlightElementPlugin>();


        ServiceLocator.Instance.Register<IHomePage, HomePage>();
        ServiceLocator.Instance.Register<IProductPage, ProductPage>();
        ServiceLocator.Instance.Register<ICartPage, CartPage>();
        ServiceLocator.Instance.Register<ICheckoutPage, CheckoutPage>();
        //HomePage = new HomePage(_driver);
        //ProductPage = new ProductPage(_driver);
        //CartPage = new CartPage(_driver);
        //CheckoutPage = new CheckoutPage(_driver);
    }

    //public HomePage HomePage { get; private set; }
    //public ProductPage ProductPage { get; private set; }
    //public CartPage CartPage { get; private set; }
    //public CheckoutPage CheckoutPage { get; private set; }
    public IHomePage HomePage => ServiceLocator.Instance.GetService<IHomePage>();
    public IProductPage ProductPage => ServiceLocator.Instance.GetService<IProductPage>();
    public ICartPage CartPage => ServiceLocator.Instance.GetService<ICartPage>();
    public ICheckoutPage CheckoutPage => ServiceLocator.Instance.GetService<ICheckoutPage>();
}
