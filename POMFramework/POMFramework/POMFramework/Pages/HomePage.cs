using OpenQA.Selenium;
using POMFramework.Base;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace POMFramework.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }


        private readonly By homePageTitleObj = By.XPath("//title[text()='Main Page – NRK Technologies']");
        private readonly By signOutBTNObj = By.XPath("//div[@id='content']/div/div[1]/div[3]");

        private readonly By elementsTAB = By.XPath("//div[@data-id='b839426']");
        private readonly By formsTAB = By.XPath("//div[@data-id='10fb85e']");
        private readonly By alertsFrameAndWindowsTAB = By.XPath("//div[@data-id='5804774']");
        private readonly By widgetsTAB = By.XPath("//div[@data-id='a9a9926']");
        private readonly By interactionsTAB = By.XPath("//div[@data-id='3fe00f1']");
        private readonly By bookStoreApplicationTAB = By.XPath("//div[@data-id='e1f0e41']");

        // VERIFY THE HOME PAGE TITLE
        public bool VerifyHomePageTitle()
        {
            return ElementExists(homePageTitleObj);
        }

        public bool VerifyHomePageAllTabsPresence()
        {
            bool allTabsExist = true;

            ElementExists(elementsTAB);
            ElementExists(formsTAB);
            ElementExists(alertsFrameAndWindowsTAB);
            ElementExists(widgetsTAB);
            ElementExists(interactionsTAB);
            ElementExists(bookStoreApplicationTAB);
            
            return allTabsExist;
        }

        // VERIFY NRK TECHNOLOGIES HOME PAGE TITLE VALIDATION AND LOGOUT
        public LoginPage LogOut_From_The_Application()
        {
            try
            {
                Click(signOutBTNObj);                
                Log("Click on the Sign Out Button successfully.");               
                Thread.Sleep(5000);

                // Return an instance of the HomePage
                return new LoginPage(_driver);
            }
            catch (Exception ex)
            {
                // Log and re-throw any exception
                Log($"An error occurred during Sing Out: {ex.Message}");
                throw;
            }
        }

        // CLICK ON FORMS TAB AND NAVIGATING TO THE FORMS PAGE
        public FormsPage ClickFormsTabAndNavigate()
        {
            try
            {
                // Wait until the Forms Tab is clickable (use explicit wait instead of Thread.Sleep)
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(formsTAB));

                // Click on the Forms Tab
                Click(formsTAB);
                Log("Successfully clicked on the Forms Tab.");

                // Return the FormsPage instance
                return new FormsPage(_driver);
            }
            catch (Exception ex)
            {
                // Log the error with stack trace for better debugging
                Log($"An error occurred while navigating to the Forms page: {ex.Message}. StackTrace: {ex.StackTrace}");
                throw;
            }
        }

    }
}
