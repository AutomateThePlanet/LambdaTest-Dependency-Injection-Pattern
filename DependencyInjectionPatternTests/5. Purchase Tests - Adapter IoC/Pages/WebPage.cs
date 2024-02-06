namespace DepedencyInjectionPattern.FifthVersion;
public abstract class WebPage
{
    protected readonly IDriver Driver;

    public WebPage(IDriver driver)
    {
        Driver = driver;
    }
}
