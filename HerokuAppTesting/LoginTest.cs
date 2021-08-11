using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Allure.Steps;
using NUnit.Framework;
using System;

namespace HerokuAppTesting
{
    
    [TestFixture(Author = "fridoleen", Description = "test Login page")]
    [AllureNUnit]
    class LoginTest
    {
        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [Test]
        [AllureStep("Step One")]
        public void GreetUser()
        {
            Console.WriteLine("What's your bidding, master? There must be a screenshot of");
        }

        [Test]
        [AllureStep("Test LigIn")]
        public void TestCaseOne()
        {
            DriverHelper.InitializeChrome("https://the-internet.herokuapp.com/login");
            var loginPage = new LoginPage(DriverHelper.Driver);
            loginPage.loginUser("tomsmith", "SuperSecretPassword!");

            var secureAreaPage = new SecureAreaPage(DriverHelper.Driver);
            string text = "You logged into a secure area!";
            Assert.AreEqual(secureAreaPage.getMessageText().Contains(text), true);
        }
    }
}
