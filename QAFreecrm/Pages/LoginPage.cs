using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QAFreecrm.Base;
using System.Threading;


namespace QAFreecrm.Pages
{
    class LoginPage : TestBase
    {

        [FindsBy(How = How.Name, Using = "username")]
        IWebElement usernameField;


        [FindsBy(How = How.Name, Using = "password")]
        IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        IWebElement loginButton;


        [FindsBy(How = How.XPath, Using = "//a/font[contains(text(), 'Sign Up')]")]
        IWebElement signUpButton;

        [FindsBy(How = How.CssSelector, Using = "div.navbar-header a img")]
        IWebElement crmLogo;


        //Initializing the Page Object
        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }


        //Actions
        public string ValidateLoginTitle()
        {
            return driver.Title;
        }

        public bool ValidateCRMImage()
        {
            return crmLogo.Displayed;
        }

        public HomePage Login(string username , string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            Thread.Sleep(2000);
            loginButton.Click();
            return new HomePage();
        }
        
    }

}
