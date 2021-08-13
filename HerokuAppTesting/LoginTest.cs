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
            Console.WriteLine("What's your bidding, master?");
            DriverHelper.InitializeChrome("https://the-internet.herokuapp.com/login");
        }

        [Test]
        [AllureStep("Test LigIn")]
        public void TestCaseOne()
        {
            DriverHelper.LogIn("tomsmith", "SuperSecretPassword!");

            string text = "You logged into a secure area!";
            Assert.AreEqual(DriverHelper.GetText().Contains(text), true);
        }
        [Test]
        [AllureStep("Finish")]
        public void CloseUp()
        {
            Console.WriteLine("We're done here");
        }

        [TearDown]
        public void AddAttachment()
        {
            if(DriverHelper.Driver != null) AllureLifecycle.Instance.AddAttachment("TearDown", "image/png", DriverHelper.GetScreenShot(), @"screen.png");
        }
    }
}
