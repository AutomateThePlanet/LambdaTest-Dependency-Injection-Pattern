namespace DepedencyInjectionPattern.FifthVersion;

public interface ICartPage
{
    IComponent ViewCartButton { get; }
    IComponent CheckoutButton { get; }
    List<IComponent> CartItems { get; }
    IComponent TotalPrice { get; }

    void ViewCart();
    void Checkout();
    void UpdateQuantity(int itemIndex, int quantity);
    void RemoveItem(int itemIndex);
    void AssertTotalPrice(string expectedPrice);
}
