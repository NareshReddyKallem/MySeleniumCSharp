using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POMFramework.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POMFramework.Pages
{
    public class FormsPage : BasePage
    {
        public FormsPage(IWebDriver driver) : base(driver) { }

        // *******************************************************************
        private readonly By formsTAB = By.XPath("//a[text()='Forms']");

        private readonly By practiceFormSubTAB = By.XPath("//a[text()='Practice Form']");

        private readonly By practiceFormPageTitleObj = By.XPath("//div[@data-id='9ef3e93']");

        private readonly By firstNameEDF = By.XPath("//input[@id='firstName']");

        private readonly By lastNameEDF = By.XPath("//input[@id='lastName']");

        private readonly By emailEDF = By.XPath("//input[@id='email']");

        private readonly By maleRdBTN = By.XPath("//input[@value='Male']");

        private readonly By femaleRdBTN = By.XPath("//input[@value='Female']");

        private readonly By otherRdBTN = By.XPath("//input[@value='Other']");

        private readonly By mobileNumberEDF = By.XPath("//input[@id='mobile']");

        private readonly By dateOfBirthCalendarEDF = By.XPath("//input[@id='dob']");

        private readonly By subjectsEDF = By.XPath("//input[@id='subjects']");

        private readonly By sportsChkBX = By.XPath("//input[@value='Sports']");

        private readonly By readingChkBX = By.XPath("//input[@value='Reading']");

        private readonly By musicChkBX = By.XPath("//input[@value='Music']");

        private readonly By pictureChooseFileBTN = By.XPath("//input[@id='picture']");

        private readonly By currentAddressEDF = By.XPath("//textarea[@id='currentAddress']");

        private readonly By stateCMB = By.XPath("//select[@id='state']");

        private readonly By cityCMB = By.XPath("//select[@id='city']");

        private readonly By submitBTN = By.XPath("//button[@type='submit']");

        private readonly By alertInfoCloseBTN = By.XPath("//button[@class='close-btn']");

        private readonly By signOutBTN = By.XPath("//div[@data-id='64950a9']");
        // *************************************************************************

        // FORMS PAGE - PRACTICE FORM SUB - TAB Validation
        public void ValidatesTheFormsTabAndPracticeFormSubTab()
        {
            try
            {
                // Wait until the Forms Tab element is visible
                WaitUntilElementIsVisible(practiceFormSubTAB);

                // Check if the Practice Form Sub Tab exists
                if (ElementExists(practiceFormSubTAB))
                {
                    Log("Successfully navigated to the Forms Page and Practice Form Sub Tab.");
                }
                else
                {
                    Log("Failed to navigate to the Forms Page and Practice Form Sub Tab.");
                }
            }
            catch (Exception ex)
            {
                // Log and re-throw any exception that occurs
                Log($"An error occurred while navigating to the Forms Page and Practice Form Sub Tab: {ex.Message}");
                throw;
            }
        }

        // FORMS PAGE - PRACTICE FORM SUB - TAB Validation
        public bool VerifyPracticeFormPageTitle()
        {
            return ElementExists(practiceFormPageTitleObj);
        }

        // VERIFY NRK TECHNOLOGIES HOME PAGE TITLE VALIDATION AND LOGOUT
        public LoginPage LogOut_From_The_Application()
        {
            try
            {
                Click(signOutBTN);
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

        public void EnterUserFullName(string firstName, string lastName)
        {
            // Enter the first name into the first name text field
            TypeText(firstNameEDF, firstName);
            Log("Entered user first name successfully.");

            // Enter the last name into the last name text field
            TypeText(lastNameEDF, lastName);
            Log("Entered user last name successfully.");
        }

        public void EnterUserEmailId(string email)
        {
            // Enter the email ID into the email text field
            TypeText(emailEDF, email);
            Log("Entered user email ID successfully.");
        }

        public void ClickOnMaleRadioButton()
        {
            // Clicks on the male radio button on the form.
            Click(maleRdBTN);
            Log("Clicked the Male radio button successfully.");            
        }

        public void EnterMobileNumber(string mobile)
        {
            // Enter the mobile number into the mobile number text field
            TypeText(mobileNumberEDF, mobile);
            Log("Entered the user's mobile number successfully.");
        }

        public void EnterDOB(string dob)
        {
            // Enter the date of birth into the DOB text field
            TypeText(dateOfBirthCalendarEDF, dob); // Assuming `dobTextField` is the correct locator for the DOB field
            Log("Entered the user's date of birth successfully.");
        }

        public void EnterSubjects(string subjects)
        {
            // Enter the subject(s) into the subject text field
            TypeText(subjectsEDF, subjects); 
            Log("Entered the user's subject(s) successfully.");
        }

        public void ClickOnSportsCheckBox()
        {
            // Click on the Sports checkbox element on the form
            Click(sportsChkBX);
            Log("Clicked the Sports checkbox successfully.");
        }

        public void UploadFile(string filePath)
        {
            // Type the file path into the file upload button
            TypeText(pictureChooseFileBTN, filePath); 
            Log($"Uploaded file successfully: {filePath}");
        }


        public void UploadFile123(string filePath)
        {
            // Identify the file input element
            By fileInput = By.XPath("//input[@id='picture']"); // Use the appropriate locator for your file input element

            // Wait for the element to be visible (optional)
            WaitUntilElementIsVisible(fileInput);

            // Send the file path to the file input element
            IWebElement fileInputElement = _driver.FindElement(fileInput);
            fileInputElement.SendKeys(filePath);

            // Log the upload success
            Log("File uploaded successfully: " + filePath);
        }


        public void EnterCurrentAddress(string currentAddress)
        {
            // Type the current address into the current address field
            TypeText(currentAddressEDF, currentAddress);
            Log("Entered current address successfully");
        }

        public void SelectState(string state)
        {
            // Select the state from the dropdown
            SelectValue(stateCMB, state);           
            Log("Selected State: from the list successfully.");
        }

        public void SelectCity(string city)
        {
            // Select the state from the dropdown
            SelectValue(cityCMB, city);
            Log("Selected City: from the list successfully.");
        }

        public void ClickOnSubmitBTN()
        {
            // Click on the submit button to submit the form
            Click(submitBTN);            
            Log("Clicked the Submit Button successfully.");
        }

        public void ClickOnAlertInformationCloseBTN()
        {
            // Click the button
            Click(alertInfoCloseBTN);
            Log("Clicked the Alert Information Close Button successfully.");
        }


    }
}
