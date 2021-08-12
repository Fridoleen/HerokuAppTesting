using OpenQA.Selenium;
using System;

namespace HerokuAppTesting
{
    public class LoginPage
    {
        protected IWebDriver driver;

        private IWebElement userName;
        private IWebElement password;
        private IWebElement submitButton;

        public By usernameBy { get => By.Name("username"); }
        public By passwordBy { get => By.Name("password"); }
        public By submitButtonBy { get => By.ClassName("radius"); } //Is this a good locator?

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            this.userName = DriverHelper.Driver.FindElement(usernameBy);
            this.password = DriverHelper.Driver.FindElement(passwordBy);
            this.submitButton = DriverHelper.Driver.FindElement(submitButtonBy);
        }

        public void loginUser(string userName, string password)
        {
            this.userName.Clear();
            this.userName.SendKeys(userName);

            this.password.Clear();
            this.password.SendKeys(password);

            this.submitButton.Click();

            //Is this optimal, or just pass url or what?
            //DriverHelper.Driver = driver; 
        }

    }


}
