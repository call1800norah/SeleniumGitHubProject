using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NewSeleniumProject
{
    public class UnitTestBase
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        [SetUp]
        public void SetUpBrowser()
        {
            driver = new ChromeDriver(@"C:\WebDriver\bin\");
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();
            Assert.AreEqual("My Store", driver.Title);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        /// <summary>
        /// Wait for IWebElement to be displayed using WebDriverWait
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        public void WaitForDisplayed(IWebElement element, int timeoutInSeconds = 10)
        {
            Assert.IsNotNull(element, $"nameof{element} returned as null!!");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = $"nameof{element} timed out after {timeoutInSeconds}."
            };
            wait.Until(e => element.Displayed);
        }
        /// <summary>
        /// Verify a list of elements are all displayed.
        /// </summary>
        /// <param name="element"></param>
        public void IsEachElementDisplayed(List<IWebElement> element)
        {
            var isEachElementsDisplayed = element.Where(e => e != null).Aggregate((first, second) => first.Displayed ? second : first);
            Assert.IsTrue(isEachElementsDisplayed.Displayed, $"nameof{isEachElementsDisplayed} was not displayed.");
        }
        /// <summary>
        /// Verify a collection of elements are all displayed.
        /// </summary>
        /// <param name="elementList"></param>
        public void ElementCollectionDisplayed(ReadOnlyCollection<IWebElement> elementList)
        {
            var isElementCollectionDisplayed = elementList.Where(e => e != null).Aggregate((first, second) => first.Displayed ? second : first);
            Assert.IsTrue(isElementCollectionDisplayed.Displayed, $"nameof{isElementCollectionDisplayed} was not displayed.");
        }
    }
}
