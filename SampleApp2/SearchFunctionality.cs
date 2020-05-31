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
        public void TestMethod1()
        {
            TheTestUser = new TestUser();
            TheTestUser.SearchKeyword = "Blouse";
            Driver = GetChromeDriver();
            myStorePg = new MyStoreAppPage(Driver);
            myStorePg.GoTo();
            var SearchPgObj=myStorePg.SearchFunctionalityValidation(TheTestUser);            
            Assert.IsTrue(SearchPgObj.IsVisible, "No Search results with the keyword");
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
