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

        public static void MakeScreenShotPng(string name = "NewScreenshot") //check for name conflict, or provide additional data
        {
            Screenshot screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile(name + ".png", ScreenshotImageFormat.Png);
        }

    }
}
