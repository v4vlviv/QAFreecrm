using QAFreecrm.Base;
using NUnit.Framework;
using QAFreecrm.Pages;
using QAFreecrm.Tools;
using System.Collections.Generic;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System;

namespace QAFreecrm.Tests
{
    [TestFixture]
    class LoginPageTests : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        TestUtil testUtil;

        readonly string TITLE = "#1 Free CRM software in the cloud for sales and service";
        static readonly string PATH = @"D:\C#_TestProject\QAFreecrm\QAFreecrm\TestData\TestDataCsv.csv";



        [SetUp]
        public void SetUp()
        {
            Initialization(BrowserType.Firefox);
            loginPage = new LoginPage();
            testUtil = new TestUtil();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ValidateLoginPageTitle()
        {
            try
            {
                string title = loginPage.ValidateLoginTitle();
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
                bool flag = loginPage.ValidateCRMImage();
                Assert.That(flag, Is.EqualTo(true),
               "Logo does not exist");
            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }
        }


        [Test, TestCaseSource("GetDataFromCSVtoLoginTest")]
        public void LoginTest(string login, string password)
        {
            try
            {
                homePage = loginPage.Login(login, password);

                testUtil.SwichToFrame();
                bool flag = homePage.ValidateUserLable();

                Assert.That(flag, Is.EqualTo(true),
                "Its not a home page");

            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                test.Fail(ex.Message);
            }

        }
        public static IEnumerable<string[]> GetDataFromCSVtoLoginTest()
        {
            Tools.CsvReader reader = new Tools.CsvReader(PATH);
            while (reader.Next())
            {
                string login = reader[0];
                string password = reader[1];
                yield return new string[] { login, password };
            }
        }
    }
}
