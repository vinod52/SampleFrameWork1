using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using ReportingFramework.Pages;
using System;

namespace ReportingFramework
{
    internal class MyStoreAppPage :BaseSampleApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public Slider Slider { get; private set; }

        public string PageTitle => "My Store";
        public IWebElement SearchBtn => Driver.FindElement(By.CssSelector("#searchbox>button"));
        public IWebElement SearchField => Driver.FindElement(By.Id("search_query_top"));

        public bool IsVisble {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }       

        public MyStoreAppPage(IWebDriver driver) :base(driver)
        {            
            Slider = new Slider(Driver);
        }        
        
        internal void GoTo()
        {
            var URL = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(URL);
            Driver.Manage().Window.Maximize();
            Assert.IsTrue(IsVisble,
                $"My Store application page is not visible =>{PageTitle}"+
                 $"Actual:{Driver.Title}");
            _logger.Info($"Opened URL =>{URL}");
        }

        internal SearchPg SearchFunctionalityValidation(string searchKeyword)
        {
            SearchField.SendKeys(searchKeyword);
            SearchBtn.Click();
            _logger.Info($"Searched for an item in the search bar=>{searchKeyword}");
            return new SearchPg(Driver);
        }
    }
}