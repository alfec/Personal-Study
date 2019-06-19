using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNunit
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    class TestUnit
    {
        

        [Test]

        static void Main(string[] args)
        {
            IWebDriver browser = new ChromeDriver();
            
            browser.Navigate().GoToUrl("http://www.google.com.br");
            browser.Manage().Window.Maximize();

            IWebElement barraPesquisar = browser.FindElement(By.Name("q"));
            barraPesquisar.SendKeys("gmail");
            barraPesquisar.SendKeys(Keys.Enter);

            var texto = browser.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div[1]/div/div/div[1]/a/h3")).Text;
            Assert.LessOrEqual(texto, "Gmail - Google");
        }

    }
}