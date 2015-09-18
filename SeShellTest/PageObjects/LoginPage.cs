using SeShell.Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.PageObjects
{

    class LoginPage
    {

        public static String usernameElement()
        {
            return LoginPageResources.usernameTextboxId;
        }

        public static String passwordElement()
        {
            return LoginPageResources.passwordTextboxId;
        }

        public static String loginElement()
        {
            return LoginPageResources.loginButtonXpath;
        }

    }

}
