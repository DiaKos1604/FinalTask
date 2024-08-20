using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

public static class DriverFactory
{
    public static IWebDriver GetDriver()
    {
        FirefoxOptions options = new FirefoxOptions();
        IWebDriver driver = new FirefoxDriver(options);

        driver.Manage().Window.Maximize();
        return driver;
    }
}