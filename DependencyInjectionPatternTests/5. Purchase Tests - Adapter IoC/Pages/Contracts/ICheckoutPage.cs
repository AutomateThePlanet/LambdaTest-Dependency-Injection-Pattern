using ChainOfResponsibility.Models;

namespace DepedencyInjectionPattern.FifthVersion;
public interface ICheckoutPage
{
    IComponent Address1Input { get; }
    IComponent Address2Input { get; }
    IComponent BillingAddressRegionSelect { get; }
    IComponent CityInput { get; }
    IComponent CompanyInput { get; }
    IComponent ConfirmPasswordInput { get; }
    IComponent ContinueButton { get; }
    IComponent EmailInput { get; }
    IComponent FirstNameInput { get; }
    IComponent LastNameInput { get; }
    IComponent PasswordInput { get; }
    IComponent PostCodeInput { get; }
    IComponent ShippingAddressCountrySelect { get; }
    IComponent TelephoneInput { get; }
    IComponent TermsAgreeCheckbox { get; }
    IComponent TotalPrice { get; }

    void AgreeToTerms();
    void AssertTotalPrice(string expectedPrice);
    IComponent BillingAddressRegionOption(string region);
    void ClickContinue();
    void CompleteCheckout();
    void FillBillingAddress(BillingAddress billingAddress);
    void FillUserDetails(UserDetails userDetails);
    IComponent ShippingAddressCountryOption(string country);
}
