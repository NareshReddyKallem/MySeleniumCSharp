using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace POMFramework.Util
{
    public class CommonUtil
    {
        public static string instanceReportFolder;
        public static string screenshotFolder;
        public static string resultFile;
        public static string indexFile;

        public static string GetProjectDirectoryPath()
        {
            string path = Environment.CurrentDirectory;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            return actualPath;
        }
        public static string GetCurrentDateTime(string pattern)
        {
            return DateTime.Now.ToString(pattern);
        }

        public static void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        public static string GetCurrentDayFolder()
        {
            string reportsFolder = CommonUtil.GetProjectDirectoryPath() + "Reports/" + GetCurrentDateTime("MMMMM_dd_yyyy");
            CreateFolder(reportsFolder);
            return reportsFolder;
        }

        public static string GetCurrentRunFolder()
        {
            string instanceReportFolder = GetCurrentDayFolder() + "/" + GetCurrentDateTime("MMMMM_dd_yyyy_hh-mm");
            CreateFolder(instanceReportFolder);
            return instanceReportFolder;
        }

        public static string GetCurrentRunScreenshotFolder()
        {
            string screenshotFolder = GetCurrentRunFolder() + "/" + "screenshots";
            CreateFolder(screenshotFolder);
            return screenshotFolder;
        }

        public static void CleanFolder(string folderPath)
        {
            //Directory.GetFiles(folderPath).ToList().ForEach(File.Delete);
            Directory.GetDirectories(folderPath).ToList().ForEach(Directory.Delete);
        }

        public static void CleanScreenshotFolder()
        {
            string screenshotFolder = GetCurrentRunFolder() + "/" + "screenshots";
            CleanFolder(screenshotFolder);
        }

        public static void CopyScreenshotFolder()
        {           
            var sourceFolder = CommonUtil.GetProjectDirectoryPath() + "Screenshots";
            var destinationFolder = screenshotFolder;
            if (destinationFolder == null) return;
            // Copy each file from the source folder to the destination folder
            foreach (var filePath in Directory.GetFiles(sourceFolder))
            {
                // Get the file name and build the destination path
                var fileName = Path.GetFileName(filePath);
                var destFilePath = Path.Combine(destinationFolder, fileName);

                // Copy the file to the destination path
                File.Copy(filePath, destFilePath, overwrite: true);
            }
            
        }

        public static string GetIPAddress()
        {
            throw new NotImplementedException();
        }

        public static void CleanFiles()
        {
            string screenshotFolder = CommonUtil.GetProjectDirectoryPath() + "Screenshots/";
            if (Directory.Exists(screenshotFolder))
            {
                Directory.GetFiles(screenshotFolder).ToList().ForEach(File.Delete);
            }
        }

        public static string CaptureScreenshot()
        {            
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)BrowserUtil.GetDriver();
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string timeStamp = GetCurrentDateTime("MMddHHmmssms");
            string dest = CommonUtil.GetProjectDirectoryPath() + "Screenshots/" + timeStamp + ".png";
            string destination = new Uri(dest).LocalPath;
            screenshot.SaveAsFile(destination);
            return destination;
        }       


        public static void KillBrowserDriverProcesses()
        {
            foreach (Process proc in Process.GetProcessesByName("Chromedriver"))
            {
                proc.Kill();
            }
            foreach (Process proc in Process.GetProcessesByName("Geckodriver"))
            {
                proc.Kill();
            }
        }

        public static string PrepareReportsDirectory()
        {
            // Creating Reports Folder if not exists
            CreateFolder(CommonUtil.GetProjectDirectoryPath() + "Reports/");

            // Creating Screenshot Folder if not exists
            CreateFolder(CommonUtil.GetProjectDirectoryPath() + "Screenshots/");

            // Creating Logs folder - implement later after checking how to do

            GetCurrentDayFolder();

            instanceReportFolder = GetCurrentRunFolder();

            screenshotFolder = GetCurrentRunScreenshotFolder();

            // Need to change the project name by reading from the properties file.
            //resultFile = instanceReportFolder + "/" + "ProjectName" + GetCurrentDateTime("MMMMM_dd_yyyy_hh-mm") + "_" + "index.html";
            resultFile = instanceReportFolder + "/index.html";

            return resultFile;
        }

        public static void CreateIndexFile()
        {
            //Thread.Sleep(10000);
            string sourceFile = resultFile;
            string destinationFile = CommonUtil.GetProjectDirectoryPath() + "index.html";
            File.Copy(sourceFile, destinationFile,true);
        }
    }
}
