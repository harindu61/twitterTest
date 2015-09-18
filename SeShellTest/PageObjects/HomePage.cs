using SeShell.Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.PageObjects
{
    class HomePage
    {

        public static String veriryLogin()
        {
            return HomePageResources.verifyAccountName;
        }

        public static String newTweetButton()
        {
            return HomePageResources.newTweetButton;
        }

        public static String newTweetText()
        {
            return HomePageResources.newTweetText;
        }

        public static String postTweetButton()
        {
            return HomePageResources.postNewTweetButton;
        }

        public static String postedTweetText()
        {
            return HomePageResources.postedTweetText;
        }

    }
}
