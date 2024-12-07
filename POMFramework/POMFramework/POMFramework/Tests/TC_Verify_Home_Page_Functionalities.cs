using NUnit.Framework;
using POMFramework.Base;
using POMFramework.Pages;
using POMFramework.TestData;
using POMFramework.Util;

namespace POMFramework.Tests
{
    [TestFixture]
    public class TC_Verify_Home_Page_Functionalities : BaseTest
    {
        [Test, Category("Regression"), Description("Verify_Home_Page_NRK_Tech_Title_Validation_And_Logout"), Author("Naresh Kallem")]
        public void TC_001_Verify_Home_Page_NRK_Tech_Title_Validation_And_Logout()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.Login_To_NRKTechHome_Valid_Credentials(GlobalTestData.validUsername, GlobalTestData.validPassword);

            HomePage homePage = new HomePage(BrowserUtil.GetDriver());
            Assert.That(homePage.VerifyHomePageTitle());

            homePage.LogOut_From_The_Application();
            loginPage.ValidateLoginPageTitle();
        }

        [Test, Category("Regression"), Description("Verify_Home_Page_NRK_Tech_Tabs_Validation_And_Logout"), Author("Naresh Kallem")]
        public void TC_002_Verify_Home_Page_NRK_Tech_Tabs_Validation_And_Logout()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.Login_To_NRKTechHome_Valid_Credentials(GlobalTestData.validUsername, GlobalTestData.validPassword);

            HomePage homePage = new HomePage(BrowserUtil.GetDriver());
            Assert.That(homePage.VerifyHomePageTitle());

            // Validates the Homepage Total TABS
            Assert.That(homePage.VerifyHomePageAllTabsPresence());

            homePage.LogOut_From_The_Application();
            loginPage.ValidateLoginPageTitle();
        }





    }
}
