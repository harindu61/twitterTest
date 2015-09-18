using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeShell.Test.Core;
using SeShell.Test.Flows;
using SeShell.Test.TestData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeShell.Test.TestCases
{
    class LoginTest : AbstractTest
    {
        [Test, TestCaseSource(typeof(LoginData), "GetLoginTestData")]
        public void LoginTwitter(LoginData data)
        {
            string currentExecutingMethod = Utilities.GetCurrentMethod();
            var resultsWriter = new ResultsWriter(Constants.ParameterizedTest, currentExecutingMethod, true);
            //var loginTestData = FBLoginData.GetLoginTestCases();

            Parallel.ForEach(WebDrivers, (driver, loopState) =>
            {
                var testAsserter = new TestCaseAsserts();
                string currentWebBrowserString = Utilities.GetWebBrowser(driver);
                //FBLoginData data = Utilities.GetBrowserBasedLoginCredentials(driver);


                ResultReport testResultReport = new ResultReport();
                string testFixtureName = Utilities.GenerateTestFixtureName(this.GetType(), currentExecutingMethod,
                currentWebBrowserString);
                testResultReport.StartMethodTimerAndInitiateCurrentTestCase(testFixtureName, true);
                try
                {
                    LoginPageFlow loginPageflow = new LoginPageFlow(driver);
                    HomePageFlow homePageFlow = loginPageflow.login(data.username, data.password);

                    testAsserter.AddBooleanAssert(
                        new Action<bool, string>(Assert.IsTrue),
                        homePageFlow.userLoggedIn(data.expectedResult),
                        Utilities.CombineTestOutcomeString(Constants.SuccessfulUserLogin, data.expectedResult));
                    testResultReport.SetCurrentTestCaseOutcome(true, testAsserter.AssertionCount.ToString());
                }
                catch (Exception e)
                {
                    string screenShotIdentifier = String.Format("{0} - {1}", data.username, currentExecutingMethod);
                    base.HandleException(e, screenShotIdentifier, driver, testResultReport, testAsserter, resultsWriter);
                    Assert.Fail("***** LoginTwitter Failed *****");
                }
                finally
                {
                    testResultReport.StopMethodTimerAndFinishCurrentTestCase();
                    base.TestCases.Add(testResultReport.currentTestCase);
                }
            });

            resultsWriter.WriteResultsToFile(this.GetType().Name, TestCases);
        }

        [Test, TestCaseSource(typeof(TweetMessageData), "GetTweetMessageData")]
        public void TweetMessage(TweetMessageData data)
        {
            string currentExecutingMethod = Utilities.GetCurrentMethod();
            var resultsWriter = new ResultsWriter(Constants.ParameterizedTest, currentExecutingMethod, true);
            //var loginTestData = FBLoginData.GetLoginTestCases();

            Parallel.ForEach(WebDrivers, (driver, loopState) =>
            {
                var testAsserter = new TestCaseAsserts();
                string currentWebBrowserString = Utilities.GetWebBrowser(driver);
                //FBLoginData data = Utilities.GetBrowserBasedLoginCredentials(driver);


                ResultReport testResultReport = new ResultReport();
                string testFixtureName = Utilities.GenerateTestFixtureName(this.GetType(), currentExecutingMethod,
                currentWebBrowserString);
                testResultReport.StartMethodTimerAndInitiateCurrentTestCase(testFixtureName, true);
                try
                {
                    LoginPageFlow loginPageflow = new LoginPageFlow(driver);
                    HomePageFlow homePageFlow = loginPageflow.login(data.username, data.password);
                    String message = data.message + DateTime.Now.ToString("hh:mm:ss");
                    homePageFlow.tweetMessage(message);
                    Thread.Sleep(5000);
                    
                    testAsserter.AddBooleanAssert(
                        new Action<bool, string>(Assert.IsTrue),
                        homePageFlow.verifyMessage(message),
                        Utilities.CombineTestOutcomeString(Constants.SuccessfulTweetPost, message));
                    testResultReport.SetCurrentTestCaseOutcome(true, testAsserter.AssertionCount.ToString());
                }
                catch (Exception e)
                {
                    string screenShotIdentifier = String.Format("{0} - {1}", data.username, currentExecutingMethod);
                    base.HandleException(e, screenShotIdentifier, driver, testResultReport, testAsserter, resultsWriter);
                    Assert.Fail("***** Post Tweet Failed *****");
                }
                finally
                {
                    testResultReport.StopMethodTimerAndFinishCurrentTestCase();
                    base.TestCases.Add(testResultReport.currentTestCase);
                }
            });

            resultsWriter.WriteResultsToFile(this.GetType().Name, TestCases);
        }

    }
}