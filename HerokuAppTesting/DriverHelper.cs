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
        }

        public static byte[] GetScreenShot() //check for file name conflict, or provide additional data to customize filename
        {
            Screenshot screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            return screenshot.AsByteArray;
        }

        public static void LogIn(string name, string pass)
        {
            if (Driver == null) Console.WriteLine("All got bad");
            Driver.Close();
            var loggerPage = new LoginPage(Driver);
            loggerPage.loginUser(name, pass);
        }

        public static string GetText()
        {
            var securePage = new SecureAreaPage(Driver);
            return securePage.getMessageText();
        }

        public static void TearDown()
        {
            Driver.Close();
        }

    }
}
