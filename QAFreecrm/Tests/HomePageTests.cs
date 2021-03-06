﻿using NUnit.Framework;
using QAFreecrm.Base;
using QAFreecrm.Pages;
using QAFreecrm.Tools;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class HomePageTests : TestBase
    {
        HomePage homePage;
        LoginPage loginPage;
        TestUtil testUtil;
        BrowserType _browserType;

        readonly string TITLE = "CRMPRO";

        [SetUp]
        public void SetUp()
        {
            var browserType = TestContext.Parameters.Get("Browser", "Chrome");
            //Parse the browser Type, since its Enum
            _browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browserType);
            //Pass it to browser
            Initialization(_browserType);

            //Initialization(BrowserType.Chrome);
            homePage = new HomePage();
            loginPage = new LoginPage();
            testUtil = new TestUtil();
            loginPage.Login("eveyv4v", "77778888");
            testUtil.SwichToFrame();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ValidateHomePageTitle()
        {
            try
            {
                string title = homePage.ValidateHomePageTitle();

                Assert.AreEqual(title, TITLE);
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

        [Test]
        public void CrmLogoTest()
        {
            try
            {
                bool flag = homePage.ValidateUserLable();
                Assert.That(flag, Is.EqualTo(true),
                    "Logo does not exist");
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

        [Test]
        public void LogOut()
        {
            try
            {
                loginPage = homePage.Logout();
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

        [Test]
        public void ClickOnContactsLink()
        {
            try
            {
                homePage.ClickOnContactsLinck();
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }

    }
}
