using NUnit.Framework;
using QAFreecrm.Base;
using QAFreecrm.Pages;
using QAFreecrm.Tools;
using System;
using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class ContactsPageTests : TestBase
    {
        LoginPage loginPage;
        TestUtil testUtil;
        ContactsPage contactsPage;
        HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            Initialization(BrowserType.Firefox);
            loginPage = new LoginPage();
            testUtil = new TestUtil();
            contactsPage = new ContactsPage();
            homePage = loginPage.Login("eveyv4v", "77778888");
            testUtil.SwichToFrame();
            contactsPage = homePage.ClickOnContactsLinck();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        [Category("Smoke"), Category("Weekly")]
        public void VerifyContactsLabel()
        {
            try
            {
                bool flag = contactsPage.SelectPageLabel();

                Assert.That(flag, Is.EqualTo(true), "Label is not shown on the page");
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

        [Test]
        public void VerifyContactsByName()
        {
            try
            {
                contactsPage.SelectContactsByName("Evey");
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

    }
}
