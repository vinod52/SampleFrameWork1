using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SampleFrameWork1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }

        [TestInitialize]
        public void SetUpForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            TheTestUser = new TestUser();
            TheTestUser.firstName = "Vinod";
            TheTestUser.lastName = "Thotakuri";
        }

        [TestMethod]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();            
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            System.Threading.Thread.Sleep(10000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA page was not visible");            
        }      
        [TestMethod]
        public void PretendTestNumber2()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            System.Threading.Thread.Sleep(10000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Ultimate QA page was not visible");
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
