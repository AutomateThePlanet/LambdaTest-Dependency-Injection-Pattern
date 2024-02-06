namespace DepedencyInjectionPattern.FifthVersion;
public interface IHomePage
{
    IComponent SearchInput { get; }

    void SearchProduct(string searchText);
}
