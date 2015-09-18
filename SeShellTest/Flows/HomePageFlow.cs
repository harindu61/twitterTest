using OpenQA.Selenium;
using SeShell.Test.Core;
using SeShell.Test.Enums;
using SeShell.Test.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeShell.Test.Flows
{
    class HomePageFlow : BaseClass
    {
        public HomePageFlow(IWebDriver driver)
        {
            Driver = driver;
            new LoginPageFlow(Driver);
        }

        public void tweetMessage(String message)
        {
            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.XPath, HomePage.newTweetText());

            IWebElement newTweetText = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, HomePage.newTweetText());
            Utilities.ClearElements(new IWebElement[] { newTweetText });

            newTweetText.SendKeys(message);

            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.XPath, HomePage.postTweetButton());
            Utilities.FindElement(this.Driver, HtmlElementBy.XPath, HomePage.postTweetButton()).Click();
        }

        public bool verifyMessage(String expectedMessage)
        {
            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.XPath, HomePage.postedTweetText());
            string actualUsersName = Utilities.FindElement(base.Driver, HtmlElementBy.XPath, HomePage.postedTweetText()).Text;

            return actualUsersName == expectedMessage ? true : false;
        }

        public bool userLoggedIn(String expectedResult)
        {
            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.XPath, HomePage.veriryLogin());
            string actualUsersName = Utilities.FindElement(base.Driver, HtmlElementBy.XPath, HomePage.veriryLogin()).Text;
            
            return actualUsersName == expectedResult ? true : false;
        }
    }
}