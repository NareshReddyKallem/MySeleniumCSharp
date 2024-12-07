using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using POMFramework.TestData;
using POMFramework.Util;

namespace POMFramework.Base
{
    [SetUpFixture]
    public class BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            CommonUtil.KillBrowserDriverProcesses();
            ExtentUtil.CreateExtentReport();
            CommonUtil.CleanFiles();
        }

        [SetUp]
        public void Init()
        {
            string testCaseName = TestContext.CurrentContext.Test.Name;
            string testCaseDescription = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
            string testCaseCategory = TestContext.CurrentContext.Test.Properties.Get("Category").ToString();
            string testCaseAuthor = TestContext.CurrentContext.Test.Properties.Get("Author").ToString();

            ExtentUtil.CreateTest(testCaseName, testCaseDescription, testCaseCategory, testCaseAuthor);
            BrowserUtil.LaunchBrowser(GlobalTestData.browser);            
        }

        [TearDown]
        public void GetResults()
        {
            string errorMessage = TestContext.CurrentContext.Result.Message;
            string stackTrace = string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            string testCaseName = TestContext.CurrentContext.Test.Name;

            if (status.Equals(TestStatus.Failed))
            {
                string screenshotPath = CommonUtil.CaptureScreenshot();
                ExtentUtil.GetExtentTest().Fail(MarkupHelper.CreateLabel(testCaseName + " Test Case FAILED due to follwoing issues:", ExtentColor.Red));
                ExtentUtil.GetExtentTest().Fail(stackTrace + errorMessage);
                ExtentUtil.GetExtentTest().Fail("details",MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            else if (status.Equals(TestStatus.Passed))
            {
                ExtentUtil.GetExtentTest().Pass(MarkupHelper.CreateLabel(testCaseName + " Test Case PASSED", ExtentColor.Green));
            }
            else 
            {
                ExtentUtil.GetExtentTest().Skip(MarkupHelper.CreateLabel(testCaseName + " Test Case SKIPPED", ExtentColor.Orange));
                ExtentUtil.GetExtentTest().Skip(stackTrace + errorMessage);
            }

            BrowserUtil.CloseBrowser();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ExtentUtil.FlushReport();

            CommonUtil.CreateIndexFile();
            CommonUtil.CopyScreenshotFolder();
            
            // Close DB connections if you have any
        }
    }
}