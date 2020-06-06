using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SampleApp2
{
    internal class MyStoreAppPage :BaseSampleApplicationPage
    {         
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
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            Assert.IsTrue(IsVisble,
                $"My Store application page is not visible =>{PageTitle}"+
                 $"Actual:{Driver.Title}");
        }

        internal SearchPg SearchFunctionalityValidation(string searchKeyword)
        {
            SearchField.SendKeys(searchKeyword);
            SearchBtn.Click();
            return new SearchPg(Driver);
        }
    }
}