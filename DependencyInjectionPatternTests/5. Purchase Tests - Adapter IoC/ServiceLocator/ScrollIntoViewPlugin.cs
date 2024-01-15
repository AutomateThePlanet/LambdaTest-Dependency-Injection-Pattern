using DepedencyInjectionPattern.FifthVersion;

namespace DepedencyInjectionPattern.SixthVersion;
public class ScrollIntoViewPlugin : IDriverPlugin
{
    public void OnComponentFound(IComponent component)
    {
        ScrollIntoView(component);
    }

    public void OnComponentsFound(List<IComponent> components)
    {
        if (components.Any())
        {
            ScrollIntoView(components.Last());
        }
    }

    private void ScrollIntoView(IComponent element)
    {
        var driver = ServiceLocator.Instance.GetService<IDriver>();
        var script = "arguments[0].scrollIntoView(true);";
        driver.ExecuteScript(script, element.WrappedElement);
    }
}
