using OpenQA.Selenium;
using System;

namespace HerokuAppTesting
{
    public class SecureAreaPage
    {
        protected IWebDriver driver;

        private IWebElement successMessage;

        public By flashMessageBy { get => By.Id("flash"); }

        public SecureAreaPage(IWebDriver driver)
        {
            this.driver = driver;

            if (!driver.Title.Contains("The Internet"))
                throw new Exception("Wrong url, must be SecureArea, but it's: " + driver.Url);
            //Probably excessive, or need to catch Exception later in driver or test

            successMessage = driver.FindElement(flashMessageBy);
        }

        public string getMessageText() => successMessage.Text;

        //What is this for?
        public SecureAreaPage managePage()
        {
            return new SecureAreaPage(driver);
        }
    }
}
