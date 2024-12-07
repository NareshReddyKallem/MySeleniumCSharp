using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using POMFramework.TestData;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace POMFramework.Util
{
    class BrowserUtil
    {
        protected static ThreadLocal<IWebDriver> DRIVER = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            return DRIVER.Value;
        }

        public static void SetDriver(IWebDriver driver)
        {
            DRIVER.Value = driver;
        }

        // LAUNCH THE SPECIFIC BROWSER
        public static void LaunchBrowser(string browserName)
        {
            try
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        LaunchChromeDriver();
                        break;
                    case "firefox":
                        LaunchFirefoxDriver();
                        break;
                    case "edge":
                        LaunchEdgeBrowser();
                        break;
                    default:
                        throw new ArgumentException($"Browser '{browserName}' is not supported.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while launching the browser: {ex.Message}", ex);
            }
        }

        public static void LaunchChromeDriver()
        {
            try
            {
                // Set up ChromeDriver using WebDriverManager for automatic driver management
                // new DriverManager().SetUpDriver(new ChromeConfig());
                SetDriver(new ChromeDriver());

                GetDriver().Manage().Window.Maximize();
                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Navigate().GoToUrl(GlobalTestData.url);

                // Dynamic wait to ensure the page has loaded
                WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.Url.Equals(GlobalTestData.url, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                // Log or handle any error
                throw new Exception($"An error occurred while launching Chrome: {ex.Message}", ex);
            }
        }

        public static void LaunchFirefoxDriver()
        {
            try
            {
                // Set up FirefoxDriver using WebDriverManager
                new DriverManager().SetUpDriver(new FirefoxConfig());
                SetDriver(new FirefoxDriver());

                GetDriver().Manage().Window.Maximize();
                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Navigate().GoToUrl(GlobalTestData.url);

                // Dynamic wait to ensure the page has loaded
                WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.Url.Equals(GlobalTestData.url, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                // Log or handle any error
                throw new Exception($"An error occurred while launching Firefox: {ex.Message}", ex);
            }
        }

        public static void LaunchEdgeBrowser()
        {
            try
            {
                // Set up EdgeDriver using WebDriverManager
                new DriverManager().SetUpDriver(new EdgeConfig());
                SetDriver(new EdgeDriver());

                GetDriver().Manage().Window.Maximize();
                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Navigate().GoToUrl(GlobalTestData.url);

                // Dynamic wait to ensure the page has loaded
                WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.Url.Equals(GlobalTestData.url, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                // Log or handle any error
                throw new Exception($"An error occurred while launching Edge: {ex.Message}", ex);
            }
        }

        // Close the current browser window
        public static void CloseBrowser()
        {
            try
            {
                if (GetDriver() != null)
                    GetDriver().Close();
            }
            catch (Exception ex)
            {
                // Handle any exception if the browser cannot be closed
                throw new Exception($"An error occurred while closing the browser: {ex.Message}", ex);
            }
        }

        // Quit the entire browser session
        public static void QuitBrowser()
        {
            try
            {
                if (GetDriver() != null)
                    GetDriver().Quit();
            }
            catch (Exception ex)
            {
                // Handle any exception if the browser cannot be quit
                throw new Exception($"An error occurred while quitting the browser: {ex.Message}", ex);
            }
        }
    }
}