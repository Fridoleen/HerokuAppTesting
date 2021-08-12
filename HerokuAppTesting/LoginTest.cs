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

        //[Test]
        //[AllureStep("Step One")]
        //public void GreetUser()
        //{
        //    Console.WriteLine("What's your bidding, master? There must be a screenshot of");
        //}

        [Test]
        [AllureStep("Test LigIn")]
        public void TestCaseOne()
        {
            DriverHelper.InitializeChrome("https://the-internet.herokuapp.com/login");

            DriverHelper.LogIn("tomsmith", "SuperSecretPassword!");

            string text = "You logged into a secure area!";
            Assert.AreEqual(DriverHelper.GetText().Contains(text), true);
        }

        [TearDown]
        public void AddAttachment()
        {
            AllureLifecycle.Instance.AddAttachment("TearDown", "image/png", DriverHelper.GetScreenShot(), @"screen.png");
            if (DriverHelper.Driver != null) DriverHelper.TearDown();
        }
    }
}
