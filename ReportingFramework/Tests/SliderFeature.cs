using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingFramework.Tests
{
    [TestClass]
    [TestCategory("SliderFeature"), TestCategory("SampleApp2")]
    public class SliderFeature : BaseTest
    {        
        [TestMethod]
        [Description("Validate that slider changes images")]
        [TestProperty("Author","Vinod")]
        public void TCID3()
        {
            MyStoreAppPage homePage = new MyStoreAppPage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;
            Assert.AreNotEqual(currentImage, newImage,
                "The slider images did not change when pressing the next button.");
        }
    }
}
