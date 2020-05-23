using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-2/");
            Driver.Manage().Window.Maximize();
            Assert.IsTrue(IsVisible, 
                $"Sample Application page is not visible=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement SubmitBtn => Driver.FindElement(By.XPath("(//input[@type='submit'])[1]"));

        public IWebElement LastNameField => Driver.FindElement(By.XPath("//input[@name='lastname']"));

        private string PageTitle => "Sample Application Lifecycle - Sprint 2 - Ultimate QA";

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
          FirstNameField.SendKeys(user.firstName);
          LastNameField.SendKeys(user.lastName);
          SubmitBtn.Click();
          return new UltimateQAHomePage(Driver);            
        }

        private UltimateQAHomePage UltimateQAHomePage(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}