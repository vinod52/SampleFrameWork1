using OpenQA.Selenium;

namespace SampleFrameWork1
{
    internal class BaseSampleApplicationPage
    {
        protected IWebDriver Driver { get; set; }
        public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}