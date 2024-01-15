using DepedencyInjectionPattern.FifthVersion;
using DepedencyInjectionPattern.Models;

namespace DepedencyInjectionPattern.FifthVersion;
public interface IProductPage
{
    IComponent AddToCartButton { get; }
    IComponent CompareButton { get; }
    IReadOnlyCollection<IComponent> CompareProductButtons { get; }
    IComponent QuantityField { get; }

    void AddToCart(string quantity);
    void AssertCompareProductDetails(ProductDetails expectedProduct, int index);
    void CompareLastProduct();
    void GoToComparePage();
    void SelectProductFromAutocomplete(int productId);
}
