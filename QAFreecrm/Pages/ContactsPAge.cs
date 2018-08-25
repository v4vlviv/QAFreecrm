using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QAFreecrm.Base;

namespace QAFreecrm.Pages
{
    class ContactsPage: TestBase
    {

        [FindsBy(How = How.XPath, Using = "//td[contains(text(), 'Contacts')]")]
        IWebElement pageLabel;


        //[FindsBy(How = How.XPath, Using = "//td/a[contains(text(), '"+ name +"')]")]
        //IWebElement userInTable;

        public ContactsPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public bool SelectPageLabel()
        {
            return pageLabel.Displayed;
        }

        public void SelectContactsByName(string name)
        {
            driver.FindElement(By.XPath("//td/a[contains(text(), '"+ name +"')]"));
        }
    }
}
