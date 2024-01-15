using DepedencyInjectionPattern.FifthVersion;

namespace DepedencyInjectionPattern.FifthVersion;
public class HomePage : WebPage, IHomePage
{
    public HomePage(IDriver driver)
        : base(driver)
    {
    }

    public IComponent SearchInput => Driver.FindComponent(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        //SearchInput.Clear();
        SearchInput.TypeText(searchText);
        //SearchInput.SendKeys(Keys.Enter);
    }
}
