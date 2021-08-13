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
        public By submitButtonBy { get => By.ClassName("radius"); } 

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            this.userName = driver.FindElement(usernameBy);
            this.password = driver.FindElement(passwordBy);
            this.submitButton = driver.FindElement(submitButtonBy);
        }

        public void loginUser(string userName, string password)
        {
            this.userName.Clear();
            this.userName.SendKeys(userName);

            this.password.Clear();
            this.password.SendKeys(password);

            this.submitButton.Click();
        }

    }


}
