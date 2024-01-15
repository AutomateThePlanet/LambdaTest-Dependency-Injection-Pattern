using DepedencyInjectionPattern.FifthVersion;

namespace DepedencyInjectionPattern.SixthVersion;
public interface IDriverPlugin
{
    public void OnComponentFound(IComponent component);
    public void OnComponentsFound(List<IComponent> components);
}
