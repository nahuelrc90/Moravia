using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;  

namespace SeleniumTests
{
    [TestFixture]
    public class AccountaSe
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        


        public void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }

        [SetUp]
        public void SetupTest()
        {
            //driver.Manage().Window.Maximize();
            driver = new FirefoxDriver();
            baseURL = "https://github.com/";
            verificationErrors = new StringBuilder();
        }
 
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                TakeScreenshot(driver, @"C:\Documents and Settings\nahuel.muruga\My Documents\Visual Studio 2010\Projects\Moravia\Moravia\captura.jpg");
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAccountaSeTest()
        {
            driver.Navigate().GoToUrl(baseURL + "login");
            //driver.FindElement(By.LinkText("Sign in")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("login_field")).Clear();
            driver.FindElement(By.Id("login_field")).SendKeys("nahuelrc90");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("lanhouse.1");
            driver.FindElement(By.Name("commit")).Click();
            driver.FindElement(By.Id("account_settings")).Click();
            driver.FindElement(By.LinkText("Account Settings")).Click();
            driver.FindElement(By.LinkText("Emails")).Click();
            driver.FindElement(By.LinkText("Profile")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("dd > input[type=\"text\"]")).Clear();
            driver.FindElement(By.CssSelector("dd > input[type=\"text\"]")).SendKeys("Nahuel");
            driver.FindElement(By.CssSelector("button.button.primary")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
