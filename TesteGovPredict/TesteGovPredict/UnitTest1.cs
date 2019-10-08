using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteGovPredict
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver browser;

        [TestInitialize]
        public void Init()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.froala.com/wysiwyg-editor/examples/custom-emoticons");

        }

        [TestMethod]
        public void HappyPath()
        {
            IWebElement textEditor = browser.FindElement(By.XPath("//*[@id='froala-editor']/div[3]/div"));
            textEditor.SendKeys("Test");

            String x = "happyPath";
            ScreenShot(x);

            Thread.Sleep(1000);

            var text = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(text, "Test");
        }

        [TestMethod]
        public void SelectEmoji()
        {
            IWebElement clickEmoji = browser.FindElement(By.XPath("//*[@id='emoticons - 1']/svg"));
            clickEmoji.Click();

            IWebElement emoji = browser.FindElement(By.XPath("//*[@id='froala - editor']/div[1]/div[3]/div[2]/span[1]"));
            emoji.Click();

            String x = "SelectEmoji";
            ScreenShot(x);


            Thread.Sleep(1000);

            var text = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(text, "Grinning face");
        }

        [TestMethod]
        public void ValidateCount()
        {
            IWebElement textEditor = browser.FindElement(By.XPath("//*[@id='froala-editor']/div[3]/div"));
            textEditor.SendKeys("Validation of character count");

            String x = "ValidationCount";
            ScreenShot(x);

            Thread.Sleep(1000);

            var count = browser.FindElement(By.XPath("//*[@id='froala - editor']/div[4]/span")).Text;
            Assert.AreNotEqual(count, "Characters : 29");
        }

        public void ScreenShot(String x)
        {
            int y = 1;
            Screenshot ss = ((ITakesScreenshot)browser).GetScreenshot();
            string shot = "C:\\Users\\bogola\\Desktop\\Automação\\TesteGovPredict\\TesteGovPredict\\prints_" + x + y + ".png";
            ss.SaveAsFile(shot, ScreenshotImageFormat.Png);
            y++;
        }

        [TestCleanup]
        public void Finish()
        {
            browser.Close();
        }
    }
}
