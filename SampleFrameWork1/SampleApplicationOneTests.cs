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
        [TestMethod]
        public void Test1()
        {          
            Driver = GetChromeDriver();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible,"Sample Application page is not visible");

            var ultimateQAHomePage= sampleApplicationPage.FillOutFormAndSubmit("Vinod");
            System.Threading.Thread.Sleep(10000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(ultimateQAHomePage.IsVisible,"Ultimate QA page was not visible");
            Driver.Quit();
        }

        [TestMethod]
        public void PretendTestNumber2()
        {
            Driver = GetChromeDriver();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible, "Sample Application page is not visible");

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit("Vinod");
            System.Threading.Thread.Sleep(10000);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA page was not visible");
            Driver.Quit();
        }
        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
