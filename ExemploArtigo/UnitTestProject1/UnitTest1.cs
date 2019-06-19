using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMtest.PageObject;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver browser;

        [TestInitialize]
        public void SetUp()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            HomePage home = new HomePage(browser);
            home.NavegaTo();
            home.FazLogin();

            var x = "André";
            Assert.AreEqual("André", x);
        }

        [TestCleanup]
        public void Finish()
        {
            browser.Close();
        }
    }
}
