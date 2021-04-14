using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSeleniumProject.PageObjects
{
    public class HomePageContactUsPagePO 
    {
        private readonly IWebDriver _driver;
        public HomePageContactUsPagePO(IWebDriver driver)
        {
            _driver = driver;
         
        }
        public HomePageContactUsPagePO() { }
        public IWebElement WholePage => _driver.FindElement(By.XPath("//div[@id='page']"));
        public IWebElement Banner => _driver.FindElement(By.XPath("//div[@class='banner']"));
        public IWebElement CallUsNow => _driver.FindElement(By.XPath("//span[@class='shop-phone' and text()='Call us now: ']"));
        public IWebElement SearchBox => _driver.FindElement(By.XPath("//input[@id='search_query_top' and @name='search_query']"));
        public IWebElement ContactUs => _driver.FindElement(By.XPath("//div[@id='contact-link']//a[@title='Contact Us']"));
        public IWebElement SignIn => _driver.FindElement(By.XPath("//div[@class='header_user_info']//a[@title='Log in to your customer account']"));
        public IWebElement StoreLogo => _driver.FindElement(By.XPath("//img[@class='logo img-responsive' and @alt='My Store']"));
        public IWebElement ShoppingCart => _driver.FindElement(By.XPath("//div[@class='shopping_cart']//following::a[@title='View my shopping cart']"));
        public IWebElement MenuContent => _driver.FindElement(By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']"));
        public IWebElement HomepageSlicer => _driver.FindElement(By.XPath("//div[@id='homepage-slider']"));
        public ReadOnlyCollection<IWebElement> ContentItemCards => _driver.FindElements(By.XPath("//div[@id='htmlcontent_top']//following::li[contains(@class, 'htmlcontent')]"));
        public ReadOnlyCollection<IWebElement> HomepageTabs => _driver.FindElements(By.XPath("//ul[@id='home-page-tabs']//li"));
        public ReadOnlyCollection<IWebElement> ProductImageLinks => _driver.FindElements(By.XPath("//ul[@id='homefeatured']//img[contains(@class, 'replace-2x img-responsive')]"));
        public ReadOnlyCollection<IWebElement> CustomInfoBlocks => _driver.FindElements(By.XPath("//div[@id='cmsinfo_block']//div[@class='col-xs-6']"));
        public ReadOnlyCollection<IWebElement> CustomInfoEachBlocks => _driver.FindElements(By.XPath("//div[@id='cmsinfo_block']//div[@class='col-xs-6']//ul//li"));
        public IWebElement FacebookBlock => _driver.FindElement(By.XPath("//div[@id='facebook_block']"));
        public IWebElement EditorialBlock => _driver.FindElement(By.XPath("//div[@id='editorial_block_center']"));
        public IWebElement FooterContainer => _driver.FindElement(By.XPath("//div[@class='footer-container']"));

        //Contact Us Page
        public IWebElement ContactUsContainer => _driver.FindElement(By.XPath("//div[@class='columns-container']"));
        public IWebElement HomeIcon => _driver.FindElement(By.XPath("//a[@class='home' and @title = 'Return to Home']"));
        public IWebElement NavigationPageContact => _driver.FindElement(By.XPath("//span[@class='navigation_page' and text()='Contact']"));
        public IWebElement CustomerServiceHeader => _driver.FindElement(By.XPath("//h1[@class='page-heading bottom-indent']"));
        public IWebElement SendAMessageHeader => _driver.FindElement(By.XPath("//h3[@class='page-subheading' and text()='send a message']"));
        public IWebElement SubjectHeading => _driver.FindElement(By.XPath("//label[@for='id_contact' and text()='Subject Heading']"));
        public IWebElement SubjectHeadingOptionDropdown => _driver.FindElement(By.XPath("//div[@id='uniform-id_contact']//child::select"));
        public ReadOnlyCollection<IWebElement> SubjectHeadingOptions => _driver.FindElements(By.XPath("//select[@id='id_contact']//child::option"));
        public IWebElement CustomeServiceOptionComment => _driver.FindElement(By.XPath("//p[normalize-space()='For any question about a product, an order']"));
        public IWebElement CommentSymbol => _driver.FindElement(By.XPath("//p[@id='desc_contact2']//child::i[@class='icon-comment-alt']"));
        public IWebElement WebMasterComment => _driver.FindElement(By.XPath("//p[normalize-space()='If a technical problem occurs on this website']"));
        public IWebElement OptionChoose => _driver.FindElement(By.XPath("//div[@id = 'uniform-id_contact']//span[text()='-- Choose --']"));
        public IWebElement EmailAddressLabel => _driver.FindElement(By.XPath("//label[text()='Email address']"));
        public IWebElement EmailInputBox => _driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
        public IWebElement OrderReferenceLabel => _driver.FindElement(By.XPath("//label[text()='Order reference']"));
        public IWebElement OrderReferenceInputBox => _driver.FindElement(By.XPath("//input[@id='id_order']"));
        public IWebElement MessageLabel => _driver.FindElement(By.XPath("//label[@for='message']"));
        public IWebElement MessageBox => _driver.FindElement(By.XPath("//textarea[@id='message']"));
        public IWebElement AttachFileLabel => _driver.FindElement(By.XPath("//label[@for='fileUpload']"));
        public IWebElement ChooseFileButton => _driver.FindElement(By.XPath("//span[@class='action' and text()='Choose File']"));
        public IWebElement InputFilePath => _driver.FindElement(By.XPath("//input[@id='fileUpload' and @type='file']"));
        public IWebElement SendButton => _driver.FindElement(By.XPath("//button[@id='submitMessage']"));
        public IWebElement AlertSuccessMessage => _driver.FindElement(By.XPath("//p[@class='alert alert-success']"));
        public IWebElement FooterLinksHome => _driver.FindElement(By.XPath("//ul[@class='footer_links clearfix']//a[@class='btn btn-default button button-small']"));

    }
}
