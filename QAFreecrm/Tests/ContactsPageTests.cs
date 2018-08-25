using NUnit.Framework;
using QAFreecrm.Base;
using QAFreecrm.Pages;
using QAFreecrm.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class ContactsPageTests:TestBase
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
        }

        [Test]
        public void VerifyContactsLabel()
        {
            bool flag = contactsPage.SelectPageLabel();

            Assert.That(flag, Is.EqualTo(true), "Label is not shown on the page");
        }

        [Test]
        public void VerifyContactsByName()
        {
            contactsPage.SelectContactsByName("Evey");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
