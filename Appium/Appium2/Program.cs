using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;

namespace Appium2
{
    [TestFixture()]
    public class ProgramTest
    {
        private AppiumDriver<AppiumWebElement> driver;

        [SetUp]
        public void beforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("deviceName", "Android Emulator");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("app", "<Path to your app>");
            driver = new AndroidDriver<AppiumWebElement>(
                           new Uri("http://127.0.0.1:4723/wd/hub"),
                               capabilities);
        }

        [TearDown]
        public void afterAll()
        {
            // shutdown
            driver.Quit();
        }

        [Test()]
        public void AppiumDriverMethodsTestCase()
        {
            // Using appium extension methods
            AppiumWebElement el = driver.FindElements(ByAndroidUIAutomator.(UiSelector().enabled(true)));
            el.SendKeys("abc");
            Assert.AreEqual(el.Text, "abc");
        }
    }

}