using FluentAssertions;
using OpenQA.Selenium;
using NLog;

[TestClass]
public class LoginTests
{
    private IWebDriver? driver;
    private LoginPage? loginPage;
    private DashboardPage? dashboardPage;
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();


    [TestInitialize]
    public void Setup()
    {
        driver = DriverFactory.GetDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage = new LoginPage(driver);
        dashboardPage = new DashboardPage(driver);
    }

    [TestMethod]
    [DataRow("", "", "Epic sadface: Username is required")]
    [DataRow("standard_user", "", "Epic sadface: Password is required")]
    public void TestLoginForm(string username, string password, string expectedError)
    {
        logger.Info("Test started.");

        loginPage?.EnterUsername(username);
        loginPage?.EnterPassword(password);

        if (string.IsNullOrEmpty(username))
        {
            loginPage?.ClearUsername();
        }

        if (string.IsNullOrEmpty(password))
        {
            loginPage?.ClearPassword();
        }

        loginPage?.ClickLogin();

        if (!string.IsNullOrEmpty(expectedError))
        {
            var actualErrorMessage = loginPage?.GetErrorMessage();
            actualErrorMessage.Should().Be(expectedError, $"Expected error: '{expectedError}', but found '{actualErrorMessage}'");
            logger.Error($"Test failed: Expected error: '{expectedError}', Actual error: '{actualErrorMessage}'");
        }
        else
        {
            dashboardPage?.GetTitle().Should().Be("Swag Labs");
        }

        logger.Debug("Some debug information.");
        logger.Warn("A potential warning.");

        logger.Info("Test finished.");
    }
    [TestMethod]
    [DataRow("standard_user", "secret_sauce", "")]
    public void TestLoginWithValidCredentials(string username, string password, string expectedError)
    {
        logger.Info("Test started.");

        loginPage?.EnterUsername(username);
        loginPage?.EnterPassword(password);
        loginPage?.ClickLogin();

        if (string.IsNullOrEmpty(expectedError))
        {
            dashboardPage?.GetTitle().Should().Be("Swag Labs");
        }
        else
        {
            loginPage?.GetErrorMessage().Should().Be(expectedError);
        }

        logger.Debug("Some debug information.");
        logger.Warn("A potential warning.");

        logger.Info("Test finished.");
    }


    [TestCleanup]
    public void Cleanup()
    {
        driver?.Quit();
       
    }
}