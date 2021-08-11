using OpenQA.Selenium;
using System;

namespace HerokuAppTesting
{
    public class LoginPage
    {
        protected IWebDriver driver;

        public By usernameBy { get => By.Id("username"); }
        public By passwordBy { get => By.Id("password"); }
        public By submitButtonBy { get => By.ClassName("radius"); } //Is this a good locator?

        //private By usernameBy = By.Id("username");
        //private By passwordBy = By.Id("password");
        //private By submitButtonBy = By.ClassName("radius");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void loginUser(string userName, string password)
        {
            if (driver.FindElement(usernameBy) == null) Console.WriteLine("did not find element 'usernameBy'");
            driver.FindElement(usernameBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(submitButtonBy).Click();

                                        //Is this optimal, or just pass url or what?
            DriverHelper.Driver = driver; 
        }

    }


}
