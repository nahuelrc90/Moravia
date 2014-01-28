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
            screenshot.SaveAsFile(saveLocation, ImageFormat.jpg);
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://login.live.com/";
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
            driver.Navigate().GoToUrl(baseURL + "login.srf?wa=wsignin1.0&rpsnv=12&ct=1390596794&rver=6.4.6456.0&wp=MBI&wreply=http:%2F%2Fmail.live.com%2Fdefault.aspx&lc=1033&id=64855&mkt=en-us&cbcxt=mai&snsc=1");
            driver.FindElement(By.Id("i0116")).Clear();
            driver.FindElement(By.Id("i0116")).SendKeys("nahuel.muruga@hotmail.com");
            driver.FindElement(By.Id("i0118")).Clear();
            driver.FindElement(By.Id("i0118")).SendKeys("lanhouse.1");
            driver.FindElement(By.Id("idSIButton9")).Click();
            driver.FindElement(By.LinkText("https://github.com/users/nahuelrc90/emails/7305728/confirm_verification/929daa4eba41ad23fd79a7320d4a61880e3fc491")).Click();
            driver.FindElement(By.CssSelector("span.octicon.octicon-tools")).Click();
            driver.FindElement(By.LinkText("Confirm")).Click();
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
