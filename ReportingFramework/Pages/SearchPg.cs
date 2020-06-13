using OpenQA.Selenium;
using System;
using System.Collections;
using AventStack.ExtentReports;
using NLog;

namespace ReportingFramework.Pages
{
    internal class SearchPg : BaseSampleApplicationPage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //protected IWebDriver Driver { get; set; }
        //public bool IsVisible { 
        //    get
        //    {
        //        try
        //        {
        //            return SearchResult.Displayed;
        //        }
        //        catch(NoSuchElementException)
        //        {
        //            return false;
        //        }
        //    }
        // }
        //public IWebElement SearchResult => Driver.FindElement(By.XPath("//*[@src='http://automationpractice.com/img/p/7/7-home_default.jpg']"));
        //public IWebElement SearchResult => Driver.FindElement(By.XPath("//*[@class='product_img_link' and @title='Blouse']"));        

        public SearchPg(IWebDriver driver) : base(driver)
        {            
        }
    
        internal bool Contains(Item itemToCheckFor)
        {
           Reporter.LogTestStepForBugLogger(Status.Info,$"Validate that item=>{itemToCheckFor} exists.");
            switch (itemToCheckFor)
            {
                case Item.Blouse:
                    var isBlouseDisplayed = Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;
                    Logger.Trace("Element found by XPath=>*[@title=\'Blouse\'] isDisplayed=>" + isBlouseDisplayed);
                    return isBlouseDisplayed;
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }

    }
}