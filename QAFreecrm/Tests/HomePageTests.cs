using NUnit.Framework;
using QAFreecrm.Base;
using QAFreecrm.Pages;
using QAFreecrm.Tools;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class HomePageTests:TestBase
    {
        HomePage homePage;
        LoginPage loginPage;
        TestUtil testUtil;
        readonly string TITLE = "CRMPRO";

        [SetUp]
        public void SetUp()
        {
            Initialization(BrowserType.Firefox);
            homePage = new HomePage();
            loginPage = new LoginPage();
            testUtil = new TestUtil();
            loginPage.Login("eveyv4v","77778888");
            testUtil.SwichToFrame();
        }

        [Test]
        public void ValidateHomePageTitle()
        {
            string title = homePage.ValidateHomePageTitle();

            Assert.AreEqual(title, TITLE);
        }

        [Test]
        public void CrmLogoTest()
        {
            bool flag = homePage.ValidateUserLable();
            Assert.That(flag, Is.EqualTo(true),
                "Logo does not exist");
        }

        [Test]
        public void LogOut()
        {           
            loginPage = homePage.Logout();
            bool flag = loginPage.ValidateCRMImage();
            Assert.That(flag, Is.EqualTo(true),
            "Logo does not exist, we did not return to the login page");
        }

        [Test]
        public void ClickOnContactsLink()
        {           
            homePage.ClickOnContactsLinck();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
