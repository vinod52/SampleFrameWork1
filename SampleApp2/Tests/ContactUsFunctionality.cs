using AutomationResrce;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("ContactUsFunctionality"), TestCategory("SampleApp2")]
    public class ContactUsFunctionality : BaseTest
    {        
        [TestMethod]
        [Description("Validating Contact Us page display with form")]
        [TestProperty("Author", "Vinod")]
        public void TCID2()
        {            
            ContactUsPage contactUsPg = new ContactUsPage(Driver);
            contactUsPg.GoTo();
            Assert.IsTrue(contactUsPg.IsLoaded,
               "The Contact us page did not load successfully");
        }      
    }
}
