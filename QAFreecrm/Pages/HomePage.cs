using QAFreecrm.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace QAFreecrm.Pages
{
    class HomePage: DriverInit
    {
        [FindsBy(How = How.XPath, Using = "//td[contains(text(), 'User:')]")]
        IWebElement userNameLabel;

        [FindsBy(How = How.XPath, Using = "//ul[@class='mlddm']/li/a[contains(text(), 'Contacts')]")]
        IWebElement contactLink;


        [FindsBy(How = How.XPath, Using = "//ul[@class='mlddm']/li/a[contains(text(), 'Deals')]")]
        IWebElement dealLink;

        [FindsBy(How = How.XPath, Using = "//ul[@class='mlddm']/li/a[contains(text(), 'Tasks')]")]
        IWebElement taskLink;

        //Change this Xpath
        [FindsBy(How = How.XPath, Using = "//td/a[contains(text(), 'Logout')]")]
        IWebElement logOut;

        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }

        public string ValidateHomePageTitle()
        {
            return driver.Title;
        }

        public bool ValidateUserLable()
        {
            return userNameLabel.Displayed;
        }
        public LoginPage Logout()
        {
            logOut.Click();
            return new LoginPage();
        }

        public ContactsPage ClickOnContactsLinck()
        {
            contactLink.Click();
            return new ContactsPage();
        }

        public DealsPage ClickOnDealsLinck()
        {
            dealLink.Click();
            return new DealsPage();
        }

        public TaskPage ClickOnTaskLinck()
        {
            taskLink.Click();
            return new TaskPage();
        }

    }
}
