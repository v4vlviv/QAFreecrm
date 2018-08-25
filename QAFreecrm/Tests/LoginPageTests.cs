using QAFreecrm.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAFreecrm.Pages;
using QAFreecrm.Tools;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class LoginPageTests : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        TestUtil testUtil;
        readonly string TITLE = "#1 Free CRM software in the cloud for sales and service";

        [SetUp]
        public void SetUp()
        {
            Initialization(BrowserType.Firefox);
            loginPage = new LoginPage();
            testUtil = new TestUtil();
        }

        [Test]
        public void ValidateLoginPageTitle()
        {
            string title = loginPage.ValidateLoginTitle();

            Assert.AreEqual(title, TITLE);
        }

        [Test]
        public void CrmLogoTest()
        {
            bool flag = loginPage.ValidateCRMImage();
            Assert.That(flag, Is.EqualTo(true), 
                "Logo does not exist");
        }

        [Test]
        public void LoginTest()
        {
            homePage = loginPage.Login("eveyv4v", "77778888");

            testUtil.SwichToFrame();
            bool flag = homePage.ValidateUserLable();

            Assert.That(flag, Is.EqualTo(true),
            "Its not a home page");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
