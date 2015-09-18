using OpenQA.Selenium;
using SeShell.Test.Core;
using SeShell.Test.Enums;
using SeShell.Test.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.Flows
{
    class LoginPageFlow : BaseClass
    {

        public LoginPageFlow(IWebDriver driver)
        {
            base.SetWebDriverInstance(driver);
            NavigateTo(String.Empty);
        }

        public HomePageFlow login(String username, String password)
        {
            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.Id, LoginPage.usernameElement());
            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.Id, LoginPage.passwordElement());

            IWebElement usernameText = Utilities.FindElement(this.Driver, HtmlElementBy.Id, LoginPage.usernameElement());
            IWebElement passwordText = Utilities.FindElement(this.Driver, HtmlElementBy.Id, LoginPage.passwordElement());

            Utilities.ClearElements(new IWebElement[] { usernameText, passwordText });

            usernameText.SendKeys(username);
            passwordText.SendKeys(password);

            Utilities.WaitTillDisplayed(this.Driver, HtmlElementBy.XPath, LoginPage.loginElement());
            Utilities.FindElement(this.Driver, HtmlElementBy.XPath, LoginPage.loginElement()).Click();

            return new HomePageFlow(Driver);
        }

    }
}
