using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections;

namespace SampleApp2
{
    internal class SearchPg
    {
        protected IWebDriver Driver { get; set; }
        public bool IsVisible { 
            get
            {
                try
                {
                    return SearchResult.Displayed;
                }
                catch(NoSuchElementException)
                {
                    return false;
                }
            }
         }
        public SearchPg(IWebDriver driver)
        {
            Driver = driver;
        }
        //public IWebElement SearchResult => Driver.FindElement(By.XPath("//*[@src='http://automationpractice.com/img/p/7/7-home_default.jpg']"));
        public IWebElement SearchResult => Driver.FindElement(By.XPath("//*[@class='product_img_link' and @title='Blouse']"));        

        internal bool Contains(Item itemToCheckFor)
        {
            switch(itemToCheckFor)
            {
                case Item.Blouse:
                    return Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;                    
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");                    
            }
        }

    }
}