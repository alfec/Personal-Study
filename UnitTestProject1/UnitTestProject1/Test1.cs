using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class Test1
    {
        private IWebDriver browser;

        [TestInitialize]
        public void Iniciar()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://www.youtube.com.br");
        }

        [TestMethod]
        public void TestMethod1()
        {
            IWebElement signIn = browser.FindElement(By.Id("button"));
            signIn.Text.Equals("Sign In");
        }

        [TestMethod]
        public void pesquisar()
        {
            IWebElement pesquisar = browser.FindElement(By.Name("search_query"));
            pesquisar.SendKeys("kouji wada animepunch");
            pesquisar.SendKeys(Keys.Enter);

            IWebElement clicar = browser.FindElement(By.XPath("/html/body/iframe[1]"));
            browser.SwitchTo().Frame(clicar);
            clicar.Click();

            browser.SwitchTo().DefaultContent();
            
        }

        [TestCleanup]
        public void terminar()
        {
            browser.Close();
        }
    }
}
