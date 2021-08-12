using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuAppTesting
{
    public static class DriverHelper
    {
        public static IWebDriver Driver { get; set; }

        public static void InitializeChrome(string url)
        {
            var Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            DriverHelper.Driver = Driver;
        }

        public static byte[] GetScreenShot() //check for file name conflict, or provide additional data to customize filename
        {
            var temp = (Driver as ITakesScreenshot);
            var screenshot = temp.GetScreenshot();
            return screenshot.AsByteArray;
        }

        public static void LogIn(string name, string pass)
        {            
            var loggerPage = new LoginPage(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loggerPage.loginUser(name, pass);
        }

        public static string GetText()
        {
            var securePage = new SecureAreaPage(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return securePage.getMessageText();
        }

        public static void TearDown()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Close();
        }

    }
}
