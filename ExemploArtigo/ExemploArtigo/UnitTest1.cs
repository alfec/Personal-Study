using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ExemploArtigo
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver browser;

        [TestInitialize]
        public void Iniciar()
        {
            browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://www.facebook.com/");
            browser.Manage().Window.Maximize();
        }

        [TestMethod]
        public void PrimeiroTeste()
        {
            IWebElement nome = browser.FindElement(By.Name("firstname"));
            nome.SendKeys("Han");

            IWebElement id = browser.FindElement(By.Id("u_0_n"));
            id.SendKeys("Solo");

            IWebElement xpath = browser.FindElement(By.XPath("//*[@id='u_0_q']"));
            xpath.SendKeys("teste@teste.com");

            IWebElement reenterEmail = browser.FindElement(By.XPath("//*[@id='u_0_t']"));
            reenterEmail.SendKeys("teste@teste.com");

            IWebElement password = browser.FindElement(By.XPath("//*[@id='u_0_x']"));
            password.SendKeys("123abc.!");

            IWebElement dropDownDia = browser.FindElement(By.Id("day"));
            var selecionaIndex = new SelectElement(dropDownDia);
            selecionaIndex.SelectByIndex(13);

            IWebElement dropDownMes = browser.FindElement(By.Id("month"));
            var selecionaValue = new SelectElement(dropDownMes);
            selecionaValue.SelectByValue("3");
            
            IWebElement dropDownAno = browser.FindElement(By.Id("year"));
            var selecionaValor = new SelectElement(dropDownAno);
            selecionaValor.SelectByValue("1905");
            
            IWebElement radioButton = browser.FindElement(By.XPath("//*[@id='u_0_11']/span[2]"));
            radioButton.Click();
            
            IWebElement botao = browser.FindElement(By.Name("websubmit"));
            botao.Click();

            Thread.Sleep(5000);
        }

        [TestCleanup]
        public void Finaliza()
        {
            browser.Close();

            browser.Quit();
        }
    }

}
