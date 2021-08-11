using OpenQA.Selenium;

namespace HerokuAppTesting
{
    public class LoginPage
    {
        protected IWebDriver driver;
       
        public By usernameBy { get => By.Name("username"); }
        public By passwordBy { get => By.Name("password"); }
        public By submitButtonBy { get => By.ClassName("radius"); } //Is this a good locator?

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void loginUser(string userName, string password)
        {
            driver.FindElement(usernameBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(submitButtonBy).Click();

                                        //Is this optimal, or just pass url or what?
            DriverHelper.Driver = driver; 
        }

    }


}
