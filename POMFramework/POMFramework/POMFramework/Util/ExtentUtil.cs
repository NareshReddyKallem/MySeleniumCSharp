using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System;
using System.Threading;

namespace POMFramework.Util
{
    public class ExtentUtil
    {
        static ThreadLocal<ExtentTest> EXTENT = new ThreadLocal<ExtentTest>();

        static ExtentReports ExtentReports;
        static ExtentSparkReporter ExtentHtmlReporter;
        static ExtentTest ExtentTest;
        //static string ReportFolder;
        static string resultFile;
        
        public static ExtentTest GetExtentTest()
        {
            return EXTENT.Value;
        }

        public static void SetExtentTest(ExtentTest ExtentTest)
        {
            EXTENT.Value = ExtentTest;
        }

        public static void CreateExtentReport()
        {
            resultFile = CommonUtil.PrepareReportsDirectory();
            if (ExtentReports == null)
            {
                //ReportFolder = CommonUtil.GetProjectDirectoryPath()+"Reports";
                //ExtentHtmlReporter = new ExtentHtmlReporter(ReportFolder+"/index.html");
                ExtentHtmlReporter = new ExtentSparkReporter(resultFile);
                ExtentHtmlReporter.Config.Theme = Theme.Dark;
                ExtentHtmlReporter.Config.DocumentTitle = "Automation Testing Report";
                ExtentHtmlReporter.Config.ReportName = "Regression Testing";

                ExtentReports = new ExtentReports();
                ExtentReports.AttachReporter(ExtentHtmlReporter);
                ExtentReports.AddSystemInfo("Project Name", "");
                ExtentReports.AddSystemInfo("Environment", "");
                ExtentReports.AddSystemInfo("User Name", Environment.UserName);
                ExtentReports.AddSystemInfo("Automation Tool", "Selenium-C#");
                ExtentReports.AddSystemInfo("C# Version", Environment.Version.ToString());
                ExtentReports.AddSystemInfo("Operating System", Environment.OSVersion.ToString());
                ExtentReports.AddSystemInfo("Host Name", "");
                ExtentReports.AddSystemInfo("IP Address", "");
            }
        }

        public static ExtentTest CreateTest(string testName, string description, string categoryName, string authorName)
        {
            ExtentTest = ExtentReports.CreateTest(testName, description).AssignCategory(categoryName).AssignAuthor(authorName);
            SetExtentTest(ExtentTest);
            return ExtentTest;
        }

        public static void FlushReport()
        {
            if (ExtentReports != null)
                ExtentReports.Flush();
        }

        public static void LogTest(string logInfo)
        {
            ExtentUtil.GetExtentTest().Info(logInfo);
        }
    }
}