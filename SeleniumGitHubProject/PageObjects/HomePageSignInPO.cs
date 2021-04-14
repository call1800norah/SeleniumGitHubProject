using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSeleniumProject.PageObjects
{
 
    public class HomePageSignInPO : UnitTestBase
    {
        private readonly IWebDriver _driver;
        public HomePageSignInPO(IWebDriver driver)
        {
            _driver = driver;
        }
        public HomePageSignInPO() { }

        //Create An Account Section
        public IWebElement SignInLink => _driver.FindElement(By.XPath("//a[@class='login' and @title='Log in to your customer account']"));
        public IWebElement SignInPageContainer => _driver.FindElement(By.XPath("//div[@class='columns-container']"));
        public IWebElement HomeIcon => _driver.FindElement(By.XPath("//a[@title='Return to Home']"));
        public IWebElement NavigationPage => _driver.FindElement(By.XPath("//span[@class='navigation_page' and text()='	Authentication']"));
        public IWebElement SignInPageHeading => _driver.FindElement(By.XPath("//h1[@class='page-heading' and text()='Authentication']"));
        public IWebElement CreateAccountForm => _driver.FindElement(By.XPath("//form[@id='create-account_form']"));
        public IWebElement CreateAccountSubHeading => _driver.FindElement(By.XPath("//h3[@class='page-subheading' and text()='Create an account']"));
        public IWebElement FormContant => _driver.FindElement(By.XPath("//p[text()='Please enter your email address to create an account.']"));
        public IWebElement EmailAddressLabel => _driver.FindElement(By.XPath("//label[@for='email_create' and text()='Email address']"));
        public IWebElement EmailInputBox => _driver.FindElement(By.XPath("//input[@id='email_create']"));
        public IWebElement CreateAccountButton => _driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));
        public IWebElement CreateAccountErrorAlert => _driver.FindElement(By.XPath("//div[@class='alert alert-danger' and @id='create_account_error']"));
        
        //Your Personal Information Form
        public IWebElement AccountCreationForm => _driver.FindElement(By.XPath("//form[@id='account-creation_form']"));
        public IWebElement YourPersionalInfoHeading => _driver.FindElement(By.XPath("//h3[@class='page-subheading' and text()='Your personal information']"));
        public IWebElement TitleLabel => _driver.FindElement(By.XPath("//div[@class='clearfix']//label[text()='Title']"));
        public ReadOnlyCollection<IWebElement> GenderRadioButtons => _driver.FindElements(By.XPath("//div[@class='radio']//input[@type='radio']"));
        public IWebElement MrLabel => _driver.FindElement(By.XPath("//div[normalize-space()= 'Mr.']"));
        public IWebElement MrsLabel => _driver.FindElement(By.XPath("//div[normalize-space()= 'Mrs.']"));
        public IWebElement FirstnameLabel => _driver.FindElement(By.XPath("//label[@for='customer_firstname' and text()='First name ']"));
        public IWebElement FirstnameInput => _driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        public IWebElement LastnameLabel => _driver.FindElement(By.XPath("//label[@for='customer_lastname' and text()='Last name ']"));
        public IWebElement LastnameInput => _driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        public IWebElement EmailLabel => _driver.FindElement(By.XPath("//label[@for='email' and text()='Email ']"));
        public IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement PasswordLabel => _driver.FindElement(By.XPath("//label[@for='passwd' and text()='Password ']"));
        public IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@id='passwd']"));
        public IWebElement PasswordFormInfo => _driver.FindElement(By.XPath("//span[@class='form_info' and text()='(Five characters minimum)']"));
        public IWebElement DateOfBirthLabel => _driver.FindElement(By.XPath("//label[text()='Date of Birth']"));
        public IWebElement DaysSelector => _driver.FindElement(By.XPath("//select[@id='days']"));
        public IWebElement MonthsSelector => _driver.FindElement(By.XPath("//select[@id='months']"));
        public ReadOnlyCollection<IWebElement> YearOptions => _driver.FindElements(By.XPath("//select[@id='years']//option"));
        public ReadOnlyCollection<IWebElement> DaysOptions => _driver.FindElements(By.XPath("//select[@id='days']//option"));
        public ReadOnlyCollection<IWebElement> MonthsOptions => _driver.FindElements(By.XPath("//select[@id='months']//option"));
        public IWebElement YearsSelector => _driver.FindElement(By.XPath("//select[@id='years']"));
        public IWebElement NewsLetterLabel => _driver.FindElement(By.XPath("//label[@for='newsletter']"));
        public IWebElement SpecialOfferLabel => _driver.FindElement(By.XPath("//label[@for='optin']"));
        public IWebElement NewsLetterCheckbox => _driver.FindElement(By.XPath("//input[@id='newsletter']"));
        public IWebElement SpecialOfferCheckbox => _driver.FindElement(By.XPath("//input[@id='optin']"));

        //Your Address Form
        public IWebElement YourAddressSubHeading => _driver.FindElement(By.XPath("//h3[@class='page-subheading' and text()='Your address']"));
        public IWebElement FirstNameLabel => _driver.FindElement(By.XPath("//label[@for='firstname']"));
        public IWebElement LastNameLabel => _driver.FindElement(By.XPath("//label[@for='lastname']"));
        public IWebElement CompanyLabel => _driver.FindElement(By.XPath("//label[@for='company']"));
        public IWebElement AddressOneLabel => _driver.FindElement(By.XPath("//label[@for='address1']"));
        public IWebElement AddressTwoLabel => _driver.FindElement(By.XPath("//label[@for='address2']"));
        public IWebElement CityLabel => _driver.FindElement(By.XPath("//label[@for='city']"));
        public IWebElement StateLabel => _driver.FindElement(By.XPath("//label[@for='id_state']"));
        public IWebElement PostcodeLabel => _driver.FindElement(By.XPath("//label[@for='postcode']"));
        public IWebElement CountryLabel => _driver.FindElement(By.XPath("//label[@for='id_country']"));
        public IWebElement HomePhoneLabel => _driver.FindElement(By.XPath("//label[@for='phone']"));
        public IWebElement MobilePhoneLabel => _driver.FindElement(By.XPath("//label[@for='phone_mobile']"));
        public IWebElement AdditionalInfoLabel => _driver.FindElement(By.XPath("//label[@for='other"));
        public IWebElement AddressAliasLabel => _driver.FindElement(By.XPath("//label[@for='alias']"));
        public IWebElement FirstNameInputBox => _driver.FindElement(By.XPath("//input[@id='firstname']"));
        public IWebElement LastNameInputBox => _driver.FindElement(By.XPath("//input[@id='lastname']"));
        public IWebElement CompanyInputBox => _driver.FindElement(By.XPath("//input[@id='company']"));
        public IWebElement AddressOneInputBox => _driver.FindElement(By.XPath("//input[@id='address1']"));
        public IWebElement AddressTwoInputBox => _driver.FindElement(By.XPath("//input[@id='address2']"));
        public IWebElement CityInputBox => _driver.FindElement(By.XPath("//input[@id='city']"));
        public IWebElement SelectState => _driver.FindElement(By.XPath("//select[@id = 'id_state']"));
        public IWebElement SelectCountry => _driver.FindElement(By.XPath("//select[@id = 'id_country']"));
        public IWebElement PostcodeInpuBox => _driver.FindElement(By.XPath("//input[@id='postcode']"));
        public IWebElement AdditionalInfoInputBox => _driver.FindElement(By.XPath("//textarea[@id='other']"));
        public IWebElement HomePhoneInputBox => _driver.FindElement(By.XPath("//input[@id='phone']"));
        public IWebElement MobilePhoneInputBox => _driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
        public IWebElement AddressAliasInputBox => _driver.FindElement(By.XPath("//input[@id='alias']"));
        public IWebElement CountryOptionSelected => _driver.FindElement(By.XPath("//select[@id = 'id_state']//following::option[@selected='selected']"));
        public IWebElement InlineInfos => _driver.FindElement(By.XPath("//p[@class='inline-infos']"));
        public ReadOnlyCollection<IWebElement> StateOptions => _driver.FindElements(By.XPath("//select[@id = 'id_state']//following::option"));
        public ReadOnlyCollection<IWebElement> AddressInlineInfos => _driver.FindElements(By.XPath("//span[@class='inline-infos']"));
        public IWebElement RegisterButton => _driver.FindElement(By.XPath("//button[@id='submitAccount']"));

        //Already Registered Section
        public IWebElement AlreadyRegisteredSubHeading => _driver.FindElement(By.XPath("//h3[@class='page-subheading' and text()='Already registered?']"));
        public IWebElement RegisteredEmailAddressLabel => _driver.FindElement(By.XPath("//label[@for='email']"));
        public IWebElement RegisteredPasswordLabel => _driver.FindElement(By.XPath("//label[@for='passwd']"));
        public IWebElement RegisteredEmailAddressInput => _driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement RegisteredPasswordInput => _driver.FindElement(By.XPath("//input[@id='passwd']"));
        public IWebElement ForgotYourPassword => _driver.FindElement(By.XPath("//a[@title='Recover your forgotten password']"));
        public IWebElement SignInButton => _driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));

        //My Account Page
        public IWebElement MyAccountHeading => _driver.FindElement(By.XPath("//h1[@class='page-heading']"));
        public IWebElement InfoAccount => _driver.FindElement(By.XPath("//p[@class='info-account']"));
        public IWebElement OrdersLink => _driver.FindElement(By.XPath("//a[@title='Orders']"));
        public IWebElement MyWishListsLink => _driver.FindElement(By.XPath("//a[@title='My wishlists']"));
        public IWebElement MyCreditSlipsLink => _driver.FindElement(By.XPath("//a[@title='Credit slips']"));
        public IWebElement MyAddressesLink => _driver.FindElement(By.XPath("//a[@title='Addresses']"));
        public IWebElement MyPersonalInfoLink => _driver.FindElement(By.XPath("//a[@title='Information']"));




    } 
}
