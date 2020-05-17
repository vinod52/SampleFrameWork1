using OpenQA.Selenium;
using System;

namespace SampleFrameWork1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {        
        public SampleApplicationPage(IWebDriver driver) : base(driver){}

        public bool IsVisible { 
            get 
            {
                return Driver.Title.Contains("Sample Application Lifecycle - Sprint 1 - Ultimate QA");
            }
            internal set { }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-1/");
            Driver.Manage().Window.Maximize();
        }
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement SubmitBtn => Driver.FindElement(By.XPath("//input[@id='submitForm']"));
        internal UltimateQAHomePage FillOutFormAndSubmit(string firstName)
        {
          FirstNameField.SendKeys(firstName);
          SubmitBtn.Click();
          return new UltimateQAHomePage(Driver);            
        }

        private UltimateQAHomePage UltimateQAHomePage(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}