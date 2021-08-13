using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HerokuAppTesting
{
    public static class DriverHelper
    {
        public static IWebDriver Driver { get; set; }

        public static void InitializeChrome(string url)
        {
            var Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(url);
            DriverHelper.Driver = Driver;
        }

        public static byte[] GetScreenShot()
        {
            var temp = (Driver as ITakesScreenshot);
                var screenshot = temp.GetScreenshot();
            return screenshot.AsByteArray;
        }

        public static void LogIn(string name, string pass)
        {            
            var loggerPage = new LoginPage(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            loggerPage.loginUser(name, pass);
        }

        public static string GetText()
        {
            var securePage = new SecureAreaPage(Driver);
            return securePage.getMessageText();
        }

        public static void TearDown()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Close();
        }

    }
}
