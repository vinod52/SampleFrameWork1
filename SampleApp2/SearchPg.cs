using OpenQA.Selenium;

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
        public IWebElement SearchResult => Driver.FindElement(By.XPath("//*[@src='http://automationpractice.com/img/p/7/7-home_default.jpg']"));
    }
}