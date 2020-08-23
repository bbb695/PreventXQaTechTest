using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.IO;
using PreventXQaTechTest.Drivers.Base;
using log4net;

namespace PreventXQaTechTest.Drivers.Pages
{
    public abstract class BasePage
    {
        protected static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Logger));
        protected BaseDriver baseDriver;
        protected IWebDriver driver;
      

        public BasePage(BaseDriver baseDriver) : base()
        {
            this.baseDriver = baseDriver;
            driver = baseDriver.webDriver;
        }

        protected void ClickElement(By by)
        {
            WaitForElementToBeClickable(by);
            GetElement(by).Click();
        }

        protected void ClickElement(IWebElement element)
        {
            element.Click();
        }

        protected void DoubleClickElement(By by)
        {
            Actions builder = new Actions(driver);
            builder.DoubleClick(GetElement(by)).Perform();
        }

        protected void MouseOver(By by)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(GetElement(by)).Perform();
        }

        protected bool IsElementClickable(By by)
        {
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(by)).Equals(true);
        }

        protected void WaitForElementToBeVisible(By by)
        {
            WaitForElementToBeVisible(by, 3);
        }

        protected void WaitForElementToBeClickable(By by)
        {
            WaitForElementToBeClickable(by, 10);
        }

        protected void WaitForElementToBeVisible(By by, int timeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        protected void WaitForElementToBeClickable(By by, int timeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        protected void WaitForElement(By by)
        {
            WaitForElement(by, 30);
        }

        protected void WaitForElement(By by, int timeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        protected bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        protected string AcceptAlertAndGetItsText()
        {
            string alertText;
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alertText = alert.Text;
                alert.Accept();

                return alertText;
            }
            catch
            {
                logger.Info("failed to close expected alert");
                return "";
            }
        }

        private void SendText(By by, string text)
        {
            GetElement(by).Click();
            GetElement(by).Clear();
            GetElement(by).SendKeys(text);
        }

        protected void EnterText(By by, string text)
        {
            logger.Info("Setting text to \"" + text + "\" for element " + by.ToString());
            try
            {
                SendText(by, text);
            }
            catch
            {
                try
                {
                    GetElement(by).Click();
                }
                catch
                {
                    logger.Info("failed to click element beffore entering text");
                }

                try
                {
                    GetElement(by).Clear();
                }
                catch
                {
                    logger.Info("failed to clear element beffore entering text");
                }
                if (String.IsNullOrWhiteSpace(GetElement(by).Text))
                {
                    GetElement(by).SendKeys(text);
                }
                else
                {
                    logger.Info("element text is not empty, using keystrokes to clear text");
                    GetElement(by).SendKeys("");
                    GetElement(by).SendKeys(Keys.Control + "a");
                    GetElement(by).SendKeys(Keys.Delete);
                    GetElement(by).SendKeys(text);
                }
            }
        }

        protected string GetAttributeFromElement(By by, string attribute)
        {
            return GetElement(by).GetAttribute(attribute);
        }

        protected string GetTextFromElement(By by)
        {
            return GetElement(by).Text;
        }

        protected IWebElement GetElement(By by)
        {
            return GetElement(by, 30);
        }

        protected string GetElementValue(By by)
        {
            return GetAttributeFromElement(by, "value");
        }

        protected IWebElement GetElement(By by, int timeoutSeconds)
        {
            WaitForElement(by, timeoutSeconds);
            return driver.FindElement(by);
        }

        protected string GetPageTitle()
        {
            return driver.Title;
        }

        protected string GetPageUrl()
        {
            return driver.Url;
        }

        protected List<IWebElement> GetAllMatchingElements(By by)
        {
            return driver.FindElements(by).ToList();
        }

        protected Boolean IsElementPresent(By by, int timeoutSeconds)
        {
            try
            {
                WaitForElement(by, timeoutSeconds);
                logger.Info("found element before timeout");
            }
            catch (NoSuchElementException e)
            {
                logger.Info("element not found");
                logger.Debug(e);
                return false;
            }
            return true;
        }

        protected Boolean IsElementPresent(By by)
        {
            return IsElementPresent(by, 3);
        }

        protected By FormXpathBy(string htmlTag, string textContent, Boolean globalSearch)
        {
            string start = "/";
            if (globalSearch)
            {
                start = "//";
            }
            return By.XPath(start + htmlTag + "[contains(., '" + textContent + "')]");
        }

        protected void TakeScreenShot(string methodName)
        {

            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HHmm-ssfff");
            TakeScreenShot(baseDriver.browserName + timeStamp, methodName);
        }

        protected void TakeScreenShot(string fileName, string folderName)
        {
            String folder = @"C:\screenshots\" + baseDriver.browserName + @"\" + folderName + @"\";

            Directory.CreateDirectory(folder);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(folder + fileName + "jpeg", ScreenshotImageFormat.Jpeg);
        }

        protected void SelectByTextFromDropdown(By by, string value)
        {
            IsElementPresent(by);
            SelectElement select = new SelectElement(driver.FindElement(by));
            select.SelectByText(value);
        }

        protected void SelectByIndexFromDropdown(By by, int value)
        {
            IsElementPresent(by);
            SelectElement select = new SelectElement(driver.FindElement(by));
            select.SelectByIndex(value);
        }

        protected void SelectByValueFromDropdown(By by, string value)
        {
            IsElementPresent(by);
            SelectElement select = new SelectElement(driver.FindElement(by));
            select.SelectByValue(value);
        }
    }
}
