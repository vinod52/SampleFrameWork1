using AutomationResrce;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("SearchFunctionality")]
    public class SearchFunctionality
    {
        public IWebDriver Driver { get; set; }
        internal MyStoreAppPage myStorePg { get; private set; }
        internal TestUser TheTestUser { get; private set; }

        [TestMethod]
        [Description("Validating search functionality using a keyword")]
        [TestProperty("Author","Vinod")]
        public void TCID1()
        {
            TheTestUser = new TestUser();
            TheTestUser.SearchKeyword = "Blouse";
            string stringToSearch = "Blouse";
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            //Driver = GetChromeDriver();
            myStorePg = new MyStoreAppPage(Driver);
            myStorePg.GoTo();
            SearchPg SearchPgObj=myStorePg.SearchFunctionalityValidation(stringToSearch);
            //Assert.IsTrue(SearchPgObj.IsVisible, "No Search results with the keyword");
            Assert.IsTrue(SearchPgObj.Contains(Item.Blouse),
                $"When searching for the string=>{stringToSearch},"+
                $"we did not find it in the search results.");
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Quit();
        }        
    }
}
