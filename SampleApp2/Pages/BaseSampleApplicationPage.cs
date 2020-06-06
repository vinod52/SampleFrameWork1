using OpenQA.Selenium;

namespace SampleApp2
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