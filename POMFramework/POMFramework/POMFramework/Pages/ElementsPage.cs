using OpenQA.Selenium;
using POMFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMFramework.Pages
{
    public class ElementsPage : BasePage
    {
        public ElementsPage(IWebDriver driver) : base(driver) { }


        private readonly By textBoxLinkTABObj = By.XPath("//a[text()='Text Box']");
        private readonly By fullNameEDFObj = By.XPath("//input[@id='customForm_fullName']");
        private readonly By emailEDFObj = By.XPath("//input[@id='customForm_email']");
        private readonly By currentAddressEDFObj = By.XPath("//input[@id='customForm_currentAddress']");
        private readonly By permanentAddressEDFObj = By.XPath("//input[@id='customForm_permanentAddress']");
        private readonly By submitBTNObj = By.XPath("//button[@onclick='customForm_submitForm()']");

        private readonly By sumbittedDataTitleObj = By.XPath("//div[@id='customForm_output']/h3");
    }
}
