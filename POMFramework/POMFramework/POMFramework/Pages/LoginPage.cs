using OpenQA.Selenium;
using POMFramework.Base;
using POMFramework.Pages;
using System;
using System.Threading;

namespace POMFramework
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Locators for login page elements
        private readonly By nrkTechTitle = By.XPath("//div[@data-id='72dfdd2']//div//h2");
        private readonly By userNameEDF = By.XPath("//input[@id='form-field-name']");
        private readonly By userPwdEDF = By.XPath("//input[@id='form-field-field_24e4725']");
        private readonly By loginBTN = By.XPath("//button[@id='frontbtnformadmin']");
        private readonly By errorMessageTextObj = By.XPath("//div[@id='error-msg-frontbtnformadmin']");


        // LOGIN PAGE VALIDATION
        public void ValidateLoginPageTitle()
        {
            try
            {
                // Wait until the NRK Technologies Title is visible
                WaitUntilElementIsVisible(nrkTechTitle);

                // Check if the username textbox exists on the page
                if (ElementExists(userNameEDF))
                {
                    Log("Login page is successfully launched.");
                }
                else
                {
                    Log("Failed to launch the login page. Username textbox not found.");
                }
            }
            catch (Exception ex)
            {
                // Log and re-throw any exception
                Log($"An error occurred while validating the login page: {ex.Message}");
                throw;
            }
        }


        public HomePage Login_To_NRKTechHome_Valid_Credentials(string userName, string password)
        {
            try
            {
                // Enter the username into the username textbox
                TypeText(userNameEDF, userName);
                Log("Entered the username successfully.");

                // Enter the password into the password textbox
                TypeText(userPwdEDF, password);
                Log("Entered the password successfully.");

                // Click on the login button to log in
                Click(loginBTN);
                Log("Clicked on the login button successfully.");                               
                Thread.Sleep(5000);

                // Return an instance of the HomePage
                return new HomePage(_driver);
            }
            catch (Exception ex)
            {
                // Log and re-throw any exception
                Log($"An error occurred during login: {ex.Message}");
                throw;
            }
        }


        // LOGIN TO THE ORANGE HRM - BUT IF YOU WANT TO PERFORM SAME FUNCTIONALITY IN THE SAME PAGE BELOW WAY WE NEED TO GIVE CODE
        public LoginPage AttemptLoginWithInvalidCredentials(string userName, string password)
        {
            try
            {
                // Enter the username into the username textbox
                TypeText(userNameEDF, userName);
                Log("Entered the username successfully.");

                // Enter the password into the password textbox
                TypeText(userPwdEDF, password);
                Log("Entered the password successfully.");

                // Click on the login button to log in
                Click(loginBTN);
                Log("Clicked on the login button successfully.");
                Thread.Sleep(5000);               

                // Return the same page object
                return this;
            }
            catch (Exception ex)
            {
                // Log and re-throw any exception
                Log($"An error occurred while logging in on the same page: {ex.Message}");
                throw;
            }
        }

        public bool IsErrorMessageDisplayed()
        {
            return ElementExists(errorMessageTextObj);
        }


        public string GetErrorMessageText()
        {
            return Find(errorMessageTextObj).Text;
        }

        public bool LoginPageTitleValidation()
        {
            return ElementExists(nrkTechTitle);
        }

    }
}
