using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMtest.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMtest
{
    public class TestPage
    {
        private IWebDriver browser;

        [SetUp]
        public void SetUp()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
        }

        [Test]
        public void PrimeiroTeste()
        {
            HomePage home = new HomePage(browser);
            home.NavegaTo();
            home.FazLogin();

            var x = "André";
            Assert.AreEqual("André", x);
        }

        [TearDown]
        public void Finish()
        {
            browser.Quit();
            browser.Close();
        }

    }
}
