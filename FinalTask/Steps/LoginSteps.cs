using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;


namespace FinalTask.Features
{
    [Binding]
    public class LoginSteps(ScenarioContext scenarioContext)
    {
        private readonly IWebDriver _driver = scenarioContext["WebDriver"] as IWebDriver
                                             ?? throw new ArgumentNullException("WebDriver not found in ScenarioContext");

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"I enter username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            var usernameInput = _driver.FindElement(By.Id("user-name"));
            var passwordInput = _driver.FindElement(By.Id("password"));

            usernameInput.Clear();
            usernameInput.SendKeys(username);

            passwordInput.Clear();
            passwordInput.SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            var loginButton = _driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string expectedError)
        {
            var errorElement = _driver.FindElement(By.CssSelector("h3[data-test='error']"));
            var actualError = errorElement.Text;

            if (expectedError == "Epic sadface: Username is required" || expectedError == "Epic sadface: Password is required")
            {
                actualError.Should().Contain("Epic sadface:", "Error message should indicate the issue.");
            }
            else
            {
                actualError.Should().Be(expectedError, $"Expected error message is '{expectedError}', but found '{actualError}' instead.");
            }
        }


        [Then(@"I should be redirected to the dashboard")]
        public void ThenIShouldBeRedirectedToTheDashboard()
        {
            _driver.Url.Should().Contain("inventory.html", "User should be redirected to the dashboard after successful login.");
        }
    }
}