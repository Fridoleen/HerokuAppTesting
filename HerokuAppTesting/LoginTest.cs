using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
        }

        public void TestCaseOne()
        {

        }
    }
}
