using NUnit.Framework;
using POMFramework.Base;
using POMFramework.Pages;
using POMFramework.TestData;
using POMFramework.Util;
using System.Threading;

namespace POMFramework.Tests
{
    [TestFixture]
    public class TC_Verify_Forms_Page_Functionalities : BaseTest
    {
        [Test, Category("Regression"), Description("Verify_Forms_Page_Title_Validation_And_Logout"), Author("Naresh Kallem")]
        public void TC_001_Verify_Forms_Page_Title_Validation_And_Logout()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.Login_To_NRKTechHome_Valid_Credentials(GlobalTestData.validUsername, GlobalTestData.validPassword);

            HomePage homePage = new HomePage(BrowserUtil.GetDriver());
            Assert.That(homePage.VerifyHomePageTitle());

            homePage.ClickFormsTabAndNavigate();
            Thread.Sleep(5000);

            FormsPage formsPage = new FormsPage(BrowserUtil.GetDriver());
            formsPage.ValidatesTheFormsTabAndPracticeFormSubTab();
            Assert.That(formsPage.VerifyPracticeFormPageTitle());

            formsPage.LogOut_From_The_Application();
            Assert.That(loginPage.LoginPageTitleValidation());
        }

        [Test, Category("Regression"), Description("Verify_Practice_Form_Page_Fill_And_Submit_Form_Then_Logout"), Author("Naresh Kallem")]
        public void TC_002_Verify_Practice_Form_Page_Fill_And_Submit_Form_Then_Logout()
        {
            LoginPage loginPage = new LoginPage(BrowserUtil.GetDriver());
            loginPage.ValidateLoginPageTitle();

            loginPage.Login_To_NRKTechHome_Valid_Credentials(GlobalTestData.validUsername, GlobalTestData.validPassword);

            HomePage homePage = new HomePage(BrowserUtil.GetDriver());
            Assert.That(homePage.VerifyHomePageTitle());

            homePage.ClickFormsTabAndNavigate();
            Thread.Sleep(5000);

            FormsPage formsPage = new FormsPage(BrowserUtil.GetDriver());
            formsPage.ValidatesTheFormsTabAndPracticeFormSubTab();
            Assert.That(formsPage.VerifyPracticeFormPageTitle());

            formsPage.EnterUserFullName("Naresh", "Kallem");

            formsPage.EnterUserEmailId("nareshreddykallem999@gmail.com");

            formsPage.ClickOnMaleRadioButton();

            formsPage.EnterMobileNumber("9876543219");

            formsPage.EnterDOB("02/08/1992");

            formsPage.EnterSubjects("Computer Science and Engineering");

            formsPage.ClickOnSportsCheckBox();                  

            formsPage.UploadFile123("G:\\OneDrive\\Desktop\\ONLY T/PP.jpg");                     
            Thread.Sleep(5000);

            formsPage.EnterCurrentAddress("USA-Texas");

            formsPage.SelectState("Texas");

            formsPage.SelectCity("Dallas");

            formsPage.ClickOnSubmitBTN();
            Thread.Sleep(5000);

            formsPage.ClickOnAlertInformationCloseBTN();
            Thread.Sleep(3000);

            formsPage.LogOut_From_The_Application();
            Assert.That(loginPage.LoginPageTitleValidation());
        }


    }
}
