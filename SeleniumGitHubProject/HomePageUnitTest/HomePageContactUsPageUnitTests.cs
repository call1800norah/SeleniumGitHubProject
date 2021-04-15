using NewSeleniumProject.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace NewSeleniumProject
{
    public class HomePageContactUsPageUnitTests : UnitTestBase
    {
        public HomePageContactUsPageUnitTests(IWebDriver driver)
        {
            this.driver = driver;
        }
        public HomePageContactUsPageUnitTests() { }
        private HomePageContactUsPagePO homePagePO;

        Random random = new Random();
        /// <summary>
        /// Method to verify homepage is loading
        /// </summary>
        public void VerifyHomePageLoadTest()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            homePagePO = new HomePageContactUsPagePO(driver);

            List<IWebElement> allElementDisplayed = new List<IWebElement>() { homePagePO.WholePage,
                homePagePO.Banner, homePagePO.CallUsNow,  homePagePO.ContactUs, homePagePO.SignIn,
                homePagePO.StoreLogo, homePagePO.SearchBox, homePagePO.ShoppingCart, homePagePO.MenuContent,
                homePagePO.HomepageSlicer, homePagePO.FacebookBlock, homePagePO.EditorialBlock, homePagePO.FooterContainer };

            IsEachElementDisplayed(allElementDisplayed);
            ElementCollectionDisplayed(homePagePO.ContentItemCards);
            ElementCollectionDisplayed(homePagePO.HomepageTabs);
            ElementCollectionDisplayed(homePagePO.ProductImageLinks);
            ElementCollectionDisplayed(homePagePO.CustomInfoBlocks);
            ElementCollectionDisplayed(homePagePO.CustomInfoEachBlocks);

            Assert.IsTrue(homePagePO.CallUsNow.Text.Contains("Call us"));
            Assert.AreEqual("Contact us", homePagePO.ContactUs.Text);
            Assert.AreEqual("Sign in", homePagePO.SignIn.Text);
            Assert.IsTrue(homePagePO.ShoppingCart.Text.Contains("Cart"));
        }
        /// <summary>
        /// Test for the Contact Us link
        /// </summary>
        [Test]
        public void ContactUsTest()
        {
            homePagePO = new HomePageContactUsPagePO(driver);
            VerifyHomePageLoadTest();
            homePagePO.ContactUs.Click();

            Assert.IsNotNull(homePagePO.ContactUsContainer, $"nameof{homePagePO.ContactUsContainer} returned as null!!");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(e => homePagePO.ContactUsContainer.Displayed);
            List<IWebElement> elements = new List<IWebElement>{ homePagePO.HomeIcon,
                homePagePO.NavigationPageContact, homePagePO.CustomerServiceHeader, homePagePO.SendAMessageHeader };

            IsEachElementDisplayed(elements);

        }
        /// <summary>
        /// Test for the subject heading dropdown in the Send Message form 
        /// </summary>
        [Test]
        public void SendAMessageSubjectHeadingDropdownTest()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            homePagePO = new HomePageContactUsPagePO(driver);
            VerifyHomePageLoadTest();
            homePagePO.ContactUs.Click();

            wait.Until(e => homePagePO.ContactUsContainer.Displayed);
            Assert.IsNotNull(homePagePO.ContactUsContainer, $"nameof{homePagePO.ContactUsContainer} returned as null!!");
            Assert.IsTrue(homePagePO.SendAMessageHeader.Text.Equals("SEND A MESSAGE"), $"Expected a label 'SEND A MESSAGE' but returned {homePagePO.SendAMessageHeader.Text.Trim()}");
            Assert.IsTrue(homePagePO.SubjectHeading.Text.Equals("Subject Heading"), $"{homePagePO.SubjectHeading.Text} was not displayed.");

            homePagePO.SubjectHeadingOptionDropdown.Click();
            ElementCollectionDisplayed(homePagePO.SubjectHeadingOptions);
        }
        /// <summary>
        /// Test for the Email Address, Order Reference and attach file fields in the Send Message form
        /// </summary>
        [Test]
        public void SendAMessageEmailAddressAndOrderReferenceTest()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            homePagePO = new HomePageContactUsPagePO(driver);
            VerifyHomePageLoadTest();
            homePagePO.ContactUs.Click();

            wait.Until(e => homePagePO.ContactUsContainer.Displayed);
            Assert.IsNotNull(homePagePO.ContactUsContainer, $"nameof{homePagePO.ContactUsContainer} returned as null!!");
            Assert.IsTrue(homePagePO.SendAMessageHeader.Text.Equals("SEND A MESSAGE"), $"Expected a label 'SEND A MESSAGE' but returned {homePagePO.SendAMessageHeader.Text}");

            SubjectHeadingRandomChoice();
            var email = homePagePO.EmailAddressLabel.Displayed ? homePagePO.EmailAddressLabel.Text.Contains("Email address") : false;
            Assert.IsTrue(email, $"Expected to return 'Email address' but instead {homePagePO.EmailAddressLabel.Text} was returned.");

            wait.Until(e => homePagePO.EmailInputBox.Displayed);
            homePagePO.EmailInputBox.Click();

            List<string> emailAddressList = new List<string>() { "test@test.com", "test@test", "test.com", "" };
            List<string> messageBoxContents = new List<string>() { "message test", "" };
            var randomEmailAddress = random.Next(emailAddressList.Count);
            homePagePO.EmailInputBox.SendKeys(emailAddressList[randomEmailAddress]);

            var orderReference = homePagePO.OrderReferenceLabel.Displayed ? homePagePO.OrderReferenceLabel.Text.Contains("Order reference") : false;
            Assert.IsTrue(email, $"Expected to return 'Order reference' but instead {homePagePO.EmailAddressLabel.Text} was returned.");
            homePagePO.OrderReferenceInputBox.SendKeys("12345");


            var messageLabel = homePagePO.MessageLabel.Displayed ? homePagePO.MessageLabel.Text.Equals("Message") : false;
            Assert.IsTrue(messageLabel, $"Expected to return 'Message' label but instead {homePagePO.MessageLabel.Text} was returned.");

            var randomMessage = random.Next(messageBoxContents.Count);
            homePagePO.MessageBox.SendKeys(messageBoxContents[randomMessage]);

            string filePath = @"C:\Users\norah\Source\Repos\FileUploadTest.txt";
            homePagePO.InputFilePath.SendKeys(filePath);
            homePagePO.SendButton.Click();
            bool isValidEmail = false;
            if (emailAddressList[randomEmailAddress].Contains("@") && emailAddressList[randomEmailAddress].Contains(".com"))
            {
                isValidEmail = true;
            }

            var isEmailValid = isValidEmail ? true : false;

            var isMessageBoxEmpty = String.IsNullOrEmpty(messageBoxContents[randomMessage]) ? true : false;

            if (isEmailValid && !isMessageBoxEmpty)
            {
                Assert.IsTrue(homePagePO.AlertSuccessMessage.Displayed,
               $"Expected a message 'Your message has been successfully sent to our team.' but " +
               $"{homePagePO.AlertSuccessMessage.Text} returned.");

                homePagePO.FooterLinksHome.Click();
                VerifyHomePageLoadTest();
            }
            else if (!isEmailValid)
            {
                Assert.IsTrue(homePagePO.ErrorMessage.Text.Contains("Invalid email address."));

            }
            else if (isMessageBoxEmpty)
            {
                Assert.IsTrue(homePagePO.ErrorMessage.Text.Contains("The message cannot be blank."));
            }
        }
        /// <summary>
        /// Method for the random choice of the Subject Heading dropdown
        /// </summary>
        public void SubjectHeadingRandomChoice()
        {
            int randomChoice = random.Next(homePagePO.SubjectHeadingOptions.Count);
            homePagePO.SubjectHeadingOptions[randomChoice].Click();
            switch (randomChoice)
            {
                case 0:
                    Assert.IsTrue(homePagePO.SubjectHeadingOptions[randomChoice].Text.Equals("-- Choose --"),
                       $"Expected 'Customer service' but returned {homePagePO.SubjectHeadingOptions[randomChoice].Text}");
                    Assert.IsTrue(homePagePO.OptionChoose.Text.Equals("-- Choose --"),
                        $"Expected 'For any question about a product, an order' but returned {homePagePO.OptionChoose.Text}");
                    break;

                case 1:
                    Assert.IsTrue(homePagePO.SubjectHeadingOptions[randomChoice].Text.Equals("Customer service"),
                        $"Expected 'Customer service' but returned {homePagePO.SubjectHeadingOptions[randomChoice].Text}");
                    Assert.IsTrue(homePagePO.CustomeServiceOptionComment.Text.Equals("For any question about a product, an order"),
                        $"Expected 'For any question about a product, an order' but returned {homePagePO.CustomeServiceOptionComment.Text}");
                    break;

                case 2:
                    Assert.IsTrue(homePagePO.SubjectHeadingOptions[randomChoice].Text.Equals("Webmaster"),
                       $"Expected 'Webmaster' but returned {homePagePO.SubjectHeadingOptions[randomChoice].Text}");
                    Assert.IsTrue(homePagePO.WebMasterComment.Text.Equals("If a technical problem occurs on this website"),
                        $"Expected 'If a technical problem occurs on this website' but returned {homePagePO.WebMasterComment.Text}");
                    break;
            }
            var IsChooseSelected = homePagePO.SubjectHeadingOptions[randomChoice].Text.Equals("-- Choose --");
            if (IsChooseSelected)
            {
                homePagePO.SubjectHeadingOptions[1].Click();
            }
        }
    }
}
