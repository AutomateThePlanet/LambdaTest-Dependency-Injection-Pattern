﻿namespace DepedencyInjectionPattern.FourthVersion;
public abstract class WebPage
{
    protected readonly IDriver Driver;

    public WebPage(IDriver driver)
    {
        Driver = driver;
    }
}
