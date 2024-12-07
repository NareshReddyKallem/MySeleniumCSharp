using NUnit.Framework;
using POMFramework.Base;
using POMFramework.Pages;
using POMFramework.TestData;
using POMFramework.Util;

namespace POMFramework.Tests
{
    [TestFixture]
    public class TC_Verify_Login_Page_Functionalities : BaseTest
    {
        [Test, Category("Regression"), Description("Verify The Application Login Module Functionality"), Author("Naresh Kallem")]
        public void TC_001_Verify_Error_Message_For_Invalid_Username_During_Login()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidUsernamePlain, GlobalTestData.validPassword);
            
            // Validating with Bool - Whether error - Displayed / Not
            Assert.That(loginPage.IsErrorMessageDisplayed());            
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Username_With_Letters_Numbers"), Author("Naresh Kallem")]
        public void TC_002_Verify_Error_Message_Invalid_Username_With_Letters_Numbers()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidUsernameAlphaNumeric, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Username_With_Special_Characters"), Author("Naresh Kallem")]
        public void TC_003_Verify_Error_Message_Invalid_Username_With_Special_Characters()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidUsernameWithSpecialChars, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Username_With_Letters_Numbers_SpecialChars"), Author("Naresh Kallem")]
        public void TC_004_Verify_Error_Message_Invalid_Username_With_Letters_Numbers_SpecialChars()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidUsernameWithNumbersAndSpecialChars, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Password_During_Login"), Author("Naresh Kallem")]
        public void TC_005_Verify_Error_Message_Invalid_Password_During_Login()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidPassword, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Password_With_Numbers"), Author("Naresh Kallem")]
        public void TC_006_Verify_Error_Message_Invalid_Password_With_Numbers()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidPasswordWithNumbers, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Error_Message_Invalid_Password_With_Numbers_And_Special_Characters"), Author("Naresh Kallem")]
        public void TC_007_Verify_Error_Message_Invalid_Password_With_Numbers_And_Special_Characters()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.AttemptLoginWithInvalidCredentials(GlobalTestData.invalidPasswordWithNumbersAndSpecialChars, GlobalTestData.validPassword);
            Assert.That(loginPage.IsErrorMessageDisplayed());
        }

        [Test, Category("Regression"), Description("Verify_Login_With_Valid_Credentials"), Author("Naresh Kallem")]
        public void TC_008_Verify_Login_With_Valid_Credentials()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.Login_To_NRKTechHome_Valid_Credentials(GlobalTestData.validUsername, GlobalTestData.validPassword);

            HomePage homePage = new HomePage(BrowserUtil.GetDriver());
            Assert.That(homePage.VerifyHomePageTitle());
        }
    }
}