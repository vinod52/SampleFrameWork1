using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SampleFrameWork1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement SubmitBtn => Driver.FindElement(By.XPath("(//input[@type='submit'])[1]"));
        public IWebElement LastNameField => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        private string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement OtherRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));
        public IWebElement FemaleGenderRadioButtonForEmergenctContact => Driver.FindElement(By.Id("radio2-f"));
        public IWebElement FirstNameFieldForEmergencyContact => Driver.FindElement(By.Id("f2"));
        public IWebElement LastNameFieldForEmergencyContact => Driver.FindElement(By.Id("l2"));

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
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Driver.Manage().Window.Maximize();
            Assert.IsTrue(IsVisible, 
                $"Sample Application page is not visible=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FillOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.firstName);
            LastNameField.SendKeys(user.lastName);
            SubmitBtn.Click();
            return new UltimateQAHomePage(Driver);
        }

        internal UltimateQAHomePage FillOutEmergenctDetails(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyContactUser.firstName);
            LastNameFieldForEmergencyContact.SendKeys(emergencyContactUser.lastName);
            SubmitBtn.Click();
            return new UltimateQAHomePage(Driver);
        }

        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.genderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmergenctContact.Click();
                    break;
                case Gender.Other:                    
                    break;
                default:
                    break;
            }
        }       

        private void SetGender(TestUser user)
        {
            switch (user.genderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

        //private UltimateQAHomePage UltimateQAHomePage(IWebDriver driver)
        //{
        //    throw new NotImplementedException();
        //}
    }
}