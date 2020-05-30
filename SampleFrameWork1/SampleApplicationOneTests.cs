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
        internal SampleApplicationPage sampleAppPage { get; private set; }
        internal TestUser TheTestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        [TestInitialize]
        public void SetUpForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            sampleAppPage = new SampleApplicationPage(Driver);
            TheTestUser = new TestUser();
            TheTestUser.firstName = "Vinod";
            TheTestUser.lastName = "Thotakuri";
            EmergencyContactUser = new TestUser();
            EmergencyContactUser.firstName = "Sujatha";
            EmergencyContactUser.lastName = "Annapareddy";
        }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            TheTestUser.genderType = Gender.Female;
            EmergencyContactUser.genderType = Gender.Female;
            sampleAppPage.GoTo();
            sampleAppPage.FillOutEmergenctDetails(EmergencyContactUser);
            var ultimateQAHomePage = sampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            System.Threading.Thread.Sleep(10000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AssertPageVisible(ultimateQAHomePage);
        }       

        [TestMethod]
        [Description("Fake 2nd test.")]
        public void PretendTestNumber2()
        {
            sampleAppPage.GoTo();
            sampleAppPage.FillOutEmergenctDetails(EmergencyContactUser);
            var ultimateQAHomePage = sampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            System.Threading.Thread.Sleep(10000);            
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }       

        [TestMethod]
        [Description("Validating that when selecting other gender type form is submitted successfully.")]
        public void PretendTestNumber3()
        {
            TheTestUser.genderType = Gender.Other;
            EmergencyContactUser.genderType = Gender.Female;
            sampleAppPage.GoTo();
            var ultimateQAHomePage = sampleAppPage.FillOutEmergenctDetails(EmergencyContactUser);
            //var ultimateQAHomePage = sampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            System.Threading.Thread.Sleep(10000);            
            AssertPageVisibleVariation2(ultimateQAHomePage);
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

        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA page was not visible");
        }
        private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Ultimate QA page was not visible");
        }
    }
}
