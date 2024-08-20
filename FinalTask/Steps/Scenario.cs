using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FinalTask.Features
{
    [Binding]
    public class Scenario
    {
        private readonly ScenarioContext _scenarioContext;

        public Scenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            IWebDriver driver = new FirefoxDriver();

            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void CleanUpWebDriver()
        {
            var driver = _scenarioContext["WebDriver"] as IWebDriver;
            driver?.Quit();
        }
    }
}