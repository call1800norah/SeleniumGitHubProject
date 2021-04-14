using Microsoft.Graph;
using NewSeleniumProject.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewSeleniumProject.HomePageUnitTest
{
    public class HomePageSignInPageUnitTests : UnitTestBase
    {
        private HomePageSignInPO signInPage;
        private readonly string firstname = "Tester";
        private readonly string lastName = "Test";
        private Random random = new Random();

        [Test]
        public void CreateAnAccountTest()
        {
            var homePage = new HomePageContactUsPageUnitTests(driver);

            homePage.VerifyHomePageLoadTest();
            SignInPageCreateAnAccountForm();
        }
        [Test]
        public void CreateAnAccountYourPersonalInfoTest()
        {
            var homePage = new HomePageContactUsPageUnitTests(driver);

            homePage.VerifyHomePageLoadTest();
            SignInPageCreateAnAccountForm();
            SignInPageYourPersonalInfoForm();
        }
        [Test]
        public void CreateAnAccountYourAdddressSectionTest()
        {

            var homePage = new HomePageContactUsPageUnitTests(driver);
            
            homePage.VerifyHomePageLoadTest();
            SignInPageCreateAnAccountForm();
            SignInPageYourAddressForm();

        }
        [Test]
        public void AlreadyRegisteredSectionTest()
        {
            var homePage = new HomePageContactUsPageUnitTests(driver);
            var signInPage = new HomePageSignInPO(driver);

            homePage.VerifyHomePageLoadTest();
            signInPage.SignInLink.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(e => signInPage.SignInPageContainer.Displayed);
            Assert.IsNotNull(signInPage.SignInPageContainer, $"nameof{signInPage.SignInPageContainer} returned as null");

            if (signInPage.AlreadyRegisteredSubHeading != null && signInPage.AlreadyRegisteredSubHeading.Displayed)
            {
                Assert.IsTrue(signInPage.AlreadyRegisteredSubHeading.Text.Equals("ALREADY REGISTERED?"),
                    $"Subheading 'ALREADY REGISTERED?' was not displayed, instead {signInPage.AlreadyRegisteredSubHeading.Text} displayed.");
            }
            bool v = false;
            Func<IWebElement, IWebElement, bool> isLableDisplayed = (e, e1) =>          
            {               
                v = (e != null && e.Displayed) && (e1 != null && e1.Displayed);
                return v;
            };
            isLableDisplayed(signInPage.RegisteredEmailAddressLabel, signInPage.RegisteredPasswordLabel);
            signInPage.RegisteredEmailAddressInput.SendKeys("call1800@test.com");
            signInPage.RegisteredPasswordInput.SendKeys("12345");
            signInPage.SignInButton.Click();
            
            wait.Until(e => signInPage.MyAccountHeading != null && signInPage.MyAccountHeading.Displayed);
            Assert.IsTrue(signInPage.InfoAccount.Text.Equals("Welcome to your account. Here you can manage all of your personal information and orders."),
                $"{signInPage.InfoAccount.Text} was not displayed.");

            List<IWebElement> LinkList = new List<IWebElement>() { signInPage.OrdersLink, signInPage.MyAddressesLink,
            signInPage.MyCreditSlipsLink, signInPage.MyPersonalInfoLink, signInPage.MyWishListsLink};

            IsEachElementDisplayed(LinkList);

        }
        [Test]
        public void MyAccountPageTest()
        {
            var homePage = new HomePageContactUsPageUnitTests(driver);
            var signInPage = new HomePageSignInPO(driver);

            homePage.VerifyHomePageLoadTest();
            signInPage.SignInLink.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(e => signInPage.SignInPageContainer.Displayed);
            Assert.IsNotNull(signInPage.SignInPageContainer, $"nameof{signInPage.SignInPageContainer} returned as null");


        }
        public void SignInPageCreateAnAccountForm()
        {
            signInPage = new HomePageSignInPO(driver);
            signInPage.SignInLink.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(e => signInPage.SignInPageContainer.Displayed);
            Assert.IsNotNull(signInPage.SignInPageContainer, $"nameof{signInPage.SignInPageContainer} returned as null");

            List<IWebElement> validateSignInPage = new List<IWebElement>() { signInPage.SignInPageHeading,
                signInPage.HomeIcon, signInPage.NavigationPage, signInPage.CreateAccountForm,
            signInPage.CreateAccountButton, signInPage.CreateAccountSubHeading, signInPage.FormContant,
                signInPage.EmailAddressLabel, signInPage.EmailInputBox};

            IsEachElementDisplayed(validateSignInPage);
            string invalidEmail = "test1234@test.com";
            signInPage.EmailInputBox.SendKeys(invalidEmail);
            signInPage.CreateAccountButton.Click();

            wait.Until(e => signInPage.CreateAccountErrorAlert.Displayed);

            string alertMessage = "An account using this email address has already been registered. Please enter a valid password or request a new one.";


            Assert.IsTrue(signInPage.CreateAccountErrorAlert.Text.Contains(alertMessage), $"Expected to return the message:{alertMessage} but returned {signInPage.CreateAccountErrorAlert.Text}");
            string validEmail = "call1800norah@test.com";
            signInPage.EmailInputBox.Clear();
            signInPage.EmailInputBox.SendKeys(validEmail);
            signInPage.CreateAccountButton.Click();
            Thread.Sleep(5000);
        }
        public void SignInPageYourPersonalInfoForm()
        {
            signInPage = new HomePageSignInPO(driver);

            Func<IWebElement, bool> accountFormDisplayed = e => e != null && e.Displayed;
            accountFormDisplayed(signInPage.AccountCreationForm);
            Assert.IsTrue(signInPage.AccountCreationForm.Displayed, $"nameof{signInPage.AccountCreationForm} was not displayed.");
            Assert.IsNotNull(signInPage.AccountCreationForm, $"nameof{signInPage.AccountCreationForm} returned as Null!");

            List<IWebElement> createAccountFormElements = new List<IWebElement>() { signInPage.TitleLabel,
                signInPage.MrLabel, signInPage.MrsLabel, signInPage.FirstnameLabel, signInPage.LastnameLabel,
                signInPage.EmailLabel, signInPage.PasswordLabel, signInPage.DateOfBirthLabel};
            IsEachElementDisplayed(createAccountFormElements);
            signInPage.GenderRadioButtons.Where(e => e != null).FirstOrDefault().Click();
            signInPage.FirstnameInput.SendKeys(firstname);
            signInPage.LastnameInput.SendKeys(lastName);
            string validPassword = "12345";
            string invalidPassword = "1234";
            signInPage.PasswordInput.SendKeys(invalidPassword);
            Assert.IsTrue(signInPage.PasswordFormInfo.Text.Equals("(Five characters minimum)"), $"nameof{signInPage.PasswordFormInfo} was not displayed.");
            signInPage.PasswordInput.Clear();
            signInPage.PasswordInput.SendKeys(validPassword);

            signInPage.DaysSelector.Click();

            List<string> daysOption = new List<string>();
            wait.Until(e => signInPage.DaysOptions.Where(e1 => e1 != null).Where(e1 => e1.Displayed));

            foreach (var day in signInPage.DaysOptions)
            {
                daysOption.Add(day.Text);
            }

            var randomdaysOption = random.Next(1, daysOption.Count - 1);
            signInPage.DaysSelector.SendKeys(daysOption[randomdaysOption]);

            List<string> monthOptions = new List<string>();
            wait.Until(e => signInPage.MonthsOptions.Where(e1 => e1 != null).Where(e1 => e1.Displayed));
            foreach (var month in signInPage.MonthsOptions)
            {
                monthOptions.Add(month.Text);
            }
            var randomMonthOption = random.Next(1, monthOptions.Count);
            string selectOption = monthOptions[randomMonthOption];

            signInPage.MonthsSelector.Click();
            signInPage.MonthsSelector.SendKeys(selectOption);

            List<string> optionYear = new List<string>();
            wait.Until(e => signInPage.YearOptions.Where(e1 => e1 != null).Where(e1 => e1.Displayed));
            foreach (var option in signInPage.YearOptions)
            {
                optionYear.Add(option.Text);
            }

            var randomYears = random.Next(1, optionYear.Count - 30);
            signInPage.YearsSelector.Click();
            signInPage.YearsSelector.SendKeys(optionYear[randomYears]);

            Assert.IsTrue(signInPage.NewsLetterLabel.Text.Equals("Sign up for our newsletter!"),
                $"nameof{signInPage.NewsLetterLabel}failed to return 'Sign up for our newsletter!', instead " +
                $"returned {signInPage.NewsLetterLabel}");
            signInPage.NewsLetterCheckbox.Click();
            signInPage.NewsLetterCheckbox.Click();


            Assert.IsTrue(signInPage.SpecialOfferLabel.Text.Equals("Receive special offers from our partners!"),
                $"nameof{signInPage.SpecialOfferLabel}failed to return 'Receive special offers from our partners!', instead " +
                $"returned {signInPage.SpecialOfferLabel}");
            signInPage.SpecialOfferCheckbox.Click();
            signInPage.SpecialOfferCheckbox.Click();
        }
        public void SignInPageYourAddressForm()
        {
            wait.Until(e => signInPage.YourAddressSubHeading != null && signInPage.YourAddressSubHeading.Displayed);

            List<IWebElement> addressInfoList = new List<IWebElement>() { signInPage.YourAddressSubHeading, signInPage.FirstNameLabel, signInPage.LastNameLabel,
            signInPage.CompanyLabel, signInPage.AddressOneLabel, signInPage.AddressTwoLabel,signInPage.CityLabel,
            signInPage.CountryLabel,  signInPage.InlineInfos, signInPage.HomePhoneLabel,
            signInPage.MobilePhoneLabel, signInPage.AddressAliasLabel};
            IsEachElementDisplayed(addressInfoList);

            signInPage = new HomePageSignInPO(driver);
            signInPage.FirstNameInputBox.SendKeys(firstname);
            signInPage.LastNameInputBox.SendKeys(lastName);
            signInPage.CompanyInputBox.SendKeys("Samsung");
            signInPage.AddressOneInputBox.SendKeys("100 BlueStar Street");
            signInPage.AddressTwoInputBox.SendKeys("Second Floor");
            signInPage.CityInputBox.SendKeys("St.Louis");


            List<string> stateOption = new List<string>();
            wait.Until(e => signInPage.StateOptions.Where(e1 => e1 != null).Where(e1 => e1.Displayed));

            foreach (var state in signInPage.StateOptions)
            {
                stateOption.Add(state.Text);
            }

            var randomdaysOption = random.Next(1, stateOption.Count - 1);
            signInPage.SelectState.Click();
            signInPage.SelectState.SendKeys(stateOption[randomdaysOption]);
            signInPage.PostcodeInpuBox.SendKeys("66999");
            signInPage.SelectCountry.Click();
            signInPage.CountryOptionSelected.Click();
            signInPage.HomePhoneInputBox.SendKeys("1234566789");
            signInPage.MobilePhoneInputBox.SendKeys("987654321");
            signInPage.AddressAliasInputBox.SendKeys("");
            signInPage.RegisterButton.Click();
        }
      
    }
}
