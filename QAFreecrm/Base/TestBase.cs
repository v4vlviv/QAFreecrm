using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;

namespace QAFreecrm.Base
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Opera,
        IE
    }

    class TestBase
    {

        public static IWebDriver driver;
        public static readonly int TIMESPAN = 20;
        public static readonly int TIMEWAIT = 10;
        public static readonly string URL = "https://www.freecrm.com/index.html";

        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        protected void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public static void Initialization(BrowserType browserType)
        {
            ChooseDriverInstance(browserType);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TIMESPAN);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEWAIT);

            driver.Navigate().GoToUrl(URL);
        }

        private static void ChooseDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    {
                        driver = new ChromeDriver();
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                        service.HideCommandPromptWindow = true;
                        service.SuppressInitialDiagnosticInformation = true;                      
                        driver = new FirefoxDriver(service);
                        break;
                    }
                case BrowserType.Opera:
                    {
                        driver = new OperaDriver();
                        break;
                    }
                case BrowserType.IE:
                    {
                        driver = new InternetExplorerDriver();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option");
                        break;
                    }
            }
        }
    }
}
