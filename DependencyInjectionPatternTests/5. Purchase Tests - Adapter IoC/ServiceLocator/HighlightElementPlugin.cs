using DepedencyInjectionPattern.FifthVersion;

namespace DepedencyInjectionPattern.SixthVersion;
public class HighlightElementPlugin : IDriverPlugin
{
    public void OnComponentFound(IComponent component)
    {
        HighlightElement(component);
    }

    public void OnComponentsFound(List<IComponent> components)
    {
        if (components.Any())
        {
            HighlightElement(components.Last());
        }
    }

    private void HighlightElement(IComponent element)
    {
        try
        {
            // Get original styles
            var originalElementBackground = element.WrappedElement.GetCssValue("background");
            var originalElementColor = element.WrappedElement.GetCssValue("color");
            var originalElementOutline = element.WrappedElement.GetCssValue("outline");

            // JavaScript to modify and then revert the element's style
            var script = @"
                let defaultBG = arguments[0].style.backgroundColor;
                let defaultOutline = arguments[0].style.outline;
                arguments[0].style.backgroundColor = '#FDFF47';
                arguments[0].style.outline = '#f00 solid 2px';

                setTimeout(function()
                {
                    arguments[0].style.backgroundColor = defaultBG;
                    arguments[0].style.outline = defaultOutline;
                }, 500);";

            // can be moved to constructor injection, instead of interface we can use base class
            var driver = ServiceLocator.Instance.GetService<IDriver>();
            driver.ExecuteScript(script, element.WrappedElement);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
