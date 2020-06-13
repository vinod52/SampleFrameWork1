using OpenQA.Selenium;

namespace ReportingFramework
{
    public class BaseSampleApplicationPage
    {
        protected IWebDriver Driver { get; set; }
        public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}