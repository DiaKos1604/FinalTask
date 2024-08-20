using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement UsernameField => _driver.FindElement(By.XPath("//input[@id='user-name']"));
    private IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@id='password']"));
    private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@id='login-button']"));
    private IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3[@data-test='error']"));

    public void EnterUsername(string username)
    {
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.SendKeys(password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }

    public void ClearUsername()
    {
        UsernameField.Clear();
    }

    public void ClearPassword()
    {
        PasswordField.Clear();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}