using OpenQA.Selenium;
using System;

namespace HerokuAppTesting
{
    public class SecureAreaPage
    {
        protected IWebDriver driver;

        public By flashMessageBy { get => By.ClassName("flash success"); } 

        //private By flashMessageBy = By.ClassName("flash success");//!!!!!!!

        public SecureAreaPage(IWebDriver driver)
        {
            this.driver = driver;

            if (!driver.Title.Contains("The Internet"))
                throw new Exception("Wrong url, must be SecureArea, but it's: " + driver.Url);
        }

        public string getMessageText() => driver.FindElement(flashMessageBy).Text;

        public SecureAreaPage managePage()
        {
            return new SecureAreaPage(driver);
        }
    }
}
