using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using POMFramework.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POMFramework.Base
{
    public class BasePage
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Find(By selector)
        {
            return _driver.FindElement(selector);
        }

        public List<IWebElement> FindMultiple(By selector)
        {
            return _driver.FindElements(selector).ToList();
        }

        public List<string> FindMultipleValues(By selector)
        {
            var values = new List<string>();
            var list = _driver.FindElements(selector);
            values = list.Select(item => item.Text.Trim()).ToList();
            return values;
        }

        public bool AlertPresent()
        {
            _driver.SwitchTo().Alert();
            return true;
        }

        public void AlertOK()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void AlertCancel()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }

        public string AlertText()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void Clear(By selector)
        {
            Find(selector).Clear();
        }

        public BasePage Click(By selector)
        {
            var element = Find(selector);
            ScrollToElement(selector);
            WaitUntilElementIsClickable(selector);
            element.Click();
            return this;
        }

        public void ScrollToElement(By selector)
        {
            var element = Find(selector);
            var actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public int Count(By selector)
        {
            return FindMultiple(selector).Count;
        }

        public string DropdownText(By selector)
        {
            var selectedValue = new SelectElement(Find(selector));
            var value = selectedValue.SelectedOption.Text;
            return value;
        }

        public BasePage TypeText(By selector, string value)
        {
            Clear(selector);
            Find(selector).SendKeys(value);
            return this;
        }

        public BasePage SelectValue(By selector, string value)
        {
            var select = new SelectElement(Find(selector));
            /*if (Int32.Parse(value) > 0)
                select.SelectByIndex(Int32.Parse(value));
            else
                select.SelectByText(value);*/
            select.SelectByText(value);
            return this;
        }

        public bool ElementExists(By selector)
        {
            return Count(selector) > 0;
        }

        public bool ElementNotExists(By selector)
        {
            return !ElementExists(selector);
        }

        public string GetElementText(By selector)
        {
            return Find(selector).Text;
        }

        public string GetAttributeValue(By selector, string attribute)
        {
            return Find(selector).GetAttribute(attribute);
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetPageSource()
        {
            return _driver.PageSource;
        }

        public void SwitchToFrame(int index)
        {
            _driver.SwitchTo().Frame(index);
        }

        public void SwitchToTab()
        {
            Find(By.CssSelector("body")).SendKeys(Keys.Control + Keys.Shift + Keys.Tab);
        }

        public List<string> GetDropdownValues(By selector)
        {
            var element = Find(selector);
            var selectList = new SelectElement(element);
            var elementsList = selectList.Options;
            var DropdownvalueList = elementsList.Select(item => item.Text).ToList();
            return DropdownvalueList;
        }

        public void PressEnter(By selector)
        {
            Find(selector).SendKeys(Keys.Enter);
        }

        public void PressTab(By selector)
        {
            Find(selector).SendKeys(Keys.Tab);
        }

        public void HoverOnElement(By selector)
        {
            var builder = new Actions(_driver);
            var element = Find(selector);
            builder.MoveToElement(element).Build().Perform();
        }

        public void CheckCheckbox(By selector)
        {
            if (!Find(selector).Selected)
                Click(selector);
        }

        public void UncheckCheckbox(By selector)
        {
            if (Find(selector).Selected)
                Click(selector);
        }

        public void DragAndDrop(By sourceSelector, By destinationSelector)
        {
            var actions = new Actions(_driver);
            var sourceElement = Find(sourceSelector);
            var destinationElement = Find(destinationSelector);
            actions.ClickAndHold(sourceElement).MoveToElement(destinationElement).Release(destinationElement).Build().Perform();
        }

        //Need to provide only CSS Selector as selector
        public void JSClick(string selector)
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript($"document.querySelector('{selector}').click()");
        }

        //Need to provide only CSS Selector as selector
        public void JSTypeText(string selector, string value)
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript($"document.querySelector('{selector}').value='{value}'");
        }

        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }

        public void NavigateForward()
        {
            _driver.Navigate().Forward();
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        public void ScrollWithInElement(string selector)
        {
            var efDriver = new EventFiringWebDriver(_driver);
            efDriver.ExecuteScript($"document.querySelector('{selector}').scrollTop = 2000000");
        }

        public void ScrollUp()
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0,-250)", "");
        }

        public void ScrollDown()
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
        }

        public void ScrollToTop()
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0,-20000)", "");
        }

        public void ScrollToBottom()
        {
            var jse = _driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0,20000)", "");
        }

        public BasePage WaitUntilElementIsVisible(By selector)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            return this;
        }

        public BasePage WaitUntilElementIsClickable(By selector)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            return this;
        }

        public BasePage Log(string message)
        {
            ExtentUtil.LogTest(message);
            return this;
        }
    }
}