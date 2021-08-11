using OpenQA.Selenium;

namespace HerokuAppTesting
{
    public class LoginPage
    {
        protected IWebDriver driver;
       
        private By usernameBy = By.Name("username");
        private By passwordBy = By.Name("password");
        private By submitButtonBy = By.ClassName("radius"); //Bad selector => specify it properly!!

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SecureAreaPage loginUser(string userName, string password)
        {
            driver.FindElement(usernameBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(submitButtonBy).Click();
            return new SecureAreaPage(driver);
        }

    }


}
