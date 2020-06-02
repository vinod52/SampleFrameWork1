using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AutomationResrce
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch(browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();                    
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
