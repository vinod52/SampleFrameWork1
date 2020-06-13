using OpenQA.Selenium;
using System;

namespace ReportingFramework
{
    public class Slider : BaseSampleApplicationPage
    {
        private IWebDriver driver;
        public string CurrentImage => MainSliderImage.GetAttribute("style");
        private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));
        public Slider(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }       
        internal void ClickNextButton()
        {
            Driver.FindElement(By.ClassName("bx-next")).Click();
        }
    }
}