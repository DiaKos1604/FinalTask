using OpenQA.Selenium;

public class DashboardPage
{
    private IWebDriver _driver;

    public DashboardPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public string GetTitle()
    {
        return _driver.Title;
    }
}