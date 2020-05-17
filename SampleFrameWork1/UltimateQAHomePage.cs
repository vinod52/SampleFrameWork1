using OpenQA.Selenium;

namespace SampleFrameWork1
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {        
        public UltimateQAHomePage(IWebDriver driver) : base(driver){}

        public bool IsVisible => AutomationRegLink.Displayed;

        public IWebElement AutomationRegLink => Driver.FindElement(By.XPath("//a[contains(@class, 'et_pb_button et_pb_custom_button_icon et_pb_button_0 et_hover_enabled et_pb_bg_layout_light')]"));
    }
}